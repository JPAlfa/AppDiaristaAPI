using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppDiarista.Data.Models
{
    [Table("Endereco", Schema = "dbo")]
    public partial class Endereco
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [Required]
        [StringLength(150)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        [Required]
        [StringLength(8)]
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }
}
