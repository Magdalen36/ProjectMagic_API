using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Models
{
    public class CollectionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public int NbCard { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardName { get; set; }
        public string EditionName { get; set; }
        public string ColorName { get; set; }

        public int EditionId { get; set; }
        public int ColorId { get; set; }
    }
}
