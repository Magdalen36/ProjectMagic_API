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
    public class ColorService : RepositoryBase, IService<ColorModel>
    {
        public ColorService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ColorModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Color", false);
            return _connection.ExecuteReader(cmd, ColorMapper.Convert);
        }

        public ColorModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[Color] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, ColorMapper.Convert).FirstOrDefault();
        }

        public int Insert(ColorModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ColorModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
