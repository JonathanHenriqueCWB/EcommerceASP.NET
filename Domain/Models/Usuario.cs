using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
            Endereco = new Endereco();
        }

        [Key]
        public int UsuarioId { get; set; }

        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Display(Name ="Senha")]
        public string Senha { get; set; }

        [NotMapped]
        [Display(Name ="Comfirma senha")]
        [Compare("Senha" , ErrorMessage ="Os campos não coincidem!")]
        public string ConfirmaSenha { get; set; }

        public Endereco Endereco { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
