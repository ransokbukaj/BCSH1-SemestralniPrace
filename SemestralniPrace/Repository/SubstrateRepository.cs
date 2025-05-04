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
    public class SubstrateRepository : IRepository<BaseModel>
    {
        public List<BaseModel> GetList(BaseModel filter)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            var query = "SELECT * FROM Substrates";
            var conditions = new List<string>();

            if (filter is Artist artistFilter)
            {
                if (!string.IsNullOrWhiteSpace(artistFilter.Name))
                {
                    conditions.Add("Name = @Name");
                    command.Parameters.AddWithValue("@Name", artistFilter.Name);
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

            var substrates = new List<BaseModel>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                substrates.Add(new BaseModel(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.IsDBNull("Description") ? null : reader.GetString("Description")
                ));
            }

            return substrates;
        }

        public BaseModel Get(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Substrates WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new BaseModel(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Name")),
                reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
            );
        }

        public bool Save(BaseModel substrate)
        {
            if (substrate == null) return false;

            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();

            if (substrate.Id == 0)
            {
                command.CommandText = "INSERT INTO Substrates (Name, Description) VALUES (@Name, @Description)";
            }
            else
            {
                command.CommandText = "UPDATE Substrates SET Name = @Name, Description = @Description WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", substrate.Id);
            }

            command.Parameters.AddWithValue("@Name", substrate.Name);
            command.Parameters.AddWithValue("@Description", substrate.Description);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Artworks WHERE SubstrateId = @Id";
            command.Parameters.AddWithValue("@Id", id);

            var result = command.ExecuteScalar();
            int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);

            if (count > 0) return false;

            command.CommandText = "DELETE FROM Substrates WHERE Id = @Id";
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

                if (parts.Length < 2)
                {
                    success = false;
                    continue;
                }

                try
                {
                    var artist = new BaseModel
                    {
                        Name = parts[0].Trim(),
                        Description = string.IsNullOrWhiteSpace(parts[1]) ? null : parts[1].Trim(),
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
                var substrates = GetList(filter);
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                foreach (var substrate in substrates)
                {
                    var line = string.Join("|",
                    [
                        substrate.Name,
                        substrate.Description,
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
