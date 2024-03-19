using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewApp.Entities
{
    internal class Curse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public int DaysDuration {  get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
