using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxTask7
{
    internal struct Worker
    {
        private char sep;
        // ID
        uint ID;
        // Дата и время добавления записи
        DateTime creation_time;
        // Ф.И.О.
        string full_name;
        // Возраст
        uint age;
        // Рост
        uint height;
        // Дата рождения
        DateTime birth_day;
        // Место рождения
        string birth_place;

        /// <summary>
        /// Создание нового работника
        /// </summary>
        /// <param name="_ID"> Уникальынй id </param>
        /// <param name="_creation_time"> Дата и время создания записи </param>
        /// <param name="_full_name"> Ф.И.О. </param>
        /// <param name="_age"> Возраст</param>
        /// <param name="_height"> Рост (см) </param>
        /// <param name="_birth_day"> Дата рождения </param>
        /// <param name="birth_place"> Место рождения </param>
        public Worker(
            uint _ID,
            DateTime _creation_time,
            string _full_name,
            uint _age,
            uint _height,
            DateTime _birth_day,
            string _birth_place,
            char _sep = '|')
        {
            ID = _ID;
            creation_time = _creation_time;
            full_name = _full_name;
            age = _age;
            height = _height;
            birth_day = _birth_day;
            birth_place = _birth_place;

            sep = _sep;
        }

        public Worker(string _info, char _sep = '|')
        {
            sep = _sep;
            string[] info = _info.Split(sep);
            ID = Convert.ToUInt16(info[0]);
            creation_time = Convert.ToDateTime(info[1]);
            full_name = info[2];
            age = Convert.ToUInt16(info[3]);
            height = Convert.ToUInt16(info[4]);
            birth_day = Convert.ToDateTime(info[5]);
            birth_place = info[6];
        }

        public readonly string info_to_write
        {
            get => $"{ID}{sep}" +
                    $"{creation_time.ToString("dd.MM.yyyy HH:mm")}{sep}" +
                    $"{full_name}{sep}" +
                    $"{age}{sep}" +
                    $"{height}{sep}" +
                    $"{birth_day.ToString("dd.MM.yyyy")}{sep}" +
                    $"{birth_place}";
        }

        public readonly string info_to_read
        {
            get => info_to_write.Replace(sep, ' ');
        }

        public readonly DateTime Date
        {
            get => creation_time;
        }
    }
}

