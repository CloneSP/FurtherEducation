using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NewApp.Entities
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public int BornAge { get; set; }

        //Один ко многим со сторонны класса:
        //При этом невозможет Null.
        public int ClassId { get; set; }

        /*или так
         * public Class Class { get; set; }
         * При этом возможен Null
         */

    }
    }
