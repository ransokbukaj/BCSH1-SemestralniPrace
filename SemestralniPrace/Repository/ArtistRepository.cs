using SemestralniPrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace SemestralniPrace.Repository
{
    public class ArtistRepository : IRepository<Artist>
    {
        public List<Artist> GetList(BaseModel filter)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            var query = "SELECT * FROM Artists";
            var conditions = new List<string>();

            if (filter is Artist artistFilter)
            {
                if (!string.IsNullOrWhiteSpace(artistFilter.Name))
                {
                    conditions.Add("Name = @Name");
                    command.Parameters.AddWithValue("@Name", artistFilter.Name);
                }

                if (!string.IsNullOrWhiteSpace(artistFilter.Surname))
                {
                    conditions.Add("Surname = @Surname");
                    command.Parameters.AddWithValue("@Surname", artistFilter.Surname);
                }

                if (artistFilter.BirthDate != DateTime.MinValue)
                {
                    conditions.Add("BirthDate = @BirthDate");
                    command.Parameters.AddWithValue("@BirthDate", artistFilter.BirthDate);
                }

                if (artistFilter.DeathDate != null)
                {
                    conditions.Add("DeathDate = @DeathDate");
                    command.Parameters.AddWithValue("@DeathDate", artistFilter.DeathDate);
                }

                if (!string.IsNullOrWhiteSpace(artistFilter.Description))
                {
                    conditions.Add("Description = @Description");
                    command.Parameters.AddWithValue("@Description", artistFilter.Description);
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }
            }

            command.CommandText = query;

            var artists = new List<Artist>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                artists.Add(new Artist(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.GetString("Surname"),
                    reader.GetDateTime("BirthDate"),
                    reader.IsDBNull("DeathDate") ? null : reader.GetDateTime("DeathDate"),
                    reader.IsDBNull("Description") ? null : reader.GetString("Description")
                ));
            }

            return artists;
        }

        public Artist? Get(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Artists WHERE Id = @Id";

            AddParameter(command, "@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new Artist(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Name")),
                reader.GetString(reader.GetOrdinal("Surname")),
                reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                reader.IsDBNull(reader.GetOrdinal("DeathDate")) ? null : reader.GetDateTime(reader.GetOrdinal("DeathDate")),
                reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
            );
        }

        public bool Save(Artist artist)
        {
            if (artist == null) return false;

            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();

            if (artist.Id == 0)
            {
                command.CommandText =
                    "INSERT INTO Artists (Name, Surname, BirthDate, DeathDate, Description) " +
                    "VALUES (@Name, @Surname, @BirthDate, @DeathDate, @Description)";
            }
            else
            {
                command.CommandText =
                    "UPDATE Artists SET Name = @Name, Surname = @Surname, " +
                    "BirthDate = @BirthDate, DeathDate = @DeathDate, Description = @Description " +
                    "WHERE Id = @Id";
                AddParameter(command, "@Id", artist.Id);
            }

            AddParameter(command, "@Name", artist.Name);
            AddParameter(command, "@Surname", artist.Surname);
            AddParameter(command, "@BirthDate", artist.BirthDate);
            AddParameter(command, "@DeathDate", artist.DeathDate);
            AddParameter(command, "@Description", artist.Description);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Artists WHERE Id = @Id";

            AddParameter(command, "@Id", id);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool ImportCsv(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            var lines = File.ReadAllLines(filePath);
            bool success = true;

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length < 5)
                {
                    success = false;
                    continue;
                }

                try
                {
                    var artist = new Artist
                    {
                        Name = parts[0].Trim(),
                        Surname = parts[1].Trim(),
                        BirthDate = DateTime.Parse(parts[2].Trim()),
                        DeathDate = string.IsNullOrWhiteSpace(parts[3]) ? null : DateTime.Parse(parts[3].Trim()),
                        Description = string.IsNullOrWhiteSpace(parts[4]) ? null : parts[4].Trim()
                    };
                    success &= Save(artist);
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        public bool ExportCsv(string filePath, BaseModel filter)
        {
            try
            {
                var artists = GetList(filter);
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                foreach (var artist in artists)
                {
                    var line = string.Join("|",
                    [
                        artist.Name,
                        artist.Surname,
                        artist.BirthDate.ToString("yyyy-MM-dd"),
                        artist.DeathDate?.ToString("yyyy-MM-dd") ?? "",
                        artist.Description ?? ""
                    ]);
                    writer.WriteLine(line);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void AddParameter(IDbCommand command, string name, object? value)
        {
            var param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = value ?? DBNull.Value;
            command.Parameters.Add(param);
        }
    }
}
