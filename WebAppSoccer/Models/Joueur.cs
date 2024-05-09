using System.ComponentModel.DataAnnotations;

namespace WebAppSoccer.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string NomPrenom { get { return Nom + " "+ Prenom} }
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime DateN { get; set; }
        [Display(Name = "Numéro")]
        public int Num { get; set; }
        [Display(Name = "Club")]
        public int ClubId { get; set; }
        public virtual ICollection<Participer>?Participers { get; set; }

        public virtual Club ? Club { get; set; }


    }
}
