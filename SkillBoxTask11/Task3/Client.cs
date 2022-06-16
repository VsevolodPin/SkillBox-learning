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
            passportSeries, passportNumber;

        public List<Log> Logs = new List<Log>();

        public string FullName
        {
            get => $"{surname} {name} {patronymic}".Trim();
        }

        public Log LastLog
        {
            get
            {
                return Logs.Count==0?new Log():Logs.Last();
            }
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

                var notice = new Log(DateTime.Now.ToLocalTime().ToLongDateString(), localChangesList, "Изменен", Changer.Identificate);
                Logs.Add(notice);
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

            Logs = new List<Log>();
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

            Logs = new List<Log>();
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
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            Logs = new List<Log>();
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
            name = Name;
            phone = Phone;
            passportSeries = PassS;
            passportNumber = PassN;

            Logs = new List<Log>();
        }
        #endregion
    }

    public class Log
    {
        public string timeChanges,
              changesList,
              changesType,
              changerSignature;

        public string GetLog
        {
            get => $"{timeChanges}\n{changesList}\n{changesType}\n{changerSignature}";
        }

        public Log()
        {
            timeChanges = "";
            changesList = "";
            changesType = "";
            changerSignature = "";
        }

        public Log(string TimeChanges, string ChangesList, string ChangesType, string ChangerSignature)
        {
            timeChanges = TimeChanges;
            changesList = ChangesList;
            changesType = ChangesType;
            changerSignature = ChangerSignature;
        }
    }
}
