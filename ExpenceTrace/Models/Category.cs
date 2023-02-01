using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Expence_Treace.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Category Name", TypeName = "Varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string? Description { get; set; }

        public DateTime? AddDate { get; set; }

        public virtual ICollection<Category>? Categories { get;set; }
    }
}
