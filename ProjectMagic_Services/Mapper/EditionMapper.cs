using ProjectMagic_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Mapper
{
    internal static class EditionMapper
    {
        internal static EditionModel Convert(IDataReader reader)
        {
            return new EditionModel
            {
                Id = (int)reader["Id"],
                NbMax = (int)reader["NbMax"],
                Name = reader["Name"].ToString()
            };
        }
    }
}
