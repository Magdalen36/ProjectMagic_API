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
    public class SousTypeService : RepositoryBase, IService<SousTypeModel>
    {

        public SousTypeService(IConfiguration config) : base(config)
        {

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SousTypeModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM SousTypeCard", false);
            return _connection.ExecuteReader(cmd, SousTypeMapper.Convert);
        }

        public SousTypeModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[SousTypeCard] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, SousTypeMapper.Convert).FirstOrDefault();
        }

        public int Insert(SousTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SousTypeModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
