using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Client
    {
        public string
            surname = "", name, patronymic = "",
            phone,
            passportSeries, passportNumber,
            timeChanges,
            changesList,
            changesType,
            changerSignature;

        public string Passport(bool access = false)
        {
            if (String.IsNullOrEmpty(passportSeries) || String.IsNullOrEmpty(passportNumber))
            {
                return String.Empty;
            }
            else
            {
                if (access)
                {
                    return passportSeries.Trim() + " " + passportNumber.Trim();
                }
                else
                {
                    return "**** ******";
                }
            }
        }

        public string FullName
        {
            get => $"{surname} {name} {patronymic}".Trim();
        }

        public string Info
        {
            get
            {
                return $"{timeChanges}\n{changesList}\n{changesType}\n{changerSignature}";
            }
        }

        public bool UpdatePhone(string newPhone)
        {
            if (String.IsNullOrEmpty(newPhone))
            {
                return false;
            }
            else
            {
                phone = newPhone;
                return true;
            }
        }

        public bool UpdateFullName(string Surname, string Name, string Patronymic)
        {
            if (String.IsNullOrEmpty(Name))
            {
                return false;
            }
            else
            {
                surname = Surname;
                name = Name;
                patronymic = Patronymic;
                return true;
            }
        }

        public bool UpdatePassport(string PassS, string PassN)
        {
            if (String.IsNullOrEmpty(PassS) || PassS.Length != 4
                || String.IsNullOrEmpty(PassN) || PassN.Length != 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Client UpdateClient(Client newClient, IWorker Changer)
        {

            changesList = "";
            if (FullName != newClient.FullName)
            {
                changesList += $"Изменено полное имя\n";
            }
            if (phone != newClient.phone)
            {
                changesList += $"Изменен номер телефона\n";
            }
            if (passportSeries + passportNumber != newClient.passportSeries + passportNumber)
            {
                changesList += $"Изменен паспорт";
            }
            if (String.IsNullOrEmpty(changesList))
            {
                changesList = "Не было изменений";
                return this;
            }
            else
            {
                timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
                changesType = "Изменен";
                changerSignature = Changer.Identificate;

                surname = newClient.surname;
                name = newClient.name;
                patronymic = newClient.patronymic;
                phone = newClient.phone;
                passportSeries = newClient.passportSeries;
                passportNumber = newClient.passportNumber;
                return this;
            }
        }

        #region Конструкторы
        public Client()
        {
            surname = " ";
            name = " ";
            patronymic = " ";
            phone = " ";
            passportSeries = " ";
            passportNumber = " ";

            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = "Не было изменений";
            changesType = "Создана";
            changerSignature = "Manager";
        }

        /// <summary>
        /// Полный конструктор
        /// </summary>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="Patronymic"></param>
        /// <param name="Phone"></param>
        /// <param name="PassS"></param>
        /// <param name="PassN"></param>
        public Client(string Surname, string Name, string Patronymic, string Phone, string PassS = "", string PassN = "")
        {
            surname = Surname;
            name = Name;
            patronymic = Patronymic;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = "Не было изменений";
            changesType = "Создана";
            changerSignature = "Manager";
        }

        /// <summary>
        /// Конструктор без отчества
        /// </summary>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="PassS"></param>
        /// <param name="PassN"></param>
        public Client(string Surname, string Name, string Phone, string PassS = "", string PassN = "")
        {
            surname = Surname;
            name = Name;
            //patronymic = String.Empty;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = "Не было изменений";
            changesType = "Создана";
            changerSignature = "Manager";
        }

        /// <summary>
        /// Конструктор без фамилии и отчества
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="PassS"></param>
        /// <param name="PassN"></param>
        public Client(string Name, string Phone, string PassS = "", string PassN = "")
        {
            //surname = String.Empty;
            name = Name;
            //patronymic = String.Empty;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = "Не было изменений";
            changesType = "Создана";
            changerSignature = "Manager";
        }
        #endregion
    }

    public class Notices
    {
        public Client client;
        string Info;

        public Notices(Client oldClient, Client newClient, IWorker Changer)
        {
            Info = Notice(oldClient, newClient, Changer);
        }

        public Notices(Client newClient, IWorker Changer)
        {
            Info = Notice(newClient, Changer);
        }

        public string Notice(Client oldClient, Client newClient, IWorker Changer)
        {
            client = newClient;
            string Date = DateTime.Now.ToLocalTime().ToString();
            string Changes = "";

            string fullName1 = oldClient.FullName, fullName2 = newClient.FullName;
            if (fullName1 != fullName2)
            {
                Changes += $"Изменено полное имя: {fullName1} => {fullName2}";
            }
            string phone1 = oldClient.phone, phone2 = newClient.phone;
            if (phone1 != phone2)
            {
                Changes += $"\nИзменен номер телефона: {phone1} => {phone2}";
            }
            string pass1 = oldClient.Passport(Changer.Access), pass2 = newClient.Passport(Changer.Access);
            if (pass1 != pass2)
            {
                Changes += $"\nИзменен паспорт: {pass1} => {pass2}";
            }
            string ChangesType = "Изменена";
            string Signature = Changer.Identificate;

            return $"{Changer.GetInfo(client)}\n{Date}\n{Changes}\n{ChangesType}\n{Signature}";
        }

        public string Notice(Client newClient, IWorker Changer)
        {
            client = newClient;
            string Date = DateTime.Now.ToLocalTime().ToString();

            string Changes = "";
            string fullName1 = "", fullName2 = client.FullName;
            if (fullName1 != fullName2)
            {
                Changes += $"Изменено полное имя: {fullName1} => {fullName2}";
            }
            string phone1 = "", phone2 = client.phone;
            if (phone1 != phone2)
            {
                Changes += $"\nИзменен номер телефона: {phone1} => {phone2}";
            }
            string pass1 = "", pass2 = client.Passport(Changer.Access);
            if (pass1 != pass2)
            {
                Changes += $"\nИзменен паспорт: {pass1} => {pass2}";
            }

            string ChangesType = "Создана";
            string Signature = Changer.Identificate;

            return $"{Changer.GetInfo(client)}\n{Date}\n{Changes}\n{ChangesType}\n{Signature}";
        }
    }

}
