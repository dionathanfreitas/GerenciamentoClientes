using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoClientes.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("Id")]
        [Display(Name = "Código Cliente")]
        public int ClienteId { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "O item {0} é obrigatório!")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O campo {0} não é um endereço de e-mail válido.")]
        public string? Email { get; set; }

        [Column("DataNascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        public string? DataNascimento { get; set; }

        [Column("CEP")]
        [Required(ErrorMessage = "O item {0} é obrigatório!")]
        [Display(Name = "CEP")]
        public string? CEP { get; set; }
    }
}
