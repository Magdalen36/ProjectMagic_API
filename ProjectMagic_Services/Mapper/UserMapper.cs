using ConnectionTool;
using ProjectMagic_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMagic_Services.Mapper
{
    internal static class UserMapper
    {
        internal static UserPublicModel Convert(IDataReader reader)
        {
            return new UserPublicModel
            {
                Id = (int)reader["Id"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                RoleId = (int)reader["RoleId"]
            };
        }
    }
}
