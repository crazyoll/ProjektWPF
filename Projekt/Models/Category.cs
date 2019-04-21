using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa kategori")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}
