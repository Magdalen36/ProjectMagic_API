using ConnectionTool;
using Microsoft.Extensions.Configuration;
using ProjectMagic_Model;
using ProjectMagic_Services.Base;
using ProjectMagic_Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMagic_Services
{
    public class EditionService : RepositoryBase, IService<EditionModel>
    {
        public EditionService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Edition WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<EditionModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Edition", false);
            return _connection.ExecuteReader(cmd, EditionMapper.Convert);
        }

        public EditionModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[Edition] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, EditionMapper.Convert).FirstOrDefault();
        }

        public int Insert(EditionModel entity)
        {
            Command cmd = new Command("INSERT INTO Edition (nbMax, name) output inserted.id VALUES (@nbMax, @name)", false);
            cmd.AddParameters("nbMax", entity.NbMax);
            cmd.AddParameters("name", entity.Name);
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(EditionModel entity, int id)
        {
            Command cmd = new Command("UPDATE Edition Set nbMax=@nbMax, name=@name WHERE id=@id", false);
            cmd.AddParameters("nbMax", entity.NbMax);
            cmd.AddParameters("name", entity.Name);
            cmd.AddParameters("id", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<EditionModel> SearchByName(string name)
        {
            Command cmd = new Command("SELECT * FROM Edition WHERE[name] LIKE @name ORDER BY [name]", false);
            cmd.AddParameters("name", "%" + name + "%");
            return _connection.ExecuteReader(cmd, EditionMapper.Convert);
        }
    }
}
