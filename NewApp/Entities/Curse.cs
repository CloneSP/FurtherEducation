using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.Entities
{
    internal class Curse
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int DaysDuration {  get; set; }
        public int Cost { get; set; }
    }
}
