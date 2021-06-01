﻿using Abstractions.Airport;
using Abstractions.Enums;
using Abstractions.Passanger;
using System;

namespace CS_Project
{
    public class Passenger : IPassenger, IAirportObj
    {
        #region passanger prop
        public int planeNum { get; set; }
        public Airline airline { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string nationality { get; set; }
        //public string passport { get; set; }           // now key in collection
        public DateTime dateOfBirthday { get; set; }
        public Sex sex { get; set; }
        public Class classF { get; set; }
        public int price { get; set; }
        #endregion

        #region constructor
        public Passenger(int planeNum, int n, Airline airline)
        {
            this.planeNum = planeNum;
            this.airline = airline;
            AddPropData(n);
        }
        public Passenger()
        {

        }

        #endregion

        #region fill prop by rnd data
        private void AddPropData(int n)
        {
            AddName(n);
            AddSecondName(n);
            AddNationality(n);
            AddSex(n);
            AddClassF(n);
            AddDate(n);
            AddPrice();
        }
        private void AddName(int n)
        {
            string[] arr = new string[] { "Max", "Jack", "James", "Kobe", "Michel" };
            this.name = arr[new Random(n * n).Next(0, arr.Length)];
        }
        private void AddSecondName(int n)
        {
            string[] arr = new string[] { "Lukashevich", "Sparrow", "LeBron", "Bryant", "Jordan" };
            this.secondName = arr[new Random(n).Next(0, arr.Length)];
        }
        private void AddNationality(int n)
        {
            string[] arr = new string[] { "Ukrain", "EU", "Japan", "USA", "Moldova" };
            this.nationality = arr[new Random(n).Next(0, arr.Length)];
        }
        private string CreatePassportNum(int n)
        {
            string[] arr = new string[] { "AA", "AE", "DQ", "GG", "WP" };

            return arr[new Random(n + 100).Next(0, arr.Length)] +
                new Random(n + 111).Next(100, 999) +
                arr[new Random(n + 222).Next(0, arr.Length)];
        }
        private void AddSex(int n)
        {
            Sex[] arr = new Sex[] { Sex.Female, Sex.Male};
            this.sex = arr[new Random(n).Next(0, arr.Length)];
        }
        private void AddClassF(int n)
        {
            Class[] arr = new Class[] { Class.Business, Class.Econom };
            this.classF = arr[new Random(n).Next(0, arr.Length)];
        }
        private void AddDate(int n)
        {
            int day = new Random(n * 2).Next(1, 29);
            int month = new Random(n * 3).Next(1, 12);
            int year = new Random(n * 4).Next(1940, 2021);
            this.dateOfBirthday = new DateTime(year, month, day);
        }
        private void AddPrice()
        {
            var price = (int)classF;
            switch (this.airline)
            {
                case Airline.UkraineInternationalAirlines:
                    if (classF == Class.Business)
                        price += 5000;
                    else
                        price += 1000;
                    break;
                case Airline.Windrose:
                    if (classF == Class.Business)
                        price += 55;
                    else
                        price += 15;
                    break;
                case Airline.SkyUpAirlines:
                    if (classF == Class.Business)
                        price += 2555;
                    else
                        price += 1999;
                    break;
                case Airline.AzurAirUkraine:
                    if (classF == Class.Business)
                        price += 228;
                    else
                        price += 322;
                    break;
                default:
                    price += 1000;
                    break;
            }
            this.price = price;
        }
        #endregion

        #region print

        public void Print(int key)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Name            : " + this.name.ToString());
            Console.WriteLine("Second name     : " + this.secondName.ToString());
            Console.WriteLine("Nationality     : " + this.nationality.ToString());
            Console.WriteLine("Passport        : " + key.ToString());
            Console.WriteLine("Date of birthday: " + this.dateOfBirthday.ToShortDateString().ToString());
            Console.WriteLine("Sex             : " + this.sex.ToString());
            Console.WriteLine("Class           : " + this.classF.ToString());
            Console.WriteLine("Price           : " + this.price.ToString());
            Console.WriteLine("Plane number    : " + this.planeNum.ToString());
            Console.WriteLine("===============================");
        }


        #endregion
    }
}