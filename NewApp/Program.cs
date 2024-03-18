using NewApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
             using - метод, который закрывает коннект с БД после работы с ним, вызывая context.Dispose().
             
             */
            using (var context = new MyDbContext())
            {
                var users = context.Users.ToList();
                var curses = context.Curses.ToList();

                foreach (var user in users)
                    Console.WriteLine(user.Name);

                Console.WriteLine();

                foreach (var curse in curses)
                    Console.WriteLine(curse.Name);

                Console.ReadKey();
            }
            //Можно так:
            // Но скорость очистки context будет медленнее чем с using

            /*var context = new MyDbContext();

            var entities = context.Users.ToList();

            foreach (var entity in entities)
            {
                Console.WriteLine(entity.Name);

            }
            context.Dispose();
            */
        }
    }
}


