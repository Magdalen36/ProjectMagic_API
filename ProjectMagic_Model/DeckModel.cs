using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Models
{
    public class DeckModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeckName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Color { get; set; }
    }
}
