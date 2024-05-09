using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppSoccer.Models
{
    public class Club
    {
        public int Id { get; set; }
        [Display(Name = "Club ")]
        public string LibClub { get; set; }


        public string Description { get; set; }
        public virtual ICollection<Joueur>? Joueurs { get; set; }
        [InverseProperty("ClubL")]
        public virtual ICollection<Match>? MatchsL { get; set; }
        [InverseProperty("ClubV")]
        public virtual ICollection<Match>? MatchsV { get; set; }
    }

    }
