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
        public string Signature { get; }
        public Client UpdateClient(Client oldClient, Client newClient);
    }

    public class Consultant : IWorker
    {
        protected bool access; // есть ли доступ к паспортным данным

        public Consultant()
        {
            access = false;
        }

        public bool Access
        {
            get => access;
        }

        public string Signature
        {
            get => access == true ? "Manager" : "Consultant";
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
    }
}
