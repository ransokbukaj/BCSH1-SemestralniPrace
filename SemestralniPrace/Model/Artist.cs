using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemestralniPrace.Model
{
    public class Artist : BaseModel
    {
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public Artist() { }

        public Artist(int id, string name, string surname, DateTime birthDate, DateTime? deathDate, string? description) : base(id, name, description)
        {
            Surname = surname;
            BirthDate = birthDate;
            DeathDate = deathDate;
        }
    }
}
