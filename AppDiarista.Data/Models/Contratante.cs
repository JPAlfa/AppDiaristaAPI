using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDiarista.Data.Models
{
    [Table("Contratante", Schema = "dbo")]
    public partial class Contratante
    {        
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(64)]
        public string Senha { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }
        [Required]
        public int IdEndereco { get; set; }
    }
}
