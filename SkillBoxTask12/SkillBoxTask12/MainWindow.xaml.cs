using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillBoxTask12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Поля класса окна

        IWorker currentUser
        {
            get => ConsRB.IsChecked == true ? new Consultant() : new Manager();
        }
        List<Client> clientsList = new List<Client>();

        List<TextBox> addClientGroup, changeClientGroup;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            #region Инициализация 

            Authorization authorizationWindow = new Authorization();
            authorizationWindow.ShowDialog();
            if (authorizationWindow.currentWorker.Access)
            {
                ManagerRB.IsChecked = true;
            }
            else
            {
                ConsRB.IsChecked = true;
            }
            AddClientBT.IsEnabled = false;

            List<TextBox> addClientGroup = new List<TextBox> { FamTB1, NameTB1, PatrTB1, PhoneTB1, PassSTB1, PassNTB1 };
            List<TextBox> changeClientGroup = new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2, PassSTB2, PassNTB2 };

            if (File.Exists("Clients DataBase.DB"))
            {
                using (StreamReader sr = new StreamReader("Clients DataBase.DB"))
                {
                    string json = sr.ReadToEnd();
                    clientsList = JsonConvert.DeserializeObject<List<Client>>(json);
                }
            }
            ClientsLB.Items.Clear();
            if (clientsList.Count != 0)
            {
                RefreshList(ClientsLB, GetFullNames(clientsList));
                RefreshList(LogsLB);
            }

            #endregion
        }

        #region Обработка радиокнопок

        private void ConsChecked(object sender, RoutedEventArgs e)
        {
            EnableElements(new List<TextBox>
            {   FamTB1, NameTB1, PatrTB1, PhoneTB1, PassSTB1, PassNTB1,
                FamTB2, NameTB2, PatrTB2, PassSTB2, PassNTB2 },
                false);

            if (ClientsLB.SelectedIndex > -1)
            {
                List<string> clientInfo = new List<string>();
                Client client = clientsList[ClientsLB.SelectedIndex];

                clientInfo.AddRange(client.FullName.Split(' '));
                clientInfo.Add(client.phone);
                clientInfo.AddRange(client.Passport(currentUser.Access).Split(' '));
                PasteText(new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2, PassSTB2, PassNTB2 }, clientInfo);
            }
        }
        private void ManagerChecked(object sender, RoutedEventArgs e)
        {
            EnableElements(new List<TextBox> {
                FamTB1, NameTB1, PatrTB1, PhoneTB1, PassSTB1, PassNTB1,
                FamTB2, NameTB2, PatrTB2, PassSTB2, PassNTB2 },
                true);

            if (ClientsLB.SelectedIndex > -1)
            {
                List<string> clientInfo = new List<string>();
                Client client = clientsList[ClientsLB.SelectedIndex];

                clientInfo.AddRange(client.FullName.Split(' '));
                clientInfo.Add(client.phone);
                clientInfo.AddRange(client.Passport(currentUser.Access).Split(' '));
                PasteText(new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2, PassSTB2, PassNTB2 }, clientInfo);
            }
        }

        #endregion

        #region Работа с ListBox`ами

        private void SelectNewClient(object sender, SelectionChangedEventArgs e)
        {
            Client client;
            RefreshList(LogsLB);
            if (ClientsLB.SelectedIndex == -1)
                return;
            else
            {
                List<string> clientInfo = new List<string>();
                client = clientsList[ClientsLB.SelectedIndex];

                clientInfo.AddRange(client.FullName.Split(' '));
                clientInfo.Add(client.phone);
                clientInfo.AddRange(client.Passport(currentUser.Access).Split(' '));
                PasteText(new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2, PassSTB2, PassNTB2 }, clientInfo);
            }
            RefreshList(LogsLB, client.GetLogsList);
        }
        private void SelectNewChangelog(object sender, SelectionChangedEventArgs e)
        {
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            try
            {
                Client client = clientsList[ClientsLB.SelectedIndex];
                Log log = client.Logs[LogsLB.SelectedIndex];
                PasteText(new List<TextBox> { ChangeTimeTB, ChangeTypeTB, ChangerTB }, new List<string> { log.timeChanges, log.changesType, log.changerSignature });
                paragraph.Inlines.Add(log.changesList);
                flowDocument.Blocks.Add(paragraph);
                ChangesListTB.Document = flowDocument;
            }
            catch
            {
                PasteText(new List<TextBox> { ChangeTimeTB, ChangeTypeTB, ChangerTB }, new List<string> { "", "", "" });
                paragraph.Inlines.Add("");
                flowDocument.Blocks.Add(paragraph);
                ChangesListTB.Document = flowDocument;
            }
        }
        private void RefreshList(ListBox listBox, List<string> data = null)
        {
            listBox.Items.Clear();
            if (data != null)
            {
                foreach (var item in data)
                {
                    listBox.Items.Add(item);
                }
            }
        }

        #endregion

        #region Обработка кнопок

        private void ChangeClientClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(NameTB2.Text) && !String.IsNullOrEmpty(PhoneTB2.Text))
            {
                Client client;

                if (currentUser.Access)
                {
                    client = currentUser.UpdateClient(
                        clientsList[ClientsLB.SelectedIndex],
                        new Client(GetText(new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2, PassSTB2, PassNTB2 })));
                }
                else
                {
                    List<string> data = GetText(new List<TextBox> { FamTB2, NameTB2, PatrTB2, PhoneTB2 });
                    data.AddRange(new List<string> { clientsList[ClientsLB.SelectedIndex].passportSeries, clientsList[ClientsLB.SelectedIndex].passportNumber });

                    client = currentUser.UpdateClient(clientsList[ClientsLB.SelectedIndex], new Client(data));
                }
                ClientsLB.Items.Remove(ClientsLB.SelectedIndex);
                ClientsLB.Items.Add(client.FullName);
                clientsList.Remove(clientsList[ClientsLB.SelectedIndex]);
                clientsList.Add(client);
                RefreshList(ClientsLB, GetFullNames(clientsList));
            }
        }
        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(NameTB1.Text) && !String.IsNullOrEmpty(PhoneTB1.Text))
            {
                Client client = new Client(GetText(new List<TextBox> { FamTB1, NameTB1, PatrTB1, PhoneTB1, PassSTB1, PassNTB1 }));
                client.Logs.Add(new Log("Не было изменений", "Создана", "Manager"));
                clientsList.Add(client);
                RefreshList(ClientsLB, GetFullNames(clientsList));
            }

            PasteText(new List<TextBox> { FamTB1, NameTB1, PatrTB1, PhoneTB1, PassSTB1, PassNTB1 }, new List<string> { "", "", "", "", "", "" });
        }
        private void SaveChangesClick(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Clients DataBase.DB"))
            {
                string json = JsonConvert.SerializeObject(clientsList);
                sw.Write(json);
            }
        }

        #endregion

        #region Работа с текстовыми полями

        void EnableElements(List<TextBox> elements, bool enable = false)
        {
            foreach (var elem in elements)
            {
                elem.IsEnabled = enable;
            }
        }
        void PasteText(List<TextBox> elements, List<string> texts)
        {
            if (elements.Count > texts.Count) return;
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Text = texts[i];
            }
        }
        List<string> GetText(List<TextBox> elements)
        {
            List<string> result = new List<string>();
            foreach (var elem in elements)
            {
                result.Add(elem.Text);
            }
            return result;
        }
        private void AddClientCheckValue(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(FamTB1.Text) ||
                String.IsNullOrEmpty(NameTB1.Text) ||
                String.IsNullOrEmpty(PatrTB1.Text) ||
                String.IsNullOrEmpty(PhoneTB1.Text) ||
                String.IsNullOrEmpty(PassSTB1.Text) ||
                String.IsNullOrEmpty(PassNTB1.Text))
            {
                AddClientBT.IsEnabled = false;
            }
            else
            {
                AddClientBT.IsEnabled = true;
            }
        }

        #endregion

        #region Работа с List`ами

        private List<string> GetFullNames(List<Client> clientsList)
        {
            List<string> fullNames = new List<string>();
            foreach (Client client in clientsList)
            {
                fullNames.Add(client.FullName);
            }
            return fullNames;
        }
        private void SortList(object sender, MouseButtonEventArgs e)
        {
            if (ClientListHeader.Text.Split(' ')[2] == "А-Я")
            {
                ClientListHeader.Text = "Список клиентов Я-А";
                clientsList.Sort();
                clientsList.Reverse();
                RefreshList(ClientsLB, GetFullNames(clientsList));
            }
            else
            {
                ClientListHeader.Text = "Список клиентов А-Я";
                clientsList.Sort();
                RefreshList(ClientsLB, GetFullNames(clientsList));
            }
        }

        #endregion
    }
}
