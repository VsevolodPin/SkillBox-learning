using System;

namespace Task2
{
    internal class Account : IAccount
    {
        public double Balance;
        public string Type { get; set; }
        public Account()
        {
            Balance = 0;
        }
        public void SetBalance<AmountType>(AmountType amount)
        {
            Balance = Convert.ToDouble(amount);
        }
        public void ReceiveMoney<AmountType>(AmountType amount)
        {
            Balance += Convert.ToDouble(amount);
        }
        public void SendMoney<AccountType, AmountType>(AccountType receiver, AmountType amount)
            where AccountType : Account
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
            Type = "Депозитный";
        }
        public DebitAccount(double startBalance)
        {
            Balance = startBalance;
            Type = "Депозитный";
        }
    }

    internal class CreditAccount : Account
    {
        public CreditAccount()
        {
            Balance = 0;
            Type = "Кредитный";
        }
        public CreditAccount(double startBalance)
        {
            Balance = startBalance;
            Type = "Кредитный";
        }
    }
}
