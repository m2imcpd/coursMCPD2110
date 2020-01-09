using coursCSharp.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace coursCSharp
{
    class Program
    {
        static object _lock = new object();
        static Mutex mutex1 = new Mutex();
        static SemaphoreSlim semaphore = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            #region cours héritage
            ////Personne p = new Personne();

            ////Etudiant e1 = new Etudiant();
            ////e1.Nom = "toto";
            ////e1.Prenom = "tata";
            ////e1.Afficher();
            ////Etudiant e2 = new Etudiant("titi", "minet");
            ////e2.Afficher();
            //Personne e3 = new Etudiant("tt", "aa", 1);
            //Personne s1 = new Salarie("Snom", "Sprenom");
            //Personne[] tabPersonne = new Personne[2];
            //tabPersonne[0] = e3;
            //tabPersonne[1] = s1;
            //foreach(Personne p in tabPersonne)
            //{
            //    if(p.GetType() == typeof(Etudiant))
            //    {
            //        (p as Etudiant).AfficherEtudiant();
            //    }
            //    if (p.GetType() == typeof(Salarie))
            //    {
            //        (p as Salarie).AfficherSalarie();
            //    }
            //    Console.WriteLine(p.GetType());
            //}
            #endregion
            #region Correction exercices
            //Correction ex1

            //Vehicule v = new Voiture(2000, 1000);
            //Vehicule c = new Camion(1999, 2000);
            //Vehicule[] tabVehicule = new Vehicule[2];
            //tabVehicule[0] = v;
            //tabVehicule[1] = c;
            //foreach (Vehicule ve in tabVehicule)
            //{
            //    Console.WriteLine(ve);
            //    ve.Demarrer();
            //    ve.Accelerer();
            //}
            //Correction Exercice 2
            //Console.OutputEncoding = Encoding.UTF8;
            //Maison m = new Maison("tourcoing", 3);
            //Batiment b = new Batiment("tourcoing");
            //Console.WriteLine(m.ToString());
            //Console.WriteLine(b.ToString());

            //Etudiant e = new Etudiant();
            //e.Marcher();
            //Salarie s = new Salarie();
            //s.Marcher();
            //Personne e = new Etudiant();
            //e.Marcher();
            //Personne s = new Salarie();
            //s.Marcher();
            //DateTime date = new DateTime(1987, 09, 11);

            //Correction ex3

            //Personne[] tab = new Personne[8];
            //tab[0] = new Employe("en1", "ep1", new DateTime(1900, 01, 01), 1000);
            //tab[1] = new Employe("en2", "ep2", new DateTime(1900, 01, 02), 1001);
            //tab[2] = new Employe("en3", "ep3", new DateTime(1900, 01, 03), 1002);
            //tab[3] = new Employe("en4", "ep4", new DateTime(1900, 01, 04), 1003);
            //tab[4] = new Employe("en5", "ep5", new DateTime(1900, 01, 05), 1004);
            //tab[5] = new Chef("cn1", "cp1", new DateTime(1800, 01, 01), 10000, "informatique");
            //tab[6] = new Chef("cn2", "cp2", new DateTime(1800, 01, 02), 10001, "RH");
            //tab[7] = new Directeur("dn1", "dp1", new DateTime(1700, 01, 01), 100000, "directeur", "M2I");
            //foreach(Personne p in tab)
            //{
            //    p.Afficher();
            //}

            //Correction compte bancaire version 1

            //IHMCompte ihmCompte = new IHMCompte();
            //ihmCompte.Start();
            #endregion
            #region cours Générique, passage paramètre, list et dictionaty
            //int d;
            //Calcule.UpdateVariable(out d);
            //Console.WriteLine(d);
            //string[] tab = new string[] { "abadi" };
            //Calcule.UpdateString(tab);
            //Console.WriteLine(tab[0]);
            //Console.WriteLine(Calcule.Addition("message1", 10, 20, 30));
            //Console.WriteLine(Calcule.Addition("message2", 10, 20));
            //Console.WriteLine(Calcule.Addition("message3", 20));
            //Console.WriteLine(Calcule.Addition("message4"));
            //Generic<int> gInt = new Generic<int>();
            //gInt.tab[0] = 10;
            //gInt.tab[1] = 20;
            //gInt.AfficherElement();

            //Generic<string> gString = new Generic<string>();
            //gString.tab[0] = "toto";
            //gString.tab[1] = "titi";
            //gString.AfficherElement();

            //List 
            //List<string> liste = new List<string>();
            ////ajouter dans une liste
            //string nom = "abadi";
            //liste.Add("tata");
            //liste.Add("toto");
            //liste.Add(nom);
            ////Parcourir une liste
            //foreach(string s in liste)
            //{
            //    Console.WriteLine(s);
            //}
            ////supprimer d'une liste
            //liste.Remove(nom);
            //liste.RemoveAt(0);
            //foreach (string s in liste)
            //{
            //    Console.WriteLine(s);
            //}
            //Dictionary
            //Dictionary<string, Personne> personnes = new Dictionary<string, Personne>();
            //personnes.Add("p1", new Employe("toto", "tata", DateTime.Now, 2000));
            //personnes.Add("p2", new Employe("titi", "minet", DateTime.Now, 2000));
            //foreach(string s in personnes.Keys)
            //{
            //    Console.WriteLine("Cle : "+ s + " value : "+personnes[s].Nom);
            //}

            //foreach(Personne p in personnes.Values)
            //{
            //    Console.WriteLine(p.Nom);
            //}
            #endregion
            #region correction forum
            //Correction Forum
            //Console.OutputEncoding = Encoding.UTF8;
            //IHMForum iForum = new IHMForum();
            //iForum.Start();
            //Convertir en json
            //string json = JsonConvert.SerializeObject(iForum);
            //Console.WriteLine(json);
            //Pile<string> pile = new Pile<string>(3);
            //Console.WriteLine(pile.Empiler("toto"));
            //Console.WriteLine(pile.Empiler("tata"));
            //Console.WriteLine(pile.Empiler("titi"));
            //Console.WriteLine(pile.Empiler("minet"));
            //Console.WriteLine(pile.Depiler());
            //Console.WriteLine(pile.Empiler("minet"));
            //Console.WriteLine(pile.GetElement(2));
            #endregion
            #region cours stream and json
            //Utilisation des fichiers en c#
            //Stream s = File.Open(@"C:\Users\Administrateur\file.txt", FileMode.Create);
            //StreamWriter writer = new StreamWriter(s);
            //writer.WriteLine("Bonjour tout le monde");
            //writer.Dispose();
            // s = File.Open(@"C:\Users\Administrateur\file.txt", FileMode.Open);
            //StreamReader reader = new StreamReader(s);
            //Console.WriteLine(reader.ReadToEnd());
            //reader.Dispose();
            //Console.Write("Merci de saisir votre texte : ");
            //StreamWriter writer = new StreamWriter(File.Open("contenu.txt", FileMode.Create));
            //string ligne;
            //do
            //{
            //    ligne = Console.ReadLine();
            //    if(ligne != "0")
            //        writer.WriteLine(ligne);
            //} while (ligne != "0");
            //writer.Dispose();
            //serialization d'un objet en json
            //Personne p = new Salarie("toto", "tata");
            //List<Personne> liste = new List<Personne>();
            //liste.Add(p);
            //liste.Add(p);
            //string json = JsonConvert.SerializeObject(liste);
            //StreamWriter writer = new StreamWriter(File.Open("personne.json", FileMode.Create));
            //writer.WriteLine(json);
            //writer.Dispose();
            //deserialization d'un objet json
            //StreamReader reader = new StreamReader(File.Open("personne.json", FileMode.Open));
            //string json = reader.ReadToEnd();
            //reader.Dispose();
            //List<Salarie> maliste = JsonConvert.DeserializeObject<List<Salarie>>(json);
            #endregion
            #region correction hotel
            //Correction Hotel
            //Console.OutputEncoding = Encoding.UTF8;
            //IHMHotel ih = new IHMHotel();
            //ih.Start();
            #endregion
            #region cours syntaxe c#, indexeur et extension méthodes
            //Syntaxe avancée c#
            //int a;
            //rendre a nullable
            //int? a = null;
            //////int b;
            //////if(a == null)
            //////{
            //////    b = 10;
            //////}
            //////else
            //////{
            //////    b = (int)a;
            //////}

            ////int b = a ?? 10;
            ////Employe e = new Employe { Nom = "toto", Prenom = "tata" };
            //Employe e = null;
            //string nom;
            //nom = e?.Nom;
            ////if (e != null)
            ////{
            ////    nom = e.Nom;
            ////}
            ////else
            ////{
            ////    nom = null;
            ////}
            //Point p1 = new Point { X = 10, Y = 20 };
            //Point p2 = new Point { X = 30, Y = 40 };
            //Point p = p1 + p2;
            //if(p1 == p2)
            //{

            //}
            //EmployeCollection collection = new EmployeCollection();
            ////List<Employe> liste = collection[DateTime.Now];
            //collection.ListeEmploye.Add(new Employe { Nom = "tata", Prenom = "toto", DateNaissance = new DateTime(1980, 1, 1) });
            //collection.ListeEmploye.Add(new Employe { Nom = "titi", Prenom = "to", DateNaissance = new DateTime(1980, 1, 2) });
            //collection.ListeEmploye.Add(new Employe { Nom = "zer", Prenom = "tozé", DateNaissance = new DateTime(1980, 1, 2) });

            //List<Employe> l2 = new List<Employe>();
            //l2.Add(new Employe { Nom = "abadi", Prenom = "ihab", DateNaissance = new DateTime(1987, 09, 11) });
            //l2.Add(new Employe { Nom = "qdqsdqsd", Prenom = "qsdsq", DateNaissance = new DateTime(1987, 09, 11) });
            //collection[new DateTime(1987, 09, 11)] = l2;
            //foreach (Employe e in collection[new DateTime(1987, 09, 11)])
            //{
            //    Console.WriteLine(e.Nom);
            //}

            //List<int> liste = new List<int>() { 10, 34, 44, 55 };
            //liste.Shuffle();
            //liste.AddToAll(30);
            //List<string> listeString = new List<string>() { "toto", "tata", "titi", "minet" };
            //listeString.Shuffle();
            //double a = 10;
            //Double aBis = new Double()
            //ICalcule<double> monCalcule = new Calcule2();

            //IHMCalcule.Start(monCalcule);
            #endregion
            #region correction exercice interface
            //Correction Ex 1 Interface 
            //List<IAnimal> liste = new List<IAnimal>();
            //liste.Add(new Chien { Nom = "c1" });
            //liste.Add(new Chien { Nom = "c2" });
            //liste.Add(new Chat { Nom = "chat1" });
            //liste.Add(new Lapin { Nom = "lapin1" });
            //foreach(IAnimal a in liste)
            //{
            //    Console.WriteLine(a.GetType());
            //    a.Crier();
            //}
            #endregion
            #region cours delegate, expression lambda, event
            //Cours delegate

            //Console.WriteLine(Calcule.Calculatrice(10, 30, Calcule.Addition));
            //Console.WriteLine(Calcule.Calculatrice(10, 30, Calcule.Souctraction));
            //Console.WriteLine(Calcule.Calculatrice(10, 30, Multiplication));
            //Console.WriteLine(Calcule.Calculatrice(10, 30, (a, b) => { return a / b; }));
            //Afficher("Mon message", (m) => { Console.WriteLine("Methode 1 " + m); });
            //Afficher("Mon message", (m) => { Console.WriteLine("Methode 2 " + m); });
            //Calcule calcule = new Calcule();
            //calcule.MonOperation = Multiplication;
            //calcule.MonOperation += Calcule.Addition;
            //calcule.MonOperation += (a, b) => { return a / b; };
            //calcule.Calculatrice(10, 30);
            //calcule.MonOperation -= Calcule.Addition;
            ////calcule.MonOperation = null;
            //calcule.Calculatrice(100, 300);
            //    Voiture v = new Voiture { Prix = 10000, Annee = 2010 };
            //    v.Promotion += (p) =>
            //    {
            //        Console.WriteLine("Sms promotion : " + p);
            //    };
            //    v.Promotion += MailPromotion;
            //    string choix;
            //    do
            //    {
            //        Console.WriteLine("Promotion ? : ");
            //        choix = Console.ReadLine();
            //        if(choix == "oui")
            //        {
            //            Console.WriteLine("Nouveau prix : ");
            //            decimal prix = Convert.ToDecimal(Console.ReadLine());
            //            v.ChangerPrix(prix);
            //        }
            //    }
            //    while (choix != "0");
            //Pile<int> maPile = new Pile<int>(3);
            //maPile.PilePleine += () => { Console.WriteLine("Pile Pleine"); };
            //maPile.Empiler(10);
            //maPile.Empiler(20);
            //maPile.Empiler(30);
            //maPile.Empiler(40);
            //List<int> liste = new List<int>() { 10,20, 35};
            //int a = liste.Find(x => x == 10);
            //List<Personne> liste = new List<Personne>();
            //liste.Add(new Employe { Nom = "tata" });
            //liste.Add(new Employe { Nom = "titi" });

            //Personne p = liste.Find(x => x.Nom == "tata");
            //List<Personne> lp = liste.FindAll(x => x.Nom == "tata");

            #endregion
            #region cours gestion des exceptions et Regex
            //cours Gestion des exceptions

            //Console.WriteLine("Saisir un nombre : ");
            //try
            //{
            //    int a = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine(a);
            //}
            //catch(FormatException e)
            //{

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Erreur de saisie {e.Message}");
            //    Console.WriteLine($"Erreur de saisie {e.GetType()}");
            //    //if(e.GetType() == typeof(FormatException))
            //    //{
            //    //    Console.WriteLine("Merci de saisir un nombre");
            //    //}
            //}finally
            //{
            //    Console.WriteLine("toujours executé");
            //}

            //Employe e = new Employe();
            //try
            //{
            //    e.Salaire = -30;
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("Saisir un nombre");
            //int a;
            //Int32.TryParse(Console.ReadLine(), out a);
            //Console.WriteLine(a);

            //string chaine = "ihab@utopios.net toto@tata.fr bonjour tout le monde";
            //string pattern = @"^t";
            //string pattern = @"^[a-zA-Z]{4,}$";
            //string pattern = @"^0[1-9]{1}((-[0-9]{2}){4}|(\.[0-9]{2}){4})$";
            //string pattern = @"^0\d{1}((-\d{2}){4}|(\.\d{2}){4}|(\s\d{2}){4})$";
            //string pattern = @"[\w_.-]+@[a-zA-Z0-9_-]+\.[a-z]{2,4}";

            //[0-9] => \d
            //[^0-9] => tout sauf 0 à 9 => \D
            //[a-zA-Z0-9] => \w
            //[^a-zA-Z0-9] => \W
            //\s => espace
            //bool match = Regex.IsMatch(chaine, pattern);
            //string[] emails = Regex.Split(chaine, @"\s");
            //Regex.replace
            //Console.WriteLine(Regex.Replace(chaine, pattern, "***"));
            //MatchCollection ocs = Regex.Matches(chaine, pattern);
            //foreach(Match m in ocs)
            //{
            //    Console.WriteLine(m.Value);
            //}
            #endregion

            //Cours multithreading

            //Création d'un thread

            //Thread t1 = new Thread(() => {
            //    for(int i=1; i< 1000; i++)
            //        Console.WriteLine("Thread 1");
            //});
            //Thread t2 = new Thread(() => {
            //    for (int i = 1; i < 1000; i++)
            //        Console.WriteLine("Thread 2");
            //});
            //t1.Start();
            //t2.Start();

            //Thread t1 = new Thread(Work);
            //t1.Start("A");
            //Thread t2 = new Thread(Work);
            //t2.Start("B");

            //Task t1 = new Task(() => Work("A"));
            //Task t2 = new Task(() => Work("B"));
            //t1.Start();
            //t2.Start();

            //Task<string> tString = new Task<string>(() => { return WorkString(); });
            ////Fin de l'execution de la task
            //tString.Start();
            //tString.Wait();
            ////Si la task a reussi son execution
            //if(tString.Status == TaskStatus.RanToCompletion)
            //    Console.WriteLine(tString.Result);

            //Exemple de deallock

            //object lock1 = new object();
            //object lock2 = new object();
            //Thread t = new Thread(() =>
            //{
            //    lock(lock1)
            //    {
            //        Thread.Sleep(3000);
            //        lock (lock2) {
            //            Console.WriteLine("T lock 2");
            //        }
            //    }
            //});
            //t.Start();
            //lock(lock2)
            //{
            //    Thread.Sleep(3000);
            //    lock(lock1)
            //    {
            //        Console.WriteLine("TInitial lock 1");
            //    }
            //}

            //Exemple semaphore;
            Console.OutputEncoding = Encoding.UTF8;
            for(int i = 1; i <= 10; i++)
            {
                Thread t = new Thread(WorkingWithSemaphore);
                t.Start(i.ToString());
            }
            Console.ReadLine();
        }
        public static void WorkingWithSemaphore(object o)
        {
            semaphore.Wait();
            Console.WriteLine("Thread N° " + (string)o + " Start");
            Console.WriteLine("Thread N° " + (string)o + " Working");
            Thread.Sleep(3000);
            Console.WriteLine("Thread N° " + (string)o + " End");
            semaphore.Release();
        }
        public static string WorkString()
        {
            return "Bonjour tout le monde";
        }
        //public static void Work(object p)
        //{
        //    lock(_lock)
        //    {
        //        for (int i = 1; i < 1000; i++)
        //        {
        //            Console.WriteLine((string)p);
        //        }
        //    }
            
        //}

        public static void Work(object p)
        {
            mutex1.WaitOne();
                for (int i = 1; i < 1000; i++)
                {
                    Console.WriteLine((string)p);
                }
            mutex1.ReleaseMutex();

        }

        //public static void MailPromotion(decimal p)
        //{
        //    Console.WriteLine("Mail promotion : " + p);
        //}
        //public static void Afficher(string message,Action<string> methodeAffichage)
        //{
        //    methodeAffichage(message);
        //}

        //public static double Multiplication(double a, double b)
        //{
        //    Console.WriteLine(a * b);
        //    return a * b;
        //}
    }
}