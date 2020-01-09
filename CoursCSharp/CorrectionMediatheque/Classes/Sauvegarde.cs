using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionMediatheque.Classes
{
    public class Sauvegarde
    {
        private static object _lockRead = new object();
        private static object _lockWrite = new object();
        public static void SaveAdherents(List<Adherent> Adherents)
        {
            lock(_lockWrite)
            {
                StreamWriter writer = new StreamWriter(File.Open(Configuration.PathAdherents, FileMode.Create));
                string json = JsonConvert.SerializeObject(Adherents);
                writer.WriteLine(json);
                writer.Dispose();
            }
            
        }

        public static List<Adherent> ReadAdherents()
        {
            lock(_lockRead)
            {
                List<Adherent> liste = new List<Adherent>();
                if (File.Exists(Configuration.PathAdherents))
                {
                    StreamReader reader = new StreamReader(File.Open(Configuration.PathAdherents, FileMode.Open));
                    liste = JsonConvert.DeserializeObject<List<Adherent>>(reader.ReadToEnd());
                    reader.Dispose();
                }
                return liste;
            }
            
        }


        public static Task<List<Adherent>> TaskReadAdherents()
        {
            Task<List<Adherent>> t = new Task<List<Adherent>>(() => ReadAdherents());
            t.Start();
            t.Wait();
            return t;
        }

        public static Task TaskSaveAdherents(List<Adherent> Adherents)
        {
            Task t = new Task(() => SaveAdherents(Adherents));
            t.Start();
            return t;
        }

        public static List<Oeuvre> ReadOeuvres()
        {
            lock (_lockRead)
            {
                List<Oeuvre> liste = new List<Oeuvre>();
                if (File.Exists(Configuration.PathBD))
                {
                    StreamReader reader = new StreamReader(File.Open(Configuration.PathBD, FileMode.Open));
                    liste.AddRange(JsonConvert.DeserializeObject<List<Oeuvre>>(reader.ReadToEnd()));
                    reader.Dispose();
                }
                if (File.Exists(Configuration.PathDVD))
                {
                    StreamReader reader = new StreamReader(File.Open(Configuration.PathDVD, FileMode.Open));
                    liste.AddRange(JsonConvert.DeserializeObject<List<Oeuvre>>(reader.ReadToEnd()));
                    reader.Dispose();
                }
                if (File.Exists(Configuration.PathCD))
                {
                    StreamReader reader = new StreamReader(File.Open(Configuration.PathCD, FileMode.Open));
                    liste.AddRange(JsonConvert.DeserializeObject<List<Oeuvre>>(reader.ReadToEnd()));
                    reader.Dispose();
                }
                if (File.Exists(Configuration.PathLivre))
                {
                    StreamReader reader = new StreamReader(File.Open(Configuration.PathLivre, FileMode.Open));
                    liste.AddRange(JsonConvert.DeserializeObject<List<Oeuvre>>(reader.ReadToEnd()));
                    reader.Dispose();
                }
                return liste;
            }
        }
    }
}
