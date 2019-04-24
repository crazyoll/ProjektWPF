using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Czy wykonano")]
        public bool IsDone { get; set; }

        [Display(Name = "Opis")]
        [Required]
        public string Description { get; set; }


        public virtual Task task { get; set; }
    }
}
