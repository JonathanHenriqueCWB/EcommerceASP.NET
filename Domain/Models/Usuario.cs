using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        #region UsuarioId
        [Key]
        public int UsuarioId { get; set; }
        #endregion
        #region Email
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        #endregion
        #region Senha
        [Display(Name ="Senha")]
        public string Senha { get; set; }

        [NotMapped]
        [Display(Name ="Comfirma senha")]
        [Compare("Senha" , ErrorMessage ="Os campos não coincidem!")]
        public string ConfirmaSenha { get; set; }
        #endregion
        #region CriadoEm
        public DateTime CriadoEm { get; set; }
        #endregion

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }        

        #region Construtor
        public Usuario()
        {
            CriadoEm = DateTime.Now;
            Endereco = new Endereco();
        }
        #endregion
    }
}
