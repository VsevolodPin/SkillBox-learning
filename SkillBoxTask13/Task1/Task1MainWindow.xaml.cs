using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Task1MainWindow : Window
    {
        List<Client> clientsList;
        Random rand = new Random();

        public Task1MainWindow()
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

        #region Обработка событий
        private void Client1CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Client1AccCB.Items.Clear();
                for (int i = 0; i < clientsList[Client1CB.SelectedIndex].Accounts.Count; i++)
                {
                    Client1AccCB.Items.Add($"Счет #{i + 1}");
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
                Client2AccCB.Items.Clear();
                for (int i = 0; i < clientsList[Client2CB.SelectedIndex].Accounts.Count; i++)
                {
                    Client2AccCB.Items.Add($"Счет #{i + 1}");
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

        #region Обработчики кнопок
        private void TransactionBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var rnd = rand.Next(0, 3);
                if (rnd == 0)
                    clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].SendMoney(clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex], int.Parse(TakeOffTB.Text));
                if (rnd == 1)
                    clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].SendMoney(clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex], float.Parse(TakeOffTB.Text));
                if (rnd == 2)
                    clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].SendMoney(clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex], double.Parse(TakeOffTB.Text));
                Balance1TB.Text = clientsList[Client1CB.SelectedIndex][Client1AccCB.SelectedIndex].Balance.ToString();
                Balance2TB.Text = clientsList[Client2CB.SelectedIndex][Client2AccCB.SelectedIndex].Balance.ToString();
            }
            catch { }
        }
        private void CreateBT_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client(FullNameTB.Text, double.Parse(StartBalanceTB.Text));
            clientsList.Add(client);
            RefreshComboBoxes();
        }
        private void SaveBT_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Clients DataBase.DB"))
            {
                string json = JsonConvert.SerializeObject(clientsList);
                sw.Write(json);
            }
        }
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
                clientsList[Client1CB.SelectedIndex].AddAccount(0);
                RefreshComboBoxes();
            }
            catch
            {
                // do nothing...
            }
        }

        #endregion

        public void RefreshComboBoxes()
        {
            Client1CB.Items.Clear();
            Client2CB.Items.Clear();
            Balance1TB.Text = "";
            Balance2TB.Text = "";
            TakeOffTB.Text = "";
            ReceiveTB.Text = "";

            foreach (Client client in clientsList)
            {
                Client1CB.Items.Add(client.FullName);
                Client2CB.Items.Add(client.FullName);
            }
        }

    }
}
