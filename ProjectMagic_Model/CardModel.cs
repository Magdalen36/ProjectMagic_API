using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Models
{
    public class CardModel
    {
        //Je fais le meme modele pour ma liste de cartes et pour les cartes détails, 
        //mais je n'afficherai pas tout dans le mvc pour la partie liste

        public int Id { get; set; }
        public string CardName { get; set; }
        public string Cost { get; set; }
        public string PS { get; set; }
        public bool Premium { get; set; }
        public string Description { get; set; }

        public int EditionId { get; set; }
        public string EditionName { get; set; }
        public int RarityId { get; set; }
        public string RarityName { get; set; }
        public int TypeCardId { get; set; }
        public string TypeCardName { get; set; }
        public int SousTypeCardId { get; set; }
        public string SousTypeCardName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
