using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Display(Name ="Rua")]
        public string Logradouro { get; set; }

        [Display(Name ="CEP")]
        public string Cep { get; set; }

        [Display(Name ="Bairro")]
        public string Bairro { get; set; }

        [Display(Name ="Cidade")]
        public string Localidade { get; set; }

        [Display(Name ="Estado")]
        public string Uf { get; set; }
    }
}
