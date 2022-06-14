using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Task3MainForm : Form
    {
        public Task3MainForm()
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

        #region Поля главноего окна
        List<Client> clients = new List<Client>();
        Manager manager;
        Consultant consultant;
        IWorker currentUser
        {
            get => ConsRB.Checked == true ? consultant : manager;
        }
        #endregion

        #region Обработка кнопок
        private void AddClientBT_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NameTB1.Text) && !String.IsNullOrEmpty(PhoneTB1.Text))
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
        }
        private void EditBT_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NameTB2.Text) && !String.IsNullOrEmpty(PhoneTB2.Text))
            {
                EditBT.Enabled = false;
                EditGroup.Enabled = false;
                UserChoosing.Enabled = true;
                ClientsListBox.Enabled = true;
                CreateClientGroup.Enabled = currentUser.Access;

                Client client;

                if (currentUser.Access)
                {
                    client = manager.UpdateClient(
                       clients[ClientsListBox.SelectedIndex],
                       new Client(
                       SurTB2.Text, NameTB2.Text, PatrTB2.Text,
                       PhoneTB2.Text,
                       PassSTB2.Text, PassNTB2.Text));
                }
                else
                {
                    client = consultant.UpdateClient(
                        clients[ClientsListBox.SelectedIndex],
                        new Client(
                        SurTB2.Text, NameTB2.Text, PatrTB2.Text,
                        PhoneTB2.Text,
                        clients[ClientsListBox.SelectedIndex].passportSeries, clients[ClientsListBox.SelectedIndex].passportNumber));
                }
                ClientsListBox.Items.Remove(ClientsListBox.SelectedIndex);
                ClientsListBox.Items.Add(client.FullName);
                clients.Remove(clients[ClientsListBox.SelectedIndex]);
                clients.Add(client);
                RefreshList();
            }
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
        private void ClientsListBox_DoubleClick(object sender, EventArgs e)
        {
            EditBT.Enabled = true;
            EditGroup.Enabled = true;
            ClientsListBox.Enabled = false;
            CreateClientGroup.Enabled = false;
            if (currentUser.Access)
            {
                SurTB2.Enabled = true;
                NameTB2.Enabled = true;
                PatrTB2.Enabled = true;
                PassSTB2.Enabled = true;
                PassNTB2.Enabled = true;
            }
            else
            {
                SurTB2.Enabled = false;
                NameTB2.Enabled = false;
                PatrTB2.Enabled = false;
                PassSTB2.Enabled = false;
                PassNTB2.Enabled = false;
            }
            UserChoosing.Enabled = false;

            Parse(clients[ClientsListBox.SelectedIndex]);
        }
        private void ClientsListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                EditBT.Enabled = true;
                EditGroup.Enabled = true;
                ClientsListBox.Enabled = false;
                CreateClientGroup.Enabled = false;
                if (currentUser.Access)
                {
                    SurTB2.Enabled = true;
                    NameTB2.Enabled = true;
                    PatrTB2.Enabled = true;
                    PassSTB2.Enabled = true;
                    PassNTB2.Enabled = true;
                }
                else
                {
                    SurTB2.Enabled = false;
                    NameTB2.Enabled = false;
                    PatrTB2.Enabled = false;
                    PassSTB2.Enabled = false;
                    PassNTB2.Enabled = false;
                }
                UserChoosing.Enabled = false;

                Parse(clients[ClientsListBox.SelectedIndex]);
            }
        }
        private void ClientsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Parse(clients[ClientsListBox.SelectedIndex]);
            }
            catch
            {
                // nothing;
            }
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
            TimeChangesTB.Text = client.timeChanges;
            ChangesListTB.Text = client.changesList;
            ChangesTypeTB.Text = client.changesType;
            ChangerSignatureTB.Text = client.changerSignature;
        }
        private void ResetInfo()
        {
            SurTB2.Text = "";
            NameTB2.Text = "";
            PatrTB2.Text = "";
            PhoneTB2.Text = "";
            PassSTB2.Text = "";
            PassNTB2.Text = "";
            TimeChangesTB.Text = "";
            ChangesListTB.Text = "";
            ChangesTypeTB.Text = "";
            ChangerSignatureTB.Text = "";
        }
        private void RefreshList()
        {
            ClientsListBox.Items.Clear();
            foreach (Client item in clients)
                ClientsListBox.Items.Add(item.FullName);
        }
        #endregion
    }
}
