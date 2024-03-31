using _3_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    abstract class ArrayBase : IBaseArray, IPrinter
    {
        protected int n;

        public ArrayBase(int n)
        {
            this.n = n;
        }


        public abstract void UserCreate();
        public abstract void RndCreate();


        public abstract decimal Average();

        public abstract void Print();

        public abstract void Change();
    }
}
