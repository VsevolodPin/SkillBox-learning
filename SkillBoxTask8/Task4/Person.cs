using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Person
    {
        #region Поля класса
        // ФИО
        public string FullName;
        // Улица проживания
        public string Street;
        // Номер дома
        public string BuildingNumber;
        // Номер квартиры
        public string ApartmentNumber;
        // Полный адрес
        public string Address
        {
            get => $"улица {Street}, дом №{BuildingNumber}, квартира №{ApartmentNumber}";
        }
        // Мобильный телефон
        public string MobileNumber;
        // Домашний телефон
        public string HomeNumber;
        // Контакты
        public string Contacts
        {
            get => $"Мобильный телефон: {MobileNumber}\n Домашний телефон: {HomeNumber}";
        }
        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор через фамилию, имя, отчество по отдельности
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronymic"></param>
        /// <param name="street"></param>
        /// <param name="building"></param>
        /// <param name="apartment"></param>
        /// <param name="mobNumber"></param>
        /// <param name="homeNumber"></param>
        public Person(
            string surname, string name, string patronymic,
            string street, string building, string apartment,
            string mobNumber, string homeNumber)
        {
            FullName = $"{surname} {name} {patronymic}";
            Street = street;
            BuildingNumber = building;
            ApartmentNumber = apartment;
            MobileNumber = mobNumber;
            HomeNumber = homeNumber;
        }

        /// <summary>
        /// Конструктор через ФИО
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="street"></param>
        /// <param name="building"></param>
        /// <param name="apartment"></param>
        /// <param name="mobNumber"></param>
        /// <param name="homeNumber"></param>
        public Person(
            string fullName,
            string street, string building, string apartment,
            string mobNumber, string homeNumber)
        {
            FullName = fullName;
            Street = street;
            BuildingNumber = building;
            ApartmentNumber = apartment;
            MobileNumber = mobNumber;
            HomeNumber = homeNumber;
        }
        #endregion
    }
}
