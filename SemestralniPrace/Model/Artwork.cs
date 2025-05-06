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
        public DateTime DatePublished { get; set; }
        public BaseModel Style { get; set; }
        public BaseModel Substrate { get; set; }
        public BaseModel Technique { get; set; }
        public Artist Artist { get; set; }
        public ArtExhibit? ArtExhibit { get; set; }

        public Artwork() { }

        public Artwork(int id, string name, string description, int width, int height, DateTime datePublished, BaseModel style, BaseModel substrate, BaseModel technique, Artist artist, ArtExhibit? artExhibit) : base(id, name, description)
        {
            Width = width;
            Height = height;
            DatePublished = datePublished;
            Style = style;
            Substrate = substrate;
            Technique = technique;
            Artist = artist;
            ArtExhibit = artExhibit;
        }
    }
}
