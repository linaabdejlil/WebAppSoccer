using System.ComponentModel.DataAnnotations;

namespace WebAppSoccer.Models
{
    public class Participer
    {
        public int Id { get; set; }
        //creation d'un cle etranger
        [Display(Name = "Match")]
        public int MatchId { get; set; }
        [Display(Name = "Joueur")]
        public int JoueurId { get; set; }
        // ?= nullable / facultatif 
        public virtual Match? Match { get; set; }
        public virtual Joueur? Joueur  { get; set; }   
    }
}
