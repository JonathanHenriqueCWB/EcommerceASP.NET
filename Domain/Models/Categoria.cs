using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        #region CategoriaId
        [Key]
        public int CategoriaId { get; set; }
        #endregion
        #region Nome
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        #endregion
    }
}
