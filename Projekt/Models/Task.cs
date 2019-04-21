using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł notatki")]
        public string Title { get; set; }

        [Display(Name = "Treść")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Data zakonczenia")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Czy wykonano")]
        public bool IsDone { get; set; }

        [Display(Name ="Stopień pilnosci")]
        public int Priority { get; set; }

        public virtual ICollection<Step> Steps { get; set; }
        public virtual Category category { get; set; }
    }
}
