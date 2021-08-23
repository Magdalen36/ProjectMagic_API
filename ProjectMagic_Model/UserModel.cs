using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "Datetime2")]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        //[Column(TypeName = "VARBINARY(64)")]
        public string Password { get; set; }
        
        [MaxLength(100)]
        public string Salt { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
