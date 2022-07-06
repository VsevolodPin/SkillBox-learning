using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
