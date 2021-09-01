using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class DeckMapper
    {
        internal static DeckModel Convert(IDataReader reader)
        {
            return new DeckModel
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                DeckName = reader["DeckName"].ToString(),
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                ColorId = (int)reader["ColorId"],
                ColorName = reader["ColorName"].ToString()
            };
        }
    }
}
