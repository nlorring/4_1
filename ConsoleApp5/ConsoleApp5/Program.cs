using ConsoleApp5;
using System.Data.SqlTypes;
using System.Globalization;

namespace _3_4
{

    internal class Program
    {

        static void Main(string[] args)
        {
            OneDimArray<int> a = new OneDimArray<int>();
            a.Add(228);
            a.Add(120);
            a.Add(69);

            a.Sort();

            a.MaxValue();
            a.MinValue();

            OneDimArray<bool> b = new OneDimArray<bool>();
            b.Add(true);
            b.Add(false);


            b.Sort();

            b.MaxValue();
            b.MinValue();



        }
    }
}