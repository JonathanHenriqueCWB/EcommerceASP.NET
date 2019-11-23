using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Produtos")]
    public class Produto
    {
        #region ID
        [Key]
        public int Id { get; set; }
        #endregion
        #region Nome
        [Display(Name ="Nome do produto")]
        [Required(ErrorMessage ="Campo nome obrigatório!")]
        public string Nome { get; set; }
        #endregion
        #region Descrição
        [Display(Name ="Descrição do produto")]
        [Required(ErrorMessage ="Campor descrição obrigatório!")]
        [MinLength(5, ErrorMessage ="Mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage ="Máximo 100 caracteres")]
        public string  Descricao{ get; set; }
        #endregion
        #region Preço
        [Display(Name ="Preço do produto")]
        [Required(ErrorMessage ="Campor preço obrigatório!")]
        public double Preco { get; set; }
        #endregion
        #region Quantidade
        [Display(Name ="Quantidade do produto")]
        [Required(ErrorMessage ="Campor quantidade obrigatório")]
        [Range(1,100, ErrorMessage ="Mínimo 1 máximo 100 produtos")]
        public int Quantidade { get; set; }
        #endregion
        #region Categoria
        public Categoria Categoria { get; set; }
        #endregion
        #region Criado em
        public DateTime CriadoEm { get; set; }
        #endregion

        public Produto()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
