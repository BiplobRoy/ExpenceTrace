using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expence_Treace.Models
{
    public class User
    {
        [Key]
        [Column("User Id")]
        public int Id { get; set; }


        [Required]
        [Column("User Name", TypeName = "Varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column("Email", TypeName = "Varchar(100)")]
        public string Email { get; set; }
        

        [Required]
        public string Password { get; set; }


        [Column("Joining Date")]
        public DateTime JoinDate { get; set; }

        public virtual ICollection<User>? Users { get; set;}
    }
}
