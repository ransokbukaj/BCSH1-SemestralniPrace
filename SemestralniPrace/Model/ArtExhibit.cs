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
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ArtExhibit() { }

        public ArtExhibit(int id, string name, string description, DateTime startDate, DateTime? endDate) : base(id, name, description)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
