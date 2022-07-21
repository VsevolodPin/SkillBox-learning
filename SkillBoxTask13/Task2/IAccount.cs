using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal interface IAccount
    {
        public void ReceiveMoney<T>(T amount);
    }
}
