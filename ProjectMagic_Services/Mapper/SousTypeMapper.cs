using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class SousTypeMapper
    {
        internal static SousTypeModel Convert(IDataReader reader)
        {
            return new SousTypeModel
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }
    }
}
