using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Client
    {
        public DebitAccount debitAccount;
        public CreditAccount creditAccount;
        public string FullName;

        public double Balance
        {
            get => debitAccount.Balance;
        }

        public Client()
        {
            FullName = "Аноним";
            debitAccount = new DebitAccount();
        }
        public Client(string fullName, double debitStartBalance, double creditStartBalance)
        {
            this.FullName = fullName;
            debitAccount = new DebitAccount(debitStartBalance);
            creditAccount = new CreditAccount(creditStartBalance);
        }

        //public void AddAccount<T>(T startBalance = default(T))
        //{
        //    Accounts.Add(new Account(Convert.ToDouble(startBalance)));
        //}
        //public void CloseAccount(int accountNumber = -1)
        //{
        //    if (Accounts.Count == 0) throw new Exception("У клиента нет ни одного действующего счета");
        //    else
        //    {
        //        // Сценарий удаления последнего открытого счета 
        //        if (accountNumber == -1)
        //        {
        //            //Если счет всего один, то удаление возможно только когда на счету нет ни денег, ни задолженности
        //            if (Accounts.Count == 1)
        //            {
        //                if (Accounts.Last().Balance < 0) throw new Exception("Нельзя закрыть счет с отрицательным балансом.");
        //                if (Accounts.Last().Balance > 0) throw new Exception("Нельзя закрыть счет с ненулевым балансом. Возможна потеря средств.");
        //                if (Accounts.Last().Balance == 0) { Accounts.Clear(); return; }
        //            }
        //            // Типичный сценарий - удаление последнего счета с переносом средств на первый
        //            else
        //            {
        //                double removedAccountBalance = Accounts.Last().Balance;
        //                Accounts.RemoveAt(Accounts.Count - 1);
        //                Accounts[0].ReceiveMoney(removedAccountBalance);
        //                return;
        //            }
        //        }
        //        // Сценарий удаления произвольного счета
        //        else
        //        {
        //            // Проверка на корректность
        //            if (accountNumber >= Accounts.Count || accountNumber < -1) throw new Exception("Индекс за пределами массива.");
        //            // Типичный сценарий
        //            else
        //            {
        //                double removedAccountBalance = Accounts[accountNumber].Balance;
        //                Accounts.RemoveAt(accountNumber);
        //                Accounts[0].ReceiveMoney(removedAccountBalance);
        //                return;
        //            }
        //        }
        //    }
        //}
    }
}
