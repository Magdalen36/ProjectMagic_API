using ProjectMagic_Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMagic_Models;
using Microsoft.Extensions.Configuration;
using ConnectionTool;
using ProjectMagic_Services.Mapper;

namespace ProjectMagic_Services
{
    public class CardService : RepositoryBase, IService<CardModel>
    {
        public CardService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Card WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<CardModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM CardView", false);
            return _connection.ExecuteReader(cmd, CardMapper.Convert);
        }

        public IEnumerable<CardModel> GetRandom(int nbr)
        {
            Command cmd = new Command("SELECT TOP (@nbr) * FROM CardView ORDER BY NEWID()", false);
            cmd.AddParameters("nbr", nbr);
            return _connection.ExecuteReader(cmd, CardMapper.Convert);
        }

        public CardModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[CardView] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, CardMapper.Convert).FirstOrDefault();
        }


        public int Insert(CardModel entity)
        {
            Command cmd = new Command("INSERT INTO Card (name, cost, PS, Premium, Description, EditionId, RarityId, TypeCardId, SousTypeCardId, ColorId) " +
                "output inserted.id VALUES (@name, @cost, @PS, @Premium, @Description, @EditionId, @RarityId, @TypeCardId, @SousTypeCardId, @ColorId)", false);
            cmd.AddParameters("name", entity.CardName);
            cmd.AddParameters("cost", entity.Cost);
            cmd.AddParameters("PS", entity.PS);
            cmd.AddParameters("Premium", entity.Premium);
            cmd.AddParameters("Description", entity.Description);
            cmd.AddParameters("EditionId", entity.EditionId);
            cmd.AddParameters("RarityId", entity.RarityId);
            cmd.AddParameters("TypeCardId", entity.TypeCardId);
            cmd.AddParameters("SousTypeCardId", entity.SousTypeCardId);
            cmd.AddParameters("ColorId", entity.ColorId);
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(CardModel entity, int id)
        {
            Command cmd = new Command("UPDATE Card Set name=@name, cost=@cost, PS=@PS, Premium=@premium, Description=@description, EditionId=@EditionId, RarityId=@RarityId, TypeCardId=@TypeCardId, SousTypeCardId=@SousTypeCardId, ColorId=@ColorId WHERE id=@id", false);
            cmd.AddParameters("id", entity.Id);
            cmd.AddParameters("name", entity.CardName);
            cmd.AddParameters("cost", entity.Cost);
            cmd.AddParameters("PS", entity.PS);
            cmd.AddParameters("Premium", entity.Premium);
            cmd.AddParameters("Description", entity.Description);
            cmd.AddParameters("EditionId", entity.EditionId);
            cmd.AddParameters("RarityId", entity.RarityId);
            cmd.AddParameters("TypeCardId", entity.TypeCardId);
            cmd.AddParameters("SousTypeCardId", entity.SousTypeCardId);
            cmd.AddParameters("ColorId", entity.ColorId);
            _connection.ExecuteScalar(cmd);
        }


        public IEnumerable<CardModel> SearchByName(string name)
        {
            Command cmd = new Command("SELECT * FROM CardView WHERE[cardname] LIKE @cardname ORDER BY [cardname]", false);
            cmd.AddParameters("cardname", "%" + name + "%");
            return _connection.ExecuteReader(cmd, CardMapper.Convert);
        }

        public IEnumerable<CardModel> SearchByColor(int color)
        {
            Command cmd = new Command("SELECT * FROM CardView WHERE[colorId] = @colorId ORDER BY [cardname]", false);
            cmd.AddParameters("colorId", color);
            return _connection.ExecuteReader(cmd, CardMapper.Convert);
        }


        public IEnumerable<CardModel> SearchByEditionId(int id)
        {
            Command cmd = new Command("SELECT * FROM[CardView] WHERE[EditionId] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, CardMapper.Convert);
        }
    }
}
