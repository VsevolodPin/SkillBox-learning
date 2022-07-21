using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Account : IAccount
    {
        public double Balance;
        public void ReceiveMoney<T>(T amount)
        {
            Balance += Convert.ToDouble(amount);
        }
        public void SendMoney<T>(IAccount receiver, T amount)
        {
            try
            {
                Balance -= Convert.ToDouble(amount);
                receiver.ReceiveMoney(amount);
            }
            catch
            {
                throw new Exception("Что-то пошло не так, транзакция не завершена.");
            }
        }
    }

    internal class DebitAccount : Account
    {
        public DebitAccount()
        {
            Balance = 0;
        }
        public DebitAccount(double startBalance)
        {
            Balance = startBalance;
        }
    }

    internal class CreditAccount : Account
    {
        public CreditAccount()
        {
            Balance = 0;
        }
        public CreditAccount(double startBalance)
        {
            Balance = startBalance;
        }
    }
}
