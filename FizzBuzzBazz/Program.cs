using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBazz
{
    class Program
    {
        static void Main(string[] args)
        {
            var fb = new FizzleBizzle
            {
                Fizz = 3,
                Buzz = 5
            };
            fb.FizzBuzz(1, 15).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("========");
            fb.FizzBuzzBazz(1, 15, x => x > 6).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("========");
            fb.Fizz = 2;
            fb.Buzz = 3;
            fb.FizzBuzzBazz(1, 15, x => x > 6).ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
