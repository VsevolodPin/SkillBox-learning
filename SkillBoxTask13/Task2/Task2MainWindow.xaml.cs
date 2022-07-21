using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
                    string json = sr.ReadToEnd();
                    clientsList = JsonConvert.DeserializeObject<List<Client>>(json);
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
                    clientsList[ClientForNewAcc.SelectedIndex].AddAccount<DebitAccount>(double.Parse(StartBalanceForNewAccTB.Text));
                }
                else
                {
                    clientsList[ClientForNewAcc.SelectedIndex].AddAccount<CreditAccount>(double.Parse(StartBalanceForNewAccTB.Text));

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
            client.AddAccount<DebitAccount>(double.Parse(StartBalanceTB.Text));
            clientsList.Add(client);
            RefreshComboBoxes();
        }
        private void TransactionBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].SendMoney(clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex], double.Parse(TakeOffTB.Text));
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
                string json = JsonConvert.SerializeObject(clientsList);
                sw.Write(json);
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
                Balance1TB.Text = clientsList[Client1CB.SelectedIndex].Accounts[Client1AccCB.SelectedIndex].Balance.ToString();
            }
            catch
            {

            }
        }
        private void Client2AccCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Balance2TB.Text = clientsList[Client2CB.SelectedIndex].Accounts[Client2AccCB.SelectedIndex].Balance.ToString();
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
    }
}
