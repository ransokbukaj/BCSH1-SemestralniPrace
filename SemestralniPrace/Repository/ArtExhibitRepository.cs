using SemestralniPrace.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralniPrace.Repository
{
    public class ArtExhibitRepository : IRepository<ArtExhibit>
    {
        public List<ArtExhibit> GetList(BaseModel filter)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            var query = "SELECT * FROM ArtExhibits";
            var conditions = new List<string>();

            if (filter is ArtExhibit artExhibitFilter)
            {
                if (!string.IsNullOrWhiteSpace(artExhibitFilter.Name))
                {
                    conditions.Add("Name = @Name");
                    command.Parameters.AddWithValue("@Name", artExhibitFilter.Name);
                }

                if (artExhibitFilter.StartDate != DateTime.MinValue)
                {
                    conditions.Add("StartDate = @StartDate");
                    command.Parameters.AddWithValue("@StartDate", artExhibitFilter.StartDate.Date);
                }

                if (artExhibitFilter.EndDate != null)
                {
                    conditions.Add("EndDate = @EndDate");
                    command.Parameters.AddWithValue("@EndDate", artExhibitFilter.EndDate.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(artExhibitFilter.Description))
                {
                    conditions.Add("Description = @Description");
                    command.Parameters.AddWithValue("@Description", artExhibitFilter.Description);
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }
            }

            command.CommandText = query;

            var artExhibits = new List<ArtExhibit>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                artExhibits.Add(new ArtExhibit(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetDateTime("StartDate"),
                    reader.IsDBNull("EndDate") ? null : reader.GetDateTime("EndDate")
                ));
            }

            return artExhibits;
        }

        public ArtExhibit Get(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ArtExhibits WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new ArtExhibit(
                reader.GetInt32("Id"),
                reader.GetString("Name"),
                reader.GetString("Description"),
                reader.GetDateTime("StartDate"),
                reader.IsDBNull("EndDate") ? null : reader.GetDateTime("EndDate")
            );
        }

        public bool Save(ArtExhibit artExhibit)
        {
            if (artExhibit == null) return false;

            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();

            if (artExhibit.Id == 0)
            {
                command.CommandText = "INSERT INTO ArtExhibits (Name, Description, StartDate, EndDate) VALUES (@Name, @Description, @StartDate, @EndDate)";
            }
            else
            {
                command.CommandText = "UPDATE ArtExhibits SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", artExhibit.Id);
            }

            command.Parameters.AddWithValue("@Name", artExhibit.Name);
            command.Parameters.AddWithValue("@Description", artExhibit.Description);
            command.Parameters.AddWithValue("@StartDate", artExhibit.StartDate.Date);
            command.Parameters.AddWithValue("@EndDate", artExhibit.EndDate.HasValue ? artExhibit.EndDate.Value.Date : DBNull.Value);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Artworks WHERE ArtExhibitId = @Id";
            command.Parameters.AddWithValue("@Id", id);

            var result = command.ExecuteScalar();
            int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);

            if (count > 0) return false;

            command.CommandText = "DELETE FROM ArtExhibits WHERE Id = @Id";
            command.ExecuteNonQuery();
            return true;
        }

        public bool ImportCsv(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            var lines = File.ReadAllLines(filePath);
            bool success = true;

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length < 4)
                {
                    success = false;
                    continue;
                }

                try
                {
                    var artExhibit = new ArtExhibit
                    {
                        Name = parts[0].Trim(),
                        Description = parts[4].Trim(),
                        StartDate = DateTime.Parse(parts[2].Trim()),
                        EndDate = string.IsNullOrWhiteSpace(parts[3]) ? null : DateTime.Parse(parts[3].Trim()),
                    };
                    success &= Save(artExhibit);
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
                var artExhibits = GetList(filter);
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                foreach (var artExhibit in artExhibits)
                {
                    var line = string.Join("|",
                    [
                        artExhibit.Name,
                        artExhibit.Description,
                        artExhibit.StartDate.ToString("yyyy-MM-dd"),
                        artExhibit.EndDate?.ToString("yyyy-MM-dd") ?? "",
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
    }
}
