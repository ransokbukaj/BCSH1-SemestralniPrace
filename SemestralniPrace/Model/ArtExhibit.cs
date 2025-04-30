using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemestralniPrace.Model
{
    public class ArtExhibit : BaseModel
    {
        public ArtExhibit(int id, string name, string description) : base(id, name, description) { }
    }
}
