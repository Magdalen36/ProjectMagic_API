using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class RarityMapper
    {
        internal static RarityModel Convert(IDataReader reader)
        {
            return new RarityModel
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }
    }
}
