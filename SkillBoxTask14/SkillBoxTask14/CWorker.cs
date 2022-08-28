using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading;


namespace SkillBoxTask14
{
    class Worker
    {
        public string Signature
        {
            get; protected set;
        }
        public Worker()
        {
            Signature = "Неизвестный работник";
        }

        /// <summary>
        /// Запись об открытии нового счета.
        /// args[0] - имя учетной записи к которой применено действие
        /// </summary>
        public string OpenAccLog(List<string> args)
        {
            string log = $"{Signature} в {DateTime.Now.ToString("HH:mm:ss dd.MM ")} открыл счет для: {args[0]}";

            Thread thr = new Thread(new ParameterizedThreadStart(ShowVidget));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start(log);

            return $"\n{log}";
        }
        /// <summary>
        /// Запись о создании новой учетной записи.
        /// args[0] - имя учетной записи к которой применено действие
        /// </summary>
        public string CreateClientLog(List<string> args)
        {
            string log = $"{Signature} в {DateTime.Now.ToString("HH:mm:ss dd.MM ")} создал новую учетную запись для: {args[0]}";

            Thread thr = new Thread(new ParameterizedThreadStart(ShowVidget));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start(log);

            return $"\n{log}";
        }
        /// <summary>
        /// Запись о закрытии счета. 
        /// args[0] - имя учетной записи к которой применено действие
        /// </summary>
        public string CloseAccLog(List<string> args)
        {
            string log = $"{Signature} в {DateTime.Now.ToString("HH: mm: ss dd.MM ")} закрыл счет у: {args[0]}";

            Thread thr = new Thread(new ParameterizedThreadStart(ShowVidget));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start(log);

            return $"\n{log}";
        }
        /// <summary>
        /// Запись об удалении учетной записи в результате закрытия последнего счета.
        /// args[0] - имя учетной записи к которой применено действие
        /// </summary>
        public string RemoveClientLog(List<string> args)
        {
            string log = $"{Signature} в {DateTime.Now.ToString("HH:mm:ss dd.MM ")} был удален клиент: {args[0]}";

            Thread thr = new Thread(new ParameterizedThreadStart(ShowVidget));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start(log);

            return $"{log}";
        }
        /// <summary>
        /// Запись о переводе средств между счетами двух учетных записей.
        /// args[0] - имя учетной записи, с которой переводятся средства, 
        /// args[1] - имя учетной записи, на которую поступают средства
        /// </summary>
        public string TransactionLog(List<string> args)
        {
            string log = $"{Signature} в {DateTime.Now.ToString("HH:mm:ss dd.MM ")} выполнил перевод средств между счетами: {args[0]} -> {args[1]}";

            Thread thr = new Thread(new ParameterizedThreadStart(ShowVidget));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start(log);

            return $"\n{log}";
        }

        private void ShowVidget(object? log)
        {
            Vidget vidget = new Vidget();
            vidget.Left = SystemParameters.PrimaryScreenWidth - vidget.Width - 25;
            vidget.Top = SystemParameters.PrimaryScreenHeight - vidget.Height - 50;
            vidget.VidgetMsg.AppendText((string)log);
            vidget.Show();
            Thread.Sleep(2500);
            vidget.Close();
        }
    }

    class Manager : Worker
    {
        public Manager()
        {
            Signature = "Менеджер";
        }
    }

    class Consultant : Worker
    {
        public Consultant()
        {
            Signature = "Консультант";
        }
    }
}
