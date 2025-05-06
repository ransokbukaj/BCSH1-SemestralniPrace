using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralniPrace.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BaseModel() { }

        public BaseModel(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
