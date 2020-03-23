using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        #region EnderecoId
        [Key]
        public int EnderecoId { get; set; }
        #endregion
        #region Logadouro (Rua)
        [Display(Name ="Rua")]
        public string Logradouro { get; set; }
        #endregion
        #region CEP
        [Display(Name ="CEP")]
        public string Cep { get; set; }
        #endregion
        #region Bairro
        [Display(Name ="Bairro")]
        public string Bairro { get; set; }
        #endregion
        #region Localidade (Cidade)
        [Display(Name ="Cidade")]
        public string Localidade { get; set; }
        #endregion
        #region Uf (Estado)
        [Display(Name ="Estado")]
        public string Uf { get; set; }
        #endregion
    }
}
