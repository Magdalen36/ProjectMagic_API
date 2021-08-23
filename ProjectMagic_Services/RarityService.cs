using ConnectionTool;
using Microsoft.Extensions.Configuration;
using ProjectMagic_Models;
using ProjectMagic_Services.Base;
using ProjectMagic_Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services
{
    public class RarityService : RepositoryBase, IService<RarityModel>
    {
        public RarityService(IConfiguration config) : base(config)
        {

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RarityModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Rarity", false);
            return _connection.ExecuteReader(cmd, RarityMapper.Convert);
        }

        public RarityModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[Rarity] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, RarityMapper.Convert).FirstOrDefault();
        }

        public int Insert(RarityModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RarityModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
