using ProjectMagic_Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMagic_Models;
using Microsoft.Extensions.Configuration;

namespace ProjectMagic_Services
{
    public class CardService : RepositoryBase, IService<CardModel>
    {
        public CardService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CardModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CardModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CardModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
