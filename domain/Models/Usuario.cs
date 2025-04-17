using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuario.domain.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public required string Nome { get; set; }
        [MinLength(5)]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public required string Email { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public required string Cidade { get; set; }
        public bool Status { get; set; } = true;
    }
}