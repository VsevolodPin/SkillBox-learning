using System;

namespace Task1
{
    public class Account
    {
        public double Balance;
        public Account ()
        {
            Balance = 0;
        }
        public Account(double startBalance)
        {
            Balance = startBalance;
        }
        public void SendMoney<T>(Account receiver, T amount)
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
        public void ReceiveMoney<T>(T amount)
        {
            Balance += Convert.ToDouble(amount);
        }
    }
}
