using System;

namespace SkillBoxTask12
{
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
            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = "";
            changesType = "";
            changerSignature = "";
        }

        public Log(string ChangesList, string ChangesType, string ChangerSignature)
        {
            timeChanges = DateTime.Now.ToLocalTime().ToLongDateString();
            changesList = ChangesList;
            changesType = ChangesType;
            changerSignature = ChangerSignature;
        }
    }
}
