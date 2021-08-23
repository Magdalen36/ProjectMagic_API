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
    public class TypeService : RepositoryBase, IService<TypeModel>
    {

        public TypeService(IConfiguration config) : base(config)
        {

        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM TypeCard", false);
            return _connection.ExecuteReader(cmd, TypeMapper.Convert);
        }

        public TypeModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[TypeCard] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, TypeMapper.Convert).FirstOrDefault();
        }

        public int Insert(TypeModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
