using System;

namespace Task2
{

    internal class Account : MoneyHolder
    {
        public Account()
        {
            Balance = 0;
        }
        public Account(double startBalance)
        {
            Balance = startBalance;
        }
        public void SetBalance<AmountType>(AmountType amount)
        {
            Balance = Convert.ToDouble(amount);
        }
        public void ReceiveMoney<AmountType>(AmountType amount)
        {
            Balance += Convert.ToDouble(amount);
            SetBalance(Balance);
        }
        public void SendMoney<AmountType>(Account receiver, AmountType amount)
        {
            try
            {
                Balance -= Convert.ToDouble(amount);
                SetBalance(Balance);
                receiver.ReceiveMoney(amount);
            }
            catch
            {
                throw new Exception("Что-то пошло не так, транзакция не завершена.");
            }
        }
    }

    internal class DebitAccount : IMoneyHolder<Account, Account>
    {
        public string Type { get; }
        public double Balance { get; set; }
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
        Account IMoneyHolder<Account, Account>.GetAccount => new Account(Balance);
        public void SetBalance<AmountType>(AmountType amount)
        {
            Balance = Convert.ToDouble(amount);
        }
        public void ReceiveMoney<AmountType>(AmountType amount)
        {
            Balance += Convert.ToDouble(amount);
        }
        public void SendMoney<AccountType, AmountType>(AccountType receiver, AmountType amount)
                    where AccountType : IMoneyHolder<Account, Account>
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

    internal class CreditAccount : IMoneyHolder<Account, Account>
    {
        public string Type { get; }
        public double Balance { get; set; }
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
        Account IMoneyHolder<Account, Account>.GetAccount => new Account(Balance);
        public void SetBalance<AmountType>(AmountType amount)
        {
            Balance = Convert.ToDouble(amount);
        }
        public void ReceiveMoney<AmountType>(AmountType amount)
        {
            Balance += Convert.ToDouble(amount);
        }
        public void SendMoney<AccountType, AmountType>(AccountType receiver, AmountType amount)
            where AccountType : IMoneyHolder<Account, Account>
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
}
