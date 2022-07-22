using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal interface IAccount<in AmountType>
    {
        public AmountType Balance { set; }
        public void ReceiveMoney<AmountType>(AmountType amount);
        public void SetBalance<AmountType>(AmountType amount);
    }
}
