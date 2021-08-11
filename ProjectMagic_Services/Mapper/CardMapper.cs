using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class CardMapper
    {
        internal static CardModel Convert(IDataReader reader)
        {
            return new CardModel 
            { 
                Id = (int)reader["Id"],
                CardName = reader["CardName"].ToString(),
                Cost = reader["Cost"].ToString(),
                PS = reader["PS"].ToString(),
                Premium = (bool)reader["Premium"],
                Description = reader["Description"].ToString(),
                EditionId = (int)reader["EditionId"],
                RarityId = (int)reader["RarityId"],
                TypeCardId = (int)reader["TypeCardId"],
                SousTypeCardId = (int)reader["SousTypeCardId"],
                ColorId = (int)reader["ColorId"],
                EditionName = reader["EditionName"].ToString(),
                RarityName = reader["RarityName"].ToString(),
                TypeCardName = reader["TypeCardName"].ToString(),
                SousTypeCardName = reader["SousTypeCardName"].ToString(),
                ColorName = reader["ColorName"].ToString()
            };
        }
    }
}
