using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxTask12
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
    }
}
