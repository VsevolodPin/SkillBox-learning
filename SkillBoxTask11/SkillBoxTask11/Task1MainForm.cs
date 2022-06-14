using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SkillBoxTask11
{
    public partial class Form1 : Form
    {
        #region Поля главноего окна
        List<Client> clients = new List<Client>();
        Manager manager;
        Consultant consultant;
        IWorker currentUser
        {
            get => ConsRB.Checked == true ? consultant : manager;
        }
        #endregion

        public Form1()
        {
            InitializeComponent();

            EditGroup.Enabled = false;

            manager = new Manager();
            consultant = new Consultant();

            if (File.Exists("Clients DataBase.DB"))
            {
                using (StreamReader sr = new StreamReader("Clients DataBase.DB"))
                {
                    string json = sr.ReadToEnd();
                    clients = JsonConvert.DeserializeObject<List<Client>>(json);
                }
            }
            ClientsListBox.Items.Clear();
            if (clients.Count != 0)
                RefreshList();
        }

        #region Обработка кнопок
        private void AddClientBT_Click(object sender, EventArgs e)
        {
            Client client;
            if (String.IsNullOrEmpty(PatrTB1.Text))
            {
                if (String.IsNullOrEmpty(SurTB1.Text))
                {
                    client = new Client(
                        NameTB1.Text,
                        PhoneTB1.Text,
                        PassSTB1.Text, PassNTB1.Text);
                }
                else
                {
                    client = new Client(
                        SurTB1.Text, NameTB1.Text,
                        PhoneTB1.Text,
                        PassSTB1.Text, PassNTB1.Text);
                }
            }
            else
            {
                client = new Client(
                    SurTB1.Text, NameTB1.Text, PatrTB1.Text,
                    PhoneTB1.Text,
                    PassSTB1.Text, PassNTB1.Text);
            }
            clients.Add(client);
            ClientsListBox.Items.Add(client.FullName);
        }
        private void EditBT_Click(object sender, EventArgs e)
        {
            EditBT.Enabled = false;
            EditGroup.Enabled = false;
            UserChoosing.Enabled = true;
            ClientsListBox.Enabled = true;
            CreateClientGroup.Enabled = currentUser.Access;

            Client client;
            if (currentUser.Access)
            {
                client = new Client(
                                    SurTB2.Text, NameTB2.Text, PatrTB2.Text,
                                    PhoneTB2.Text,
                                    PassSTB2.Text, PassNTB2.Text);
            }
            else
            {
                client = new Client(
                                     SurTB2.Text, NameTB2.Text, PatrTB2.Text,
                                     PhoneTB2.Text,
                                     clients[ClientsListBox.SelectedIndex].passportSeries, clients[ClientsListBox.SelectedIndex].passportNumber);
            }

            ClientsListBox.Items.Remove(ClientsListBox.SelectedIndex);
            ClientsListBox.Items.Add(client.FullName);
            clients.Remove(clients[ClientsListBox.SelectedIndex]);
            clients.Add(client);
            RefreshList();
            ResetInfo();
        }
        private void SaveBT_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Clients DataBase.DB"))
            {
                string json = JsonConvert.SerializeObject(clients);
                sw.Write(json);
            }
        }
        #endregion

        #region Обработка событий
        private void ConsRB_CheckedChanged(object sender, EventArgs e)
        {
            ResetInfo();
            RefreshList();
            if (ConsRB.Checked)
            {
                AddClientBT.Enabled = false;
                CreateClientGroup.Enabled = false;
            }
            else
            {
                AddClientBT.Enabled = true;
                CreateClientGroup.Enabled = true;
            }
        }
        private void RefreshList()
        {
            ClientsListBox.Items.Clear();
            foreach (Client item in clients)
                ClientsListBox.Items.Add(item.FullName);
        }
        private void ClientsListBox_DoubleClick(object sender, EventArgs e)
        {
            EditBT.Enabled = true;
            EditGroup.Enabled = true;
            ClientsListBox.Enabled = false;
            CreateClientGroup.Enabled = false;
            if (ConsRB.Checked)
            {
                SurTB2.Enabled = false;
                NameTB2.Enabled = false;
                PatrTB2.Enabled = false;
                PassSTB2.Enabled = false;
                PassNTB2.Enabled = false;
            }
            else
            {
                SurTB2.Enabled = true;
                NameTB2.Enabled = true;
                PatrTB2.Enabled = true;
                PassSTB2.Enabled = true;
                PassNTB2.Enabled = true;
            }
            UserChoosing.Enabled = false;

            Parse(clients[ClientsListBox.SelectedIndex]);
        }
        private void ClientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parse(clients[ClientsListBox.SelectedIndex]);
        }
        private void Parse(Client client)
        {
            SurTB2.Text = client.surname;
            NameTB2.Text = client.name;
            PatrTB2.Text = client.patronymic;
            PhoneTB2.Text = client.phone;
            string passport = client.Passport(currentUser.Access);
            PassSTB2.Text = passport.Split(' ')[0];
            PassNTB2.Text = passport.Split(' ')[1];
        }
        private void ResetInfo()
        {
            SurTB2.Text = "";
            NameTB2.Text = "";
            PatrTB2.Text = "";
            PhoneTB2.Text = "";
            PassSTB2.Text = "";
            PassNTB2.Text = "";
        }
        #endregion

    }
}
