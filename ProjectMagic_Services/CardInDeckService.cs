using ConnectionTool;
using Microsoft.Extensions.Configuration;
using ProjectMagic_Models;
using ProjectMagic_Services.Base;
using ProjectMagic_Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMagic_Services
{
    public class CardInDeckService : RepositoryBase, IService<CardInDeckModel>
    {
        public CardInDeckService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM CardInDeck WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<CardInDeckViewModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM CardDeckView", false);
            return _connection.ExecuteReader(cmd, CardInDeckMapper.ConvertView);
        }

        public IEnumerable<CardInDeckViewModel> GetAllByDeckId(int deckId)
        {
            Command cmd = new Command("SELECT * FROM[CardDeckView] WHERE[DeckId] = @id", false);
            cmd.AddParameters("Id", deckId);
            return _connection.ExecuteReader(cmd, CardInDeckMapper.ConvertView);
        }

        public CardInDeckModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[CardInDeck] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, CardInDeckMapper.Convert).FirstOrDefault();
        }

        public int Insert(CardInDeckModel entity)
        {
            Command cmd = new Command("INSERT INTO CardInDeck (DeckId, CardId, NbCard) output inserted.id VALUES (@deckId, @cardId, @nbCard)", false);
            cmd.AddParameters("deckId", entity.DeckId);
            cmd.AddParameters("cardId", entity.CardId);
            cmd.AddParameters("nbCard", entity.NbCard);
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(CardInDeckModel entity, int id)
        {
            Command cmd = new Command("UPDATE CardInDeck Set DeckId=@deckId, CardId=@cardId, NbCard=@nbCard WHERE id=@id", false);
            cmd.AddParameters("deckId", entity.DeckId);
            cmd.AddParameters("cardId", entity.CardId);
            cmd.AddParameters("nbCard", entity.NbCard);
            cmd.AddParameters("id", id);
            _connection.ExecuteNonQuery(cmd);
        }

        IEnumerable<CardInDeckModel> IService<CardInDeckModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
