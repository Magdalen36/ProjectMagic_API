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
    public class DeckService : RepositoryBase, IService<DeckModel>
    {
        public DeckService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Deck WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<DeckModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM DeckView", false);
            return _connection.ExecuteReader(cmd, DeckMapper.Convert);
        }

        public IEnumerable<DeckModel> GetAllByUserId(int userId)
        {
            Command cmd = new Command("SELECT * FROM[DeckView] WHERE[UserId] = @id", false);
            cmd.AddParameters("Id", userId);
            return _connection.ExecuteReader(cmd, DeckMapper.Convert);
        }

        public DeckModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[DeckView] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, DeckMapper.Convert).FirstOrDefault();
        }

        public int Insert(DeckModel entity)
        {
            Command cmd = new Command("INSERT INTO Deck (Name, UserId, ColorId) output inserted.id VALUES (@Name, @UserId, @ColorId)", false);
            cmd.AddParameters("UserId", entity.UserId);
            cmd.AddParameters("Name", entity.DeckName);
            cmd.AddParameters("ColorId", entity.ColorId);
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(DeckModel entity, int id)
        {
            Command cmd = new Command("UPDATE Deck Set UserId=@UserId, Name=@Name, ColorId=@ColorId WHERE id=@id", false);
            cmd.AddParameters("UserId", entity.UserId);
            cmd.AddParameters("Name", entity.DeckName);
            cmd.AddParameters("ColorId", entity.ColorId);
            cmd.AddParameters("id", id);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
