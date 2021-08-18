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
    public class UserService : RepositoryBase
    {

        //pas d'interface IService ici
        //incompatible avec le double profil (public et privé)

        public UserService(IConfiguration config): base(config)
        {

        }

        //Permet de passer d'un modele de user à l'autre pour l'affichage (pas d'affichage public de password)
        private Func<UserModel, UserPublicModel> mapping = (pro) =>
        {
            if (pro is null) return null;
            return new UserPublicModel
            {
                Id = pro.Id,
                FirstName = pro.FirstName,
                LastName = pro.LastName,
                BirthDate = pro.BirthDate,
                Email = pro.Email,
                Token = null,
                RoleId = pro.RoleId
            };
        };

        public UserPublicModel Check(string email, string password)
        {
            Command cmd = new Command("LoginUser", true);
            cmd.AddParameters("email", email);
            cmd.AddParameters("password", password);
            UserModel user = new UserModel();
            user = _connection.ExecuteReader(cmd, UserMapper.ConvertBack).FirstOrDefault();

            if (user == null) return null;
            else return mapping(user);
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM [User] WHERE Id=@Id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<UserPublicModel> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [User]", false);
            return _connection.ExecuteReader(cmd, UserMapper.Convert);
        }

        public UserPublicModel GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM[User] WHERE[Id] = @id", false);
            cmd.AddParameters("Id", id);
            return _connection.ExecuteReader(cmd, UserMapper.Convert).FirstOrDefault();
        }

        public int Insert(UserModel entity)
        {
            Command cmd = new Command("RegisterUser", true);
            cmd.AddParameters("firstname", entity.FirstName);
            cmd.AddParameters("lastname", entity.LastName);
            cmd.AddParameters("email", entity.Email);
            cmd.AddParameters("birthdate", entity.BirthDate);
            cmd.AddParameters("roleid", 2);
            cmd.AddParameters("password",entity.Password);
           
            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Update(UserModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
