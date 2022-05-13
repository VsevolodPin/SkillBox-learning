using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxTask10
{
    internal class CitiesTheGame
    {
        static string pathToCities = "..\\..\\..\\ProgrammFiles\\Города.txt";

        public char lastLetter;
        public char lastLetterU
        {
            get => lastLetter.ToString().ToUpper()[0];
        }
        public bool noCities
        {
            get => Cities[alphabetDict[lastLetter]].Count == 0 ? true : false;
        }
        public string userCityU, userCityL;
        public string botCityU, botCityL;

        public string alphabetChar = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public Dictionary<char, int> alphabetDict;
        public List<string>[] Cities = new List<string>[33];
        public Random rand = new Random();

        public CitiesTheGame()
        {
            #region Формирование списка доступных городов
            rand = new Random();

            // Формирование алфавита
            alphabetDict = new Dictionary<char, int>();
            for (int i = 0; i < alphabetChar.Length; i++)
            {
                alphabetDict.Add(alphabetChar[i], i);
            }
            // Формирование списка городов
            for (int i = 0; i < Cities.Length; i++)
            {
                Cities[i] = new List<string>();
            }
            HashSet<string> uniqueCities = new HashSet<string>();
            using (StreamReader sr = new StreamReader(pathToCities))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    line = line.ToLower();
                    line = line.Split('(')[0].TrimEnd();
                    if (!line.Contains("*"))
                        if (uniqueCities.Add(line))
                        {
                            Cities[alphabetDict[line[0]]].Add(line);
                        }
                }
            }
            #endregion
        }

        public bool FirstCheck(string cityName)
        {
            userCityL = cityName.ToLower();
            userCityU = userCityL.Substring(0, 1).ToUpper() + userCityL.Substring(1);
            if (userCityL[0] != lastLetter)
                return false;
            else
                return true;
        }

        public bool CityInDatabase(string cityName)
        {
            if (Cities[alphabetDict[lastLetter]].Contains(cityName.TrimEnd()))
            {
                Cities[alphabetDict[lastLetter]].Remove(cityName);
                lastLetter = cityName.Last();
                return true;
            }
            else
                return false;
        }

        public string FindCity()
        {
            int idx;
            char last;
            do
            {
                idx = rand.Next(0, Cities[alphabetDict[lastLetter]].Count);
                last = Cities[alphabetDict[lastLetter]][idx].Last();
            } while (Cities[alphabetDict[last]].Count == 0);

            int idx2 = alphabetDict[lastLetter];
            lastLetter = Cities[idx2][idx].Last();

            botCityL = Cities[idx2][idx];
            botCityU = Cities[idx2][idx].Substring(0, 1).ToUpper() + Cities[idx2][idx].Substring(1);
            Cities[idx2].RemoveAt(idx);

            return botCityU;
        }

        public string FindRandomCity()
        {
            int letterIdx;
            do
            {
                letterIdx = rand.Next(0, Cities.Length);
            } while (Cities[letterIdx].Count == 0);
            int cityIdx = rand.Next(0, Cities[letterIdx].Count);
            botCityL = Cities[letterIdx][cityIdx];
            botCityU = Cities[letterIdx][cityIdx].Substring(0, 1).ToUpper() + Cities[letterIdx][cityIdx].Substring(1);

            lastLetter = Cities[letterIdx][cityIdx].Last();
            Cities[letterIdx].RemoveAt(cityIdx);
            return botCityU;
        }
    }
}
