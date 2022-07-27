using System;

namespace Task2
{
    internal interface IMoneyHolder<out Co, in Counter>
        //where AccountType : MoneyHolder
    {
        Co GetAccount { get; }
        public string Type { get; }

        void ReceiveMoney<AmountType>(AmountType? amount);
        void SetBalance<AmountType>(AmountType? amount);
        void SendMoney<AccountType, AmountType>(AccountType receiver, AmountType amount)
                    where AccountType : IMoneyHolder<Account, Account>;

    }

    abstract class MoneyHolder
    {
        public MoneyHolder()
        {
            Balance = 0;
        }
        public MoneyHolder(double startBalance)
        {
            this.Balance = startBalance;
        }
        public double Balance { get; set; }
    }
}
