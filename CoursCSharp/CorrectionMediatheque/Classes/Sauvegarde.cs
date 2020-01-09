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
        public static void SaveAdherents(List<Adherent> Adherents)
        {
            StreamWriter writer = new StreamWriter(File.Open(Configuration.PathAdherents, FileMode.Create));
            string json = JsonConvert.SerializeObject(Adherents);
            writer.WriteLine(json);
            writer.Dispose();
        }

        public static List<Adherent> ReadAdherents()
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
    }
}
