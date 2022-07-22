using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Client
    {
        #region Поля класса
        public List<Account> Accounts;
        public string FullName;
        public double Balance
        {
            get
            {
                double to_return = 0;
                foreach (var account in Accounts)
                {
                    to_return += account.Balance;
                }
                return to_return;
            }
        }
        public Account this[int index]
        {
            get => Accounts[index];
        }
        #endregion

        #region Конструкторы
        public Client()
        {
            FullName = "Аноним";
            Accounts = new List<Account>();
        }
        public Client(string fullName)
        {
            this.FullName = fullName;
            Accounts = new List<Account>();
        }
        #endregion

        #region Методы работы со счетами
        public void AddAccount<AccountType>(double startBalance = default(double))
            where AccountType : Account, new()
        {
            AccountType account = new AccountType();
            account.SetBalance(startBalance);
            Accounts.Add(account);
        }
        public void AddAccount<AccountType>(AccountType newAccount)
            where AccountType : Account
        {
            Accounts.Add(new Account());
            Accounts[Accounts.Count-1] = newAccount;
        }
        public bool CloseAccount(int accountNumber = -1)
        {
            if (Accounts.Count == 0) throw new Exception("У клиента нет ни одного действующего счета");
            else
            {
                // Сценарий удаления последнего открытого счета 
                if (accountNumber == -1)
                {
                    //Если счет всего один, то удаление возможно только когда на счету нет ни денег, ни задолженности
                    if (Accounts.Count == 1)
                    {
                        if (Accounts.Last().Balance < 0) throw new Exception("Нельзя закрыть счет с отрицательным балансом.");
                        if (Accounts.Last().Balance > 0) throw new Exception("Нельзя закрыть счет с ненулевым балансом. Возможна потеря средств.");
                        if (Accounts.Last().Balance == 0) { Accounts.Clear(); return true; }
                    }
                    // Типичный сценарий - удаление последнего счета с переносом средств на первый
                    else
                    {
                        double removedAccountBalance = Accounts.Last().Balance;
                        Accounts.RemoveAt(Accounts.Count - 1);
                        Accounts[0].ReceiveMoney(removedAccountBalance);
                        return true;
                    }
                }
                // Сценарий удаления произвольного счета
                else
                {
                    // Проверка на корректность
                    if (accountNumber >= Accounts.Count || accountNumber < -1) throw new Exception("Индекс за пределами массива.");
                    // Типичный сценарий
                    else
                    {
                        double removedAccountBalance = Accounts[accountNumber].Balance;
                        Accounts.RemoveAt(accountNumber);
                        Accounts[0].ReceiveMoney(removedAccountBalance);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
