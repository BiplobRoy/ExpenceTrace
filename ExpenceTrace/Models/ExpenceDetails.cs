using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Expence_Treace.Models
{
    public class ExpenceDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CategoryName")]
        public int CategoriesId { get; set; }

        public virtual Category CategoryName { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string Description { get; set; }

        public DateTime ExpencDate { get; set; }

        [Required]
        [ForeignKey("UserName")]
        public int UsersId { get; set; }

        public virtual User UserName { get; set; }
    }
}
