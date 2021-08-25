using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Models
{
    public class CardInDeckModel
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public int NbCard { get; set; }
    }
}
