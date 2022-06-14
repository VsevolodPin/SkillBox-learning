using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxTask11
{
    public class Client
    {
        public string
            surname = "", name, patronymic = "",
            phone,
            passportSeries, passportNumber;

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
                    return passportSeries.Trim()+ " " + passportNumber.Trim();
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

        #region Конструкторы
        public Client()
        {
            surname = " ";
            name = " ";
            patronymic = " ";
            phone = " ";
            passportSeries = " ";
            passportNumber = " ";

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
        }
        #endregion
    }

    public interface IWorker
    {
        public bool Access { get; }
        public string GetInfo(Client client);
    }


    public class Consultant : IWorker
    {
        protected bool access;
        public Consultant()
        {
            access = false;
        }

        public bool Access
        {
            get => access;
        }

        public string GetInfo(Client client)
        {
            string passport = client.Passport(access);
            string clientFIO = client.FullName;
            string phoneNumber = client.phone;
            return $"{clientFIO}|{phoneNumber}|{passport}";
        }

        public bool UpdatePhone(Client client, string Phone)
        {
            return client.UpdatePhone(Phone);
        }
    }

    public class Manager : Consultant
    {
        public Manager()
        {
            access = true;
        }

        public bool UpdateData(Client client, string Surname, string Name, string Patronymic, string Phone, string PassS = "", string PassN = "")
        {
            // Делаем копию данных клиента
            Client reserveData = client;

            // Проверка корректности изменений
            bool result;
            result = client.UpdateFullName(Surname, Name, Patronymic);
            result &= client.UpdatePhone(Phone);
            result &= client.UpdatePassport(PassS, PassN);
            if (!result)
            {
                client = reserveData;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


