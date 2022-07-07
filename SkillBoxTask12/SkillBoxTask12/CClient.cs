using System;
using System.Collections.Generic;

namespace SkillBoxTask12
{
    public class Client : IComparable, IComparable<Client>
    {
        #region Поля класса
        public string
            surname = " ", name, patronymic = " ",
            phone,
            passportSeries, passportNumber;

        public List<Log> Logs = new List<Log>();
        #endregion

        #region Получение данных
        public List<string> GetLogsList
        {
            get
            {
                List<string> LogsList = new List<string>();
                for (int i = 0; i < Logs.Count; i++)
                {
                    LogsList.Add($"Изменение №{i + 1}");
                }
                return LogsList;
            }
        }
        public string FullName
        {
            get => $"{(String.IsNullOrEmpty(surname) == true ? ' ' : surname.Trim())} " +
                $"{name.Trim()} " +
                $"{(String.IsNullOrEmpty(patronymic) == true ? String.Empty : patronymic.Trim())}";
        }
        public string Passport(bool access = false)
        {
            if (String.IsNullOrEmpty(passportSeries) || String.IsNullOrEmpty(passportNumber))
            {
                return String.Empty + " " + String.Empty;
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
        #endregion

        #region Реализация IComparable

        public int CompareTo(object obj)
        {
            return CompareClient(this, (Client)obj);
        }
        public int CompareTo(Client obj)
        {
            if (obj != null && !(obj is Client))
            {
                throw new ArgumentException("Объект должен быть типа Client");
            }
            return CompareClient(this, obj);
        }
        public int CompareClient(Client cl1, Client cl2)
        {
            return cl1.FullName.CompareTo(cl2.FullName);
        }

        #endregion

        #region Конструкторы
        public Client()
        {
            surname = " ";
            name = " ";
            patronymic = " ";
            phone = " ";
            passportSeries = " ";
            passportNumber = " ";

            Logs = new List<Log>();
        }

        /// <summary>
        /// Полный конструктор
        /// </summary>
        public Client(string Surname, string Name, string Patronymic, string Phone, string PassS = "", string PassN = "")
        {
            surname = Surname;
            name = Name;
            patronymic = Patronymic;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            Logs = new List<Log>();
        }

        /// <summary>
        /// Конструктор без отчества
        /// </summary>
        public Client(string Surname, string Name, string Phone, string PassS = "", string PassN = "")
        {
            surname = Surname;
            name = Name;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            Logs = new List<Log>();
        }

        /// <summary>
        /// Конструктор без фамилии и отчества
        /// </summary>
        public Client(string Name, string Phone, string PassS = "", string PassN = "")
        {
            name = Name;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            Logs = new List<Log>();
        }

        /// <summary>
        /// Конструктор через массив данных
        /// </summary>
        /// <param name="data"> Фамилия, имя, отчество, телефон, серия паспорта, номер паспорта </param>
        public Client(List<string> data)
        {
            surname = data[0];
            name = data[1];
            patronymic = data[2];
            phone = data[3];
            passportSeries = data[4];
            passportNumber = data[5];

            Logs = new List<Log>();
        }
        #endregion

        public Client UpdateClient(Client newClient, IWorker Changer)
        {
            string localChangesList = "";
            if (FullName != newClient.FullName)
            {
                localChangesList += $"Изменено полное имя\n";
            }
            if (phone != newClient.phone)
            {
                localChangesList += $"Изменен номер телефона\n";
            }
            if (passportSeries + passportNumber != newClient.passportSeries + passportNumber)
            {
                localChangesList += $"Изменен паспорт";
            }
            if (String.IsNullOrEmpty(localChangesList))
            {
                return this;
            }
            else
            {
                surname = newClient.surname;
                name = newClient.name;
                patronymic = newClient.patronymic;
                phone = newClient.phone;
                passportSeries = newClient.passportSeries;
                passportNumber = newClient.passportNumber;

                var notice = new Log(localChangesList, "Изменен", Changer.Signature);
                Logs.Add(notice);
                return this;
            }
        }
    }
}
