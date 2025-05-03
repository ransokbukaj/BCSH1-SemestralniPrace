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
    public class StyleRepository : IRepository<BaseModel>
    {
        public List<BaseModel> GetList(BaseModel filter)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            var query = "SELECT * FROM Styles";
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

            var styles = new List<BaseModel>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                styles.Add(new BaseModel(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.IsDBNull("Description") ? null : reader.GetString("Description")
                ));
            }

            return styles;
        }

        public BaseModel Get(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Styles WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new BaseModel(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Name")),
                reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
            );
        }

        public bool Save(BaseModel style)
        {
            if (style == null) return false;

            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();

            if (style.Id == 0)
            {
                command.CommandText = "INSERT INTO Styles (Name, Description) VALUES (@Name, @Description)";
            }
            else
            {
                command.CommandText = "UPDATE Styles SET Name = @Name, Description = @Description WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", style.Id);
            }

            command.Parameters.AddWithValue("@Name", style.Name);
            command.Parameters.AddWithValue("@Description", style.Description);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Styles WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id); 

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
                var styles = GetList(filter);
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                foreach (var style in styles)
                {
                    var line = string.Join("|",
                    [
                        style.Name,
                        style.Description,
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
