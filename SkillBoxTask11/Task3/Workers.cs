using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IWorker
    {
        public bool Access { get; }
        public string GetInfo(Client client);
        public string Identificate { get; }
        public Client UpdateClient(Client oldClient, Client newClient);
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

        public string Identificate
        {
            get => access == true ? "Manager" : "Consultant";
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

        public Client UpdateClient(Client oldClient, Client newClient)
        {
            return oldClient.UpdateClient(newClient, this);
        }
    }

    public class Manager : Consultant
    {
        public Manager()
        {
            access = true;
        }
        public Client CreateClient(string Surname, string Name, string Patronymic, string Phone, string PassS = "", string PassN = "")
        {
            Client client = new Client(Surname, Name, Patronymic, Phone, PassS, PassN);
            return client;
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
