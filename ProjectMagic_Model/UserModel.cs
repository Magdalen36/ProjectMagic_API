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
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARBINARY(50)")]
        public byte[] Password { get; set; }
        [Required]
        [Column(TypeName = "CHAR(36)")]
        public string Salt { get; set; }
        public int RoleId { get; set; }
    }
}
