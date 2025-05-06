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
    public class ArtworkRepository : IRepository<Artwork>
    {
        private ArtExhibitRepository artExhibitRepository;
        private ArtistRepository artistRepository;
        private StyleRepository styleRepository;
        private SubstrateRepository substrateRepository;
        private TechniqueRepository techniqueRepository;

        public ArtworkRepository()
        {
            artExhibitRepository = new ArtExhibitRepository();
            artistRepository = new ArtistRepository();
            styleRepository = new StyleRepository();    
            substrateRepository = new SubstrateRepository();
            techniqueRepository = new TechniqueRepository();
        }

        public List<Artwork> GetList(BaseModel filter)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            var query = "SELECT * FROM Artworks";
            var conditions = new List<string>();

            if (filter is Artwork artworkFilter)
            {
                if (artworkFilter.Id > 0)
                {
                    conditions.Add("Id = @Id");
                    command.Parameters.AddWithValue("@Id", artworkFilter.Id);
                }

                if (!string.IsNullOrWhiteSpace(artworkFilter.Name))
                {
                    conditions.Add("Name = @Name");
                    command.Parameters.AddWithValue("@Name", artworkFilter.Name);
                }

                if (!string.IsNullOrWhiteSpace(artworkFilter.Description))
                {
                    conditions.Add("Description = @Description");
                    command.Parameters.AddWithValue("@Description", artworkFilter.Description);
                }

                if (artworkFilter.Width > 0)
                {
                    conditions.Add("Width = @Width");
                    command.Parameters.AddWithValue("@Width", artworkFilter.Width);
                }

                if (artworkFilter.Height > 0)
                {
                    conditions.Add("Height = @Height");
                    command.Parameters.AddWithValue("@Height", artworkFilter.Height);
                }

                if (artworkFilter.DatePublished != DateTime.MinValue)
                {
                    conditions.Add("DatePublished = @DatePublished");
                    command.Parameters.AddWithValue("@DatePublished", artworkFilter.DatePublished.Date);
                }

                if (artworkFilter.Style != null && artworkFilter.Style.Id > 0)
                {
                    conditions.Add("StyleId = @StyleId");
                    command.Parameters.AddWithValue("@StyleId", artworkFilter.Style.Id);
                }

                if (artworkFilter.Substrate != null && artworkFilter.Substrate.Id > 0)
                {
                    conditions.Add("SubstrateId = @SubstrateId");
                    command.Parameters.AddWithValue("@SubstrateId", artworkFilter.Substrate.Id);
                }

                if (artworkFilter.Technique != null && artworkFilter.Technique.Id > 0)
                {
                    conditions.Add("TechniqueId = @TechniqueId");
                    command.Parameters.AddWithValue("@TechniqueId", artworkFilter.Technique.Id);
                }

                if (artworkFilter.Artist != null && artworkFilter.Artist.Id > 0)
                {
                    conditions.Add("ArtistId = @ArtistId");
                    command.Parameters.AddWithValue("@ArtistId", artworkFilter.Artist.Id);
                }

                if (artworkFilter.ArtExhibit != null && artworkFilter.ArtExhibit.Id > 0)
                {
                    conditions.Add("ArtExhibitId = @ArtExhibitId");
                    command.Parameters.AddWithValue("@ArtExhibitId", artworkFilter.ArtExhibit.Id);
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }
            }

            command.CommandText = query;

            var artworks = new List<Artwork>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                artworks.Add(new Artwork
                (
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetInt32("Width"),
                    reader.GetInt32("Height"),
                    reader.GetDateTime("DatePublished"),
                    styleRepository.Get(reader.GetInt32("StyleId")),
                    substrateRepository.Get(reader.GetInt32("SubstrateId")),
                    techniqueRepository.Get(reader.GetInt32("TechniqueId")),
                    artistRepository.Get(reader.GetInt32("ArtistId")),
                    artExhibitRepository.Get(reader.GetInt32("ArtExhibitId"))
                ));
            }

            return artworks;
        }

        public Artwork Get(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Artworks WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new Artwork(
                reader.GetInt32("Id"),
                reader.GetString("Name"),
                reader.GetString("Description"),
                reader.GetInt32("Width"),
                reader.GetInt32("Height"),
                reader.GetDateTime("DatePublished"),
                styleRepository.Get(reader.GetInt32("StyleId")),
                substrateRepository.Get(reader.GetInt32("SubstrateId")),
                techniqueRepository.Get(reader.GetInt32("TechniqueId")),
                artistRepository.Get(reader.GetInt32("ArtistId")),
                artExhibitRepository.Get(reader.GetInt32("ArtExhibitId"))
            );
        }

        public bool Save(Artwork artwork)
        {
            if (artwork == null) return false;

            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();

            if (artwork.Id == 0)
            {
                command.CommandText = "INSERT INTO Artworks (Name, Description, Width, Height, DatePublished, StyleId, SubstrateId, TechniqueId, ArtistId, ArtExhibitId) VALUES (@Name, @Description, @Width, @Height, @DatePublished, @StyleId, @SubstrateId, @TechniqueId, @ArtistId, @ArtExhibitId)";
            }
            else
            {
                command.CommandText = "UPDATE Artworks SET Name = @Name, Description = @Description, Width = @Width, Height = @Height, DatePublished = @DatePublished, StyleId = @StyleId, SubstrateId = @SubstrateId, TechniqueId = @TechniqueId, ArtistId = @ArtistId, ArtExhibitId = @ArtExhibitId WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", artwork.Id);
            }

            command.Parameters.AddWithValue("@Name", artwork.Name);
            command.Parameters.AddWithValue("@Description", artwork.Description);
            command.Parameters.AddWithValue("@Width", artwork.Width);
            command.Parameters.AddWithValue("@Height", artwork.Height);
            command.Parameters.AddWithValue("@DatePublished", artwork.DatePublished.Date);
            command.Parameters.AddWithValue("@StyleId", artwork.Style.Id);
            command.Parameters.AddWithValue("@SubstrateId", artwork.Substrate.Id);
            command.Parameters.AddWithValue("@TechniqueId", artwork.Technique.Id);
            command.Parameters.AddWithValue("@ArtistId", artwork.Artist.Id);
            command.Parameters.AddWithValue("@ArtExhibitId", artwork.ArtExhibit?.Id);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            using var connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Artworks WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
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

                if (parts.Length < 10)
                {
                    success = false;
                    continue;
                }

                try
                {
                    var artwork = new Artwork
                    {
                        Name = parts[0].Trim(),
                        Description = parts[1].Trim(),
                        Width = int.Parse(parts[2].Trim()),
                        Height = int.Parse(parts[3].Trim()),
                        DatePublished = DateTime.Parse(parts[4].Trim()),
                        Style = new BaseModel { Id = int.Parse(parts[5].Trim()) },
                        Substrate = new BaseModel { Id = int.Parse(parts[6].Trim()) },
                        Technique = new BaseModel { Id = int.Parse(parts[7].Trim()) },
                        Artist = new Artist { Id = int.Parse(parts[8].Trim()) },
                        ArtExhibit = string.IsNullOrWhiteSpace(parts[9]) ? null : new ArtExhibit { Id = int.Parse(parts[9].Trim()) },
                    };
                    success &= Save(artwork);
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
                var artworks = GetList(filter);
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                foreach (var artwork in artworks)
                {
                    var line = string.Join("|",
                    [
                        artwork.Name,
                        artwork.Description,
                        artwork.Width,
                        artwork.Height,
                        artwork.DatePublished.ToString("yyyy-MM-dd"),
                        artwork.Style.Id,
                        artwork.Substrate.Id,
                        artwork.Technique.Id,
                        artwork.Artist.Id,
                        artwork.ArtExhibit == null ? "" : artwork.ArtExhibit.Id,
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
