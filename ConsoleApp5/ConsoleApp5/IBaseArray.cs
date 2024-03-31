using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IBaseArray
    {
        void UserCreate();
        void RndCreate();
        decimal Average();

        void Change();
    }
}
