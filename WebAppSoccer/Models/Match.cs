
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppSoccer.Models
{
    public class Match
    {
        public int Id { get; set; }
        [Display (Name ="Date")]
        public DateTime DateM { get; set; }
        [Display(Name = "Buts Locale")]
        public int ButL { get; set; }
        [Display(Name = "Buts Visiteuses")]
        public int ButV { get; set;}
        [ForeignKey("ClubL")]
        [Display(Name = "Club Local")]
        public int ClubIdL { get; set; }
        [ForeignKey("ClubV")]
        [Display(Name = "Club Visiteur ")]
        public int ClubIdV { get; set; }

        public virtual ICollection<Participer>? Participers { get; set; }
        public virtual Club? ClubL { get; set; }
        public virtual Club? ClubV { get; set; }
    }
}
