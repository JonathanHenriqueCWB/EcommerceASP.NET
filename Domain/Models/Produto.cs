using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Produtos")]
    public class Produto
    {
        #region ProdutoId
        [Key]
        public int ProdutoId { get; set; }
        #endregion
        #region Name
        [Display(Name = "Nome do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        #endregion
        #region Quantidade
        [Display(Name = "Quantidade do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 1000, ErrorMessage = "Os valores devem estar entre 1 e 1000")]
        public int Quantidade { get; set; }
        #endregion
        #region Preço
        [Display(Name = "Preço do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Preco { get; set; }
        #endregion
        #region Imagem
        public string Imagem { get; set; }
        #endregion
        #region CriadoEm
        public DateTime CriadoEm { get; set; }
        #endregion

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        #region Construtor
        public Produto()
        {
            CriadoEm = DateTime.Now;
        }
        #endregion
    }
}
