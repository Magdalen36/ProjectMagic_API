using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class CollectionMapper
    {
        internal static CollectionModel Convert(IDataReader reader) 
        {
            return new CollectionModel
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                CardId = (int)reader["CardId"],
                NbCard = (int)reader["NbCard"]
            };
        }

        internal static CollectionViewModel ConvertView(IDataReader reader)
        {
            return new CollectionViewModel
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                CardId = (int)reader["CardId"],
                NbCard = (int)reader["NbCard"],
                EditionId = (int)reader["EditionId"],
                ColorId = (int)reader["ColorId"],
                CardName = reader["CardName"].ToString(),
                EditionName = reader["EditionName"].ToString(),
                ColorName = reader["ColorName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString()
            };
        }
    }
}
