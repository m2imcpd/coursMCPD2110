﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace coursCSharp.Classes
{
    public class Client
    {
        private int numero;

        private string nom;

        private string prenom;

        private string telephone;

        //private static int compteur = 0;

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public Client()
        {
            //compteur++;
            //Numero = compteur;
            
        }

        public Client(string n, string p, string t)
        {
            int compteur = 0;
            if (File.Exists("client.txt"))
            {
                StreamReader reader = new StreamReader(File.Open("client.txt", FileMode.Open));
                compteur = Convert.ToInt32(reader.ReadToEnd());
                reader.Dispose();
            }
            compteur++;
            Numero = compteur;
            StreamWriter writer = new StreamWriter(File.Open("client.txt", FileMode.Create));
            writer.WriteLine(compteur);
            writer.Dispose();
            Nom = n;
            Prenom = p;
            Telephone = t;
        }
        //public override string ToString()
        //{
        //    return "Numero : " + Numero + " Nom : " + Nom + " Prénom : " + Prenom + " Téléphone : " + Telephone;
        //}
        //public override string ToString() => "Numero : " + Numero + " Nom : " + Nom + " Prénom : " + Prenom + " Téléphone : " + Telephone;
        public override string ToString() => $"Numero : {Numero}  Nom : {Nom} Prénom :  {Prenom}  Téléphone :  {Telephone}";
    }
}
