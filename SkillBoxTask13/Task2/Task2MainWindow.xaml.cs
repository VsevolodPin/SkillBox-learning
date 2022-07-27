using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


/// В этом проекте реализованы задания 2 и 3 в виде одновременно ковариантного и контрвариантного интерфейса IMoneyHolder


namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Task2MainWindow : Window
    {
        List<Client> clientsList;

        public Task2MainWindow()
        {
            InitializeComponent();

            // Загрузка базы данных
            clientsList = new List<Client>();
            if (File.Exists("Clients DataBase.DB"))
            {
                using (StreamReader sr = new StreamReader("Clients DataBase.DB"))
                {
                    //string json = sr.ReadToEnd();
                    //clientsList = JsonConvert.DeserializeObject<List<Client>>(json);
                    string data = sr.ReadToEnd();
                    clientsList = Deserialize(data);
                }
            }
            RefreshComboBoxes();
        }

        private void RefreshComboBoxes()
        {
            Client1CB.Items.Clear();
            Client2CB.Items.Clear();
            ClientForNewAcc.Items.Clear();
            Balance1TB.Text = "";
            Balance2TB.Text = "";
            TakeOffTB.Text = "";
            ReceiveTB.Text = "";

            foreach (Client client in clientsList)
            {
                Client1CB.Items.Add(client.FullName);
                Client2CB.Items.Add(client.FullName);
                ClientForNewAcc.Items.Add(client.FullName);
            }
        }

        #region Обработка кнопок
        private void CloseAccBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int clientIdx = Client1CB.SelectedIndex;
                int accIdx;
                try
                {
                    accIdx = Client1AccCB.SelectedIndex;
                }
                catch (IndexOutOfRangeException)
                {
                    accIdx = -1;
                }

                if (clientsList[clientIdx].CloseAccount(accIdx))
                {
                    if (clientsList[clientIdx].Accounts.Count == 0)
                    {
                        clientsList.RemoveAt(clientIdx);
                    }
                }
                RefreshComboBoxes();
            }
            catch
            {
                // do nothing...
            }
        }
        private void OpenAccBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DebitAccRB.IsChecked == true)
                {
                    clientsList[ClientForNewAcc.SelectedIndex].AddAccount(new DebitAccount(double.Parse(StartBalanceForNewAccTB.Text)));
                }
                else
                {
                    clientsList[ClientForNewAcc.SelectedIndex].AddAccount(new CreditAccount(double.Parse(StartBalanceForNewAccTB.Text)));
                }
                RefreshComboBoxes();
            }
            catch
            {
                // do nothing...
            }
        }
        private void CreateBT_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client(FullNameTB.Text);
            client.AddAccount(new DebitAccount(double.Parse(StartBalanceTB.Text)));
            clientsList.Add(client);
            RefreshComboBoxes();
        }
        private void TransactionBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idxAcc1 = Client1AccCB.SelectedIndex, idxClient1 = Client1CB.SelectedIndex;
                int idxAcc2 = Client2AccCB.SelectedIndex, idxClient2 = Client2CB.SelectedIndex;

                clientsList[idxClient1].Accounts[idxAcc1].SendMoney(clientsList[idxClient2].Accounts[idxAcc2], double.Parse(TakeOffTB.Text));
                Balance1TB.Text = clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].Balance.ToString();
                Balance2TB.Text = clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex].Balance.ToString();
            }
            catch
            {
                // do nothing...
            }
        }
        private void SaveBT_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Clients DataBase.DB"))
            {
                //string json = JsonConvert.SerializeObject(clientsList);
                //sw.Write(json);
                string data = Serialize(clientsList);
                sw.Write(data);
            }
        }
        #endregion

        #region Обработка событий
        private void Client1CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int debitAccIdx = 0, creditAccIdx = 0;
                Client1AccCB.Items.Clear();
                for (int i = 0; i < clientsList[Client1CB.SelectedIndex].Accounts.Count; i++)
                {
                    if (clientsList[Client1CB.SelectedIndex].Accounts[i].Type == "Депозитный")
                    {
                        Client1AccCB.Items.Add($"{clientsList[Client1CB.SelectedIndex].Accounts[i].Type} счет #{debitAccIdx + 1}");
                        debitAccIdx++;
                    }
                    else
                    {
                        Client1AccCB.Items.Add($"{clientsList[Client1CB.SelectedIndex].Accounts[i].Type} счет #{creditAccIdx + 1}");
                        creditAccIdx++;
                    }
                }
            }
            catch
            {

            }
        }
        private void Client2CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int debitAccIdx = 0, creditAccIdx = 0;
                Client2AccCB.Items.Clear();
                for (int i = 0; i < clientsList[Client2CB.SelectedIndex].Accounts.Count; i++)
                {
                    if (clientsList[Client2CB.SelectedIndex].Accounts[i].Type == "Депозитный")
                    {
                        Client2AccCB.Items.Add($"{clientsList[Client2CB.SelectedIndex].Accounts[i].Type} счет #{debitAccIdx + 1}");
                        debitAccIdx++;
                    }
                    else
                    {
                        Client2AccCB.Items.Add($"{clientsList[Client2CB.SelectedIndex].Accounts[i].Type} счет #{creditAccIdx + 1}");
                        creditAccIdx++;
                    }
                }
            }
            catch
            {

            }
        }
        private void Client1AccCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Balance1TB.Text = clientsList[Client1CB.SelectedIndex].Accounts[Client1AccCB.SelectedIndex].GetAccount.Balance.ToString();
            }
            catch
            {

            }
        }
        private void Client2AccCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Balance2TB.Text = clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex].Balance.ToString();
            }
            catch
            {

            }
        }
        private void TakeOffTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReceiveTB.Text = TakeOffTB.Text;
        }
        #endregion

        #region Работа с сохранением и загрузкой
        private string Serialize(List<Client> list)
        {
            char sep = '|';
            string to_return = "";
            to_return += list.Count.ToString() + sep;
            for (int i = 0; i < list.Count; i++)
            {
                to_return += list[i].FullName + sep;
                to_return += list[i].Accounts.Count.ToString() + sep;
                for (int j = 0; j < list[i].Accounts.Count; j++)
                {
                    to_return += list[i].Accounts[j].Type + sep + list[i].Accounts[j].GetAccount.Balance.ToString() + sep;
                }
            }
            return to_return;
        }
        private List<Client> Deserialize(string line)
        {
            List<Client> to_return = new List<Client>();
            int p = 0;
            var lines = line.Split('|');
            int clientsCount = int.Parse(lines[p]);
            p++;
            for (int i = 0; i < clientsCount; i++)
            {
                string name = lines[p];
                p++;

                Client client = new Client(name);
                int accountsCount = int.Parse(lines[p]);
                p++;

                for (int j = 0; j < accountsCount; j++)
                {
                    if (lines[p] == "Депозитный")
                    {
                        client.AddAccount(new DebitAccount(double.Parse(lines[p + 1])));
                    }
                    else
                    {
                        client.AddAccount(new CreditAccount(double.Parse(lines[p + 1])));
                    }
                    p += 2;
                }
                to_return.Add(client);
            }
            return to_return;
        }
        #endregion
    }
}
