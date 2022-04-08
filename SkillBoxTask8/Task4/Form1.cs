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
using System.Xml.Linq;
using System.Xml.Serialization;


// Задание 4.Записная книжка

// Что нужно сделать
// Программа спрашивает у пользователя данные о контакте:

// ФИО
// Улица
// Номер дома
// Номер квартиры
// Мобильный телефон
// Домашний телефон

// С помощью XElement создайте xml файл, в котором есть введенная информация. XML файл должен содержать следующую структуру:

// < Person name =”ФИО человека” >
//     <Address>
//         <Street>Название улицы</Street>
//         <HouseNumber>Номер дома</HouseNumber>
//         <FlatNumber>Номер квартиры</FlatNumber>
//     </Address>
//     <Phones>
//         <MobilePhone>89999999999999</MobilePhone>
//         <FlatPhone>123-45-67<FlatPhone>
//     </Phones>
// </Person>

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteAsXML_Click(object sender, EventArgs e)
        {
            Person person = new Person(
                SurnameTB.Text, NameTB.Text, PatrTB.Text,
                StreetTB.Text, BuildingNumberTB.Text, ApartmentNumberTB.Text,
                MobileNumberTB.Text, HomeNumberTB.Text);

            XElement mainContainer = new XElement("Person", new XAttribute("name", person.FullName),
                new XElement("Address",
                    new XElement("Street", person.Street),
                    new XElement("HouseNumber", person.BuildingNumber),
                    new XElement("FlatNumber", person.ApartmentNumber)),
                new XElement("Phones",
                    new XElement("MobilePhone", person.MobileNumber),
                    new XElement("FlatPhone", person.HomeNumber)));

            if (NameUsage.Checked)
            {
                mainContainer.Save(new FileStream($"{person.FullName}.xml", FileMode.Create, FileAccess.Write));
            }
            else
            {
                if (File.Exists("Записная книжка.xml"))
                {
                    FileStream fs = new FileStream("Записная книжка.xml", FileMode.Append, FileAccess.Write);
                    mainContainer.Save(fs);
                    fs.Close();
                }
                else
                {
                    mainContainer.Save(new FileStream("Записная книжка.xml", FileMode.Create, FileAccess.Write));
                }
            }
        }
    }
}
