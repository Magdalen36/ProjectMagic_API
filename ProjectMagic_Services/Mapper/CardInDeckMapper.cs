using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class CardInDeckMapper
    {
        internal static CardInDeckModel Convert(IDataReader reader)
        {
            return new CardInDeckModel
            {
                Id = (int)reader["Id"],
                DeckId = (int)reader["DeckId"],
                CardId = (int)reader["CardId"],
                NbCard = (int)reader["NbCard"]
            };
        }

        internal static CardInDeckViewModel ConvertView(IDataReader reader)
        {
            return new CardInDeckViewModel
            {
                Id = (int)reader["Id"],
                DeckId = (int)reader["DeckId"],
                CardId = (int)reader["CardId"],
                NbCard = (int)reader["NbCard"],

                UserId = (int)reader["UserId"],
                ColorId = (int)reader["ColorId"],
                RarityId = (int)reader["RarityId"],
                TypeId = (int)reader["TypeCardId"],
                SousTypeId = (int)reader["SousTypeCardId"],

                DeckName=reader["DeckName"].ToString(),
                FirstName=reader["FirstName"].ToString(),
                LastName=reader["LastName"].ToString(),

                CardName=reader["CardName"].ToString(),
                Cost=reader["Cost"].ToString(),
                Description=reader["Description"].ToString(),
                PS=reader["PS"].ToString(),

                ColorName=reader["ColorName"].ToString(),
                RarityName=reader["RarityName"].ToString(),
                TypeName=reader["TypeName"].ToString(),
                SousTypeName=reader["SousTypeName"].ToString(),

            };
        }
    }
}
