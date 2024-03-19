using System;
using System.Linq;
using System.Threading;
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
            Thread loading = new Thread(Loading);
            loading.Start();

            using (var context = new MyDbContext())
            {
                try
                {
                    var users = context.Users.ToList();
                    var curses = context.Curses.ToList();

                    foreach (var user in users)
                        Console.WriteLine(user.Name);

                    Console.WriteLine();
                    
                    foreach (var curse in curses)
                        Console.WriteLine(curse.Name);
                }
                catch (Exception)
                {
                    loading.Abort();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Произошла непредвиденная ошибка. ");

                    throw;
                }

            }

            loading.Abort();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Операция выполнена успешно. Нажмите любую клавишу чтобы закрыть программу...");

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
        static void Loading()
        {
            while (true)
            {
                Console.WriteLine('.');
                Thread.Sleep(1000);
            }
        }

    }
}


