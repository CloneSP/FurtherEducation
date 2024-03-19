using System;
using System.Linq;

namespace NewApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.WriteLine("Подождите пожалуйста, операция выполняется...");

            /*
             using - метод, который закрывает коннект с БД после работы с ним, вызывая context.Dispose().
             
             */
            try
            {
                using (var context = new MyDbContext())
                {
                    var users = context.Users.ToList();
                    var curses = context.Curses.ToList();

                    foreach (var user in users)
                        Console.WriteLine(user.Name);

                    Console.WriteLine();

                    foreach (var curse in curses)
                        Console.WriteLine(curse.Name);
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла непредвиденная ошибка. ");
                throw;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Операция выполнена успешно. ");

            Console.ForegroundColor = defaultColor;
            Console.ReadKey();
            //Console.ReadKey();
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


