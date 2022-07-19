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
    public partial class MainWindow : Window
    {
        List<Client> clientsList;
        Random rand = new Random();

        public MainWindow()
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
                Balance1TB.Text = clientsList[Client1CB.SelectedIndex].Balance.ToString();
            }
            catch
            {

            }
        }
        private void Client2CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Balance2TB.Text = clientsList[Client2CB.SelectedIndex].Balance.ToString();
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
            var rnd = rand.Next(0, 3);
            if (rnd == 0)
                clientsList[Client1CB.SelectedIndex][0].SendMoney(clientsList[Client2CB.SelectedIndex][0], int.Parse(TakeOffTB.Text));
            if (rnd == 1)
                clientsList[Client1CB.SelectedIndex][0].SendMoney(clientsList[Client2CB.SelectedIndex][0], float.Parse(TakeOffTB.Text));
            if (rnd == 2)
                clientsList[Client1CB.SelectedIndex][0].SendMoney(clientsList[Client2CB.SelectedIndex][0], double.Parse(TakeOffTB.Text));
            Balance1TB.Text = clientsList[Client1CB.SelectedIndex][0].Balance.ToString();
            Balance2TB.Text = clientsList[Client2CB.SelectedIndex][0].Balance.ToString();
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
                clientsList.RemoveAt(Client1CB.SelectedIndex);
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
