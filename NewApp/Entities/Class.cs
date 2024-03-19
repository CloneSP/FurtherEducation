using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace NewApp.Entities
{
    internal class Class
    {
        //[Key]
        public int ClassId {  get; set; }
        //[Required]
        public string Name { get; set; }

        //public ICollection<User> Users { get; set; }

    }
}
