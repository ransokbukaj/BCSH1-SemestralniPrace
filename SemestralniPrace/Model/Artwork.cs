using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralniPrace.Model
{
    public class Artwork : BaseModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public DateOnly DatePublished { get; set; }
        public BaseModel Style { get; set; }
        public BaseModel Substrate { get; set; }
        public BaseModel Technique { get; set; }
        public Artist Artist { get; set; }
        public ArtExhibit? ArtExhibit { get; set; }

        public Artwork(int id, string name, string description, int width, int height, DateOnly datePublished, Artist artist, ArtExhibit? Artexhibit) : base(id, name, description)
        {
            Width = width;
            Height = height;
            DatePublished = datePublished;
            Artist = artist;
            ArtExhibit = Artexhibit;
        }
    }
}
