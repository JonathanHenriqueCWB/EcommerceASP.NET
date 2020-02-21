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
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 1000, ErrorMessage = "Os valores devem estar entre 1 e 1000")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço do produto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Preco { get; set; }

        public Categoria Categoria { get; set; }
        public string Imagem { get; set; }
        public DateTime CriadoEm { get; set; }

        public Produto()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
