namespace Task2
{
    internal interface IAccount<out AmountType>
    {
        public AmountType Balance { get; }
        public void ReceiveMoney<AmountType>(AmountType amount);
        public void SetBalance<AmountType>(AmountType amount);
    }
}
