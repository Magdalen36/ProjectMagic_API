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
    public class CollectionService : RepositoryBase, IService<CollectionModel>
    {
        public CollectionService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Collection WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<CollectionModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Collection", false);
            return _connection.ExecuteReader(cmd, CollectionMapper.Convert);
        }

        public IEnumerable<CollectionViewModel> GetAllByUserId(int userId)
        {
            Command cmd = new Command("SELECT * FROM[CollectionView] WHERE[UserId] = @id", false);
            cmd.AddParameters("Id", userId);
            return _connection.ExecuteReader(cmd, CollectionMapper.ConvertView);
        }

        public CollectionModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[Collection] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, CollectionMapper.Convert).FirstOrDefault();
        }

        public int Insert(CollectionModel entity)
        {
            Command cmd = new Command("INSERT INTO Collection (UserId, CardId, NbCard) output inserted.id VALUES (@userId, @cardId, @nbCard)", false);
            cmd.AddParameters("userId", entity.UserId);
            cmd.AddParameters("cardId", entity.CardId);
            cmd.AddParameters("nbCard", entity.NbCard);
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(CollectionModel entity, int id)
        {
            Command cmd = new Command("UPDATE Collection Set UserId=@userId, CardId=@cardId, NbCard=@nbCard WHERE id=@id", false);
            cmd.AddParameters("userId", entity.UserId);
            cmd.AddParameters("cardId", entity.CardId);
            cmd.AddParameters("nbCard", entity.NbCard);
            cmd.AddParameters("id", id);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
