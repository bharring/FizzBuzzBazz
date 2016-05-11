using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBazz
{
    interface IFizzleBizzle
    {
        int Fizz { set; }
        int Buzz { set; }

        /// <summary>
        /// FizzBuzz generates an array of strings representing the consecutive sequence of
        /// integers from start to end. When the integer is a multiple of Fizz, the string
        /// "Fizz" is added instead. Likewise, for multiples of Buzz, "Buzz" is added. For
        /// multiples of both Fizz and Buzz, "FizzBuzz" is added.
        /// (e.g. With Fizz = 3, Buzz = 5, start = 1, and end = 15; the array looks like:
        /// ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", ... , "14", "FizzBuzz"])
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        string[] FizzBuzz(int start, int end);

        /// <summary>
        /// FizzBuzzBazz returns the same result as FizzBuzz, except that instances of "FizzBuzz"
        /// are "FizzBuzzBazz" where the Predicate bazz is true.
        /// (e.g. With Fizz = 2, Buzz = 3, start = 1, end = 15, bazz = (x => x > 6); the array
        /// looks like ["1", "Fizz", "Buzz", "Fizz", "5", "FizzBuzz", "7", "Fizz", "Buzz", "Fizz",
        /// "11", "FizzBuzzBazz", "13", "Fizz", "Buzz"])
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bazz"></param>
        /// <returns></returns>
        string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz);
    }

    public class StringMod
    {
        public string Name;
        public Predicate<int> Pred;
    }
    public class FizzleBizzle : IFizzleBizzle
    {
        public int Fizz { get; set; }
        public int Buzz { get; set; }
        private readonly List<StringMod> _list;

        public FizzleBizzle()
        {
            _list = new List<StringMod>
            {
                new StringMod {Name = "Fizz", Pred = i => i%Fizz == 0},
                new StringMod {Name = "Buzz", Pred = i => i%Buzz == 0},
            };
        }

        private string FbHelper(int i, List<StringMod> list)
        {
            var s = string.Empty;

            list.ForEach(x => { if (x.Pred(i)) s += x.Name; });

            if (s == string.Empty)
                s = i.ToString();
            return s;
        }
        public string[] FizzBuzz(int start, int end)
        {
            if (start >= end || start < 0 || end < 1)
                return new[] { "Invalid input" };

            return Enumerable.Range(start, end - start + 1).Select(i => FbHelper(i, _list)).ToArray();
        }

        public string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz)
        {
            if (start >= end || start < 0 || end < 1)
                return new[] { "Invalid input" };

            var list = new List<StringMod>();
            _list.ForEach(l => list.Add(l));
            list.Add(new StringMod { Name = "Bazz", Pred = i => _list.All(l => l.Pred(i)) && bazz(i) });

            return Enumerable.Range(start, end - start + 1).Select(i => FbHelper(i, list)).ToArray();
        }
    }
}
