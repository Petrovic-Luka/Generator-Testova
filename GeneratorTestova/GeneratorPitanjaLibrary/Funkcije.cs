using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorPitanjaLibrary
{

    public static class Funkcije
    {
        public const string dbName = "PitanjaConnectionString";
        /// <summary>
        /// vraca putanju do trazene baze
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// Vraca listu Oblast koja pripada predmetu sa proslednjenom id vrednosti
        /// </summary>
        /// <param name="IdPredmeta"></param>
        /// <returns></returns>
        public static List<Oblast> GetOblast(int IdPredmeta)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                List<Oblast> output = new List<Oblast>();
                output = connection.Query<Oblast>("Select * from oblasti where IdPredmeta=" + IdPredmeta).ToList();
                return output;
            }
        }
        /// <summary>
        /// vraca listu dostupnih pitanja na osnovu odabrane oblasti koja ima proslednjeni id
        /// </summary>
        /// <param name="idOblasti"></param>
        /// <returns></returns>
        public static List<Pitanje> GetPitanja(int idOblasti)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                List<Pitanje> output = new List<Pitanje>();
                var p = new DynamicParameters();
                p.Add("@id", idOblasti);
                output = connection.Query<Pitanje>("Get_Pitanja", p, commandType: CommandType.StoredProcedure).ToList();
                return output;
            }
        }
        /// <summary>
        /// vraca listu svih predmeta
        /// </summary>
        /// <returns></returns>
        public static List<Predmet> GetPredmet_All()
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                List<Predmet> output = new List<Predmet>();
                output = connection.Query<Predmet>("select * from predmeti").ToList();
                return output;
            }
        }

        /// <summary>
        ///vraca listu random odabranih pitanja od dostupnih
        /// </summary>
        /// <param name="brPitanja"></param>
        /// <param name="dostupna"></param>
        /// <returns></returns>
        private static List<Pitanje> OdaberiRandomPitanja(int brPitanja, List<Pitanje> dostupna)
        {
            List<Pitanje> output = new List<Pitanje>();
            Random r = new Random();
            for (int i = 0; i < brPitanja; i++)
            {
                //nije testirano ideja da ne mora da se proverava broj dostupnih pitanja i broj oblasti svaki put
                //trebalo bi da samo redom odabere sva dostupna pitanja i vrati ih
                //if(dostupna.Count==0)
                //{
                //    break;
                //}
                Pitanje p = dostupna[r.Next(0, dostupna.Count)];
                output.Add(p);
                dostupna.Remove(p);
                p = null;
            }
            return output;
        }

        /// <summary>
        /// Prima id predmeta i Listu oblasti i nasumicno odabira pitanja za test
        /// ako je lista prazna vraca pitanja za ceo predmet
        /// </summary>
        /// <param name="IdPredmeta"></param>
        /// <param name="oblasti"></param>
        /// <returns></returns>
        public static List<Pitanje> OdaberiPitanjaZaTest(int IdPredmeta, List<Oblast> oblasti)
        {
            if (oblasti == null)
            {
                return new List<Pitanje>();
            }
            int ukupanBrPitanja = 20;
            List<Pitanje> dostupnaPitanja;
            List<Pitanje> output = new List<Pitanje>();
            Random r = new Random();
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                //ako je br oblasti 0 to znaci da se gleda ceo predmet
                if (oblasti.Count == 0)
                {
                    dostupnaPitanja = connection.Query<Pitanje>("Select * from pitanja where IdPredmeta=" + IdPredmeta).ToList();
                    //ako je ukupan broj dostupnih pitanja manji od odabranog vraca samo onoliko pitanja koliko ih ima
                    if (ukupanBrPitanja > dostupnaPitanja.Count)
                    {
                        return dostupnaPitanja;
                    }
                    output = OdaberiRandomPitanja(ukupanBrPitanja, dostupnaPitanja);
                    return output;
                }
                //ako ima samo jedna oblast gleda samo tu oblast
                if (oblasti.Count == 1)
                {
                    dostupnaPitanja = connection.Query<Pitanje>("Select * from pitanja where IdOblasti=" + oblasti[0].ID).ToList();
                    if (ukupanBrPitanja > dostupnaPitanja.Count)
                    {
                        return dostupnaPitanja;
                    }
                    output = OdaberiRandomPitanja(ukupanBrPitanja, dostupnaPitanja);
                    return output;
                }
                int brojPitanjaPoOblasti;
                List<Pitanje> pomocna;
                string upit = "SELECT * FROM pitanja WHERE IdOblasti IN (";
                foreach (var i in oblasti)
                {
                    upit = upit + i.ID + ",";
                }
                upit=upit.Substring(0, upit.Length - 1);
                upit += ")";
                dostupnaPitanja = connection.Query<Pitanje>(upit).ToList();
                //ako je broj pitanja po oblasti jednak
                if (ukupanBrPitanja % oblasti.Count == 0 && ukupanBrPitanja / 2 >= oblasti.Count)
                {
                    brojPitanjaPoOblasti = ukupanBrPitanja / oblasti.Count;
                    //ako je br pitanja manji od zadatog vraca onoliko pitanja koliko ih ima
                    foreach (var i in oblasti)
                    {
                        if (brojPitanjaPoOblasti > dostupnaPitanja.Where(x => x.ID == i.ID).Count())
                        {
                            foreach (Pitanje p in dostupnaPitanja.Where(x => x.IdOblasti == i.ID).ToList())
                            {
                                output.Add(p);
                            }
                        }
                        else
                        {
                            pomocna = OdaberiRandomPitanja(brojPitanjaPoOblasti, dostupnaPitanja.Where(x => x.IdOblasti == i.ID).ToList());
                            foreach (Pitanje p in pomocna)
                            {
                                output.Add(p);
                            }
                        }
                    }
                }
                //ako je broj pitanja po oblasti nije jednak i neke oblasti treba da imaju vise od drugih
                else
                {
                    brojPitanjaPoOblasti = ukupanBrPitanja / oblasti.Count;
                    //broj oblasti koja treba da imaju vise pitanja od prosecnog
                    //ako je npr 20 pitanja i 3 oblasti 20/3=6 a 20-6*3=2 sto znaci da 2 oblasti imaju po 7 pitanja a preostala 6
                    // ako je 20/11 sledi 20/11=1 a 20-11*1=9 sto znaci 9 oblasti ima po 2 pitanja a ostale 1
                    int dodatak = ukupanBrPitanja - brojPitanjaPoOblasti * oblasti.Count;
                    foreach (var i in oblasti)
                    {
                        if (dodatak > 0)
                        {
                            if (brojPitanjaPoOblasti + 1 > dostupnaPitanja.Where(x=>x.IdOblasti==i.ID).Count())
                            {
                                pomocna = dostupnaPitanja;
                                dodatak--;
                            }
                            else
                            {
                                pomocna = OdaberiRandomPitanja(brojPitanjaPoOblasti + 1, dostupnaPitanja.Where(x => x.IdOblasti == i.ID).ToList());
                                dodatak--;
                            }
                        }
                        else
                        {
                            if (ukupanBrPitanja > dostupnaPitanja.Where(x => x.IdOblasti == i.ID).Count())
                            {
                                pomocna = dostupnaPitanja;
                            }
                            else pomocna = OdaberiRandomPitanja(brojPitanjaPoOblasti, dostupnaPitanja.Where(x => x.IdOblasti == i.ID).ToList());
                        }
                        foreach (Pitanje p in pomocna)
                        {
                            output.Add(p);
                        }
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// dodaje predmet u bazu sa odgovarajucim nazivom
        /// </summary>
        /// <param name="naziv"></param>
        public static void DodajPredmetUBazu(string naziv)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "INSERT INTO predmeti(Naziv)Values(@Naziv)";
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.Parameters.AddWithValue("@Naziv", naziv);
                command.ExecuteNonQuery();
            }
        }
       
        /// <summary>
        /// Dodaje oblast u bazu za prosledjeni naziv oblasti i id predmeta koem oblast pripada
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="IdPredmeta"></param>
        public static void DodajOblastUBazu(string naziv,int IdPredmeta)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "INSERT INTO oblasti(Naziv,IdPredmeta)Values(@Naziv,@IdPredmeta)";
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.Parameters.AddWithValue("@Naziv", naziv);
                command.Parameters.AddWithValue("@IdPredmeta",IdPredmeta);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        /// <summary>
        /// Za dati txt fajl, odabrani predmet i oblast cuva pitanja u bazu
        /// </summary>
        /// <param name="putanja"></param>
        /// <param name="IdPredmeta"></param>
        /// <param name="IdOblasti"></param>
        public static void UbacivanjePitanjaUBazu(string putanja,int IdPredmeta,int IdOblasti)
        {
            string sadrzaj = File.ReadAllText(putanja);
           sadrzaj= sadrzaj.Replace("\r\n"," ");
            sadrzaj = sadrzaj.Replace("\"", " ");
            List<string> podeljeno = sadrzaj.Split('|').ToList();
            if(podeljeno.Count%2==0)
            {
                throw new Exception("Nepravilan format pitanja");
            }
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "INSERT INTO pitanja(Tekst,Odgovor,IdOblasti,IdPredmeta)Values(@Tekst,@Odgovor,@IdOblasti,@IdPredmeta)";
                //{ podeljeno[i]}\",\"{podeljeno[i+1]}\",{IdOblasti},{IdPredmeta}
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                for (int i = 0; i < podeljeno.Count-2; i = i + 2)
                {
                    command.Parameters.AddWithValue("@Tekst", podeljeno[i]);
                    command.Parameters.AddWithValue("@Odgovor", podeljeno[i+1]);
                    command.Parameters.AddWithValue("@IdOblasti", IdOblasti);
                    command.Parameters.AddWithValue("@IdPredmeta", IdPredmeta);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                command.Dispose();
            }
        }
        /// <summary>
        /// Overload metode kada se upisuje za predmet bez odredjene oblasti
        /// </summary>
        /// <param name="putanja"></param>
        /// <param name="IdOblasti"></param>
        public static void UbacivanjePitanjaUBazu(string putanja, int IdPredmeta)
        {
            string sadrzaj = File.ReadAllText(putanja);
            sadrzaj = sadrzaj.Replace("\r\n", "");
            List<string> podeljeno = sadrzaj.Split('|').ToList();
            if (podeljeno.Count % 2 == 0)
            {
                throw new Exception("Nepravilan format pitanja");
            }
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "INSERT INTO pitanja(Tekst,Odgovor,IdPredmeta)Values(@Tekst,@Odgovor,@IdPredmeta)";
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                for (int i = 0; i < podeljeno.Count - 2; i = i + 2)
                {
                    //\"{podeljeno[i]}\",\"{podeljeno[i + 1]}\",{IdPredmeta}
                    command.Parameters.AddWithValue("@Tekst", podeljeno[i]);
                    command.Parameters.AddWithValue("@Odgovor", podeljeno[i+1]);
                    command.Parameters.AddWithValue("@IdPredmeta", IdPredmeta);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                command.Dispose();
            }
        }

        /// <summary>
        /// Za zadatu putanju,predmet i cuva txt fajl sa svim pitanjima koja pripadaju zadatoj oblasti predmeta
        /// </summary>
        public static void ExportujPitanja(string putanja,int IdPredmeta,int IdOblasti)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                List<Pitanje>pitanja = connection.Query<Pitanje>("Select * from pitanja where IdOblasti=" + IdOblasti).ToList();
                StringBuilder sb = new StringBuilder();
                foreach(Pitanje p in pitanja)
                {
                    sb.AppendLine(p.Tekst + "|" + p.Odgovor + "|");
                }
                File.WriteAllText(putanja, sb.ToString());
            }
        }
        /// <summary>
        /// Overload funkcije za ceo predmet
        /// </summary>
        /// <param name="putanja"></param>
        /// <param name="IdPredmeta"></param>
        public static void ExportujPitanja(string putanja, int IdPredmeta)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                List<Pitanje> pitanja = connection.Query<Pitanje>("Select * from pitanja where IdPredmeta=" + IdPredmeta).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (Pitanje p in pitanja)
                {
                    sb.AppendLine(p.Tekst + "|" + p.Odgovor + "|");
                }
                File.WriteAllText(putanja, sb.ToString());
            }
        }

        /// <summary>
        /// Brise pitanja samo za prosledjenu oblast odredjenog predmeta
        /// </summary>
        /// <param name="IdPredmeta"></param>
        /// <param name="IdOblasti"></param>
        public static void ObrisiPitanja(int IdPredmeta, int IdOblasti)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "DELETE FROM pitanja Where IdOblasti="+IdOblasti;
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.ExecuteNonQuery();
            }
        }
       
        /// <summary>
        /// Brise sva pitanja za dati predmet
        /// </summary>
        /// <param name="IdPredmeta"></param>
        public static void ObrisiPitanja(int IdPredmeta)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "DELETE FROM pitanja Where IdPredmeta=@IdPredmeta";
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.Parameters.AddWithValue("@IdPredmeta", IdPredmeta);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        /// <summary>
        /// Obrisi sve oblasti za zadati predmet
        /// </summary>
        /// <param name="IdPredmeta"></param>
        public static void ObrisiOblasti(int IdPredmeta)
        {
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "DELETE FROM Oblasti Where IdPredmeta=" + IdPredmeta;
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        /// <summary>
        /// Funkcija brise predmet kao i sva pitanja i oblasti vezane za njega
        /// </summary>
        /// <param name="IdPredmeta"></param>
        public static void ObrisiPredmet(int IdPredmeta)
        {
            ObrisiPitanja(IdPredmeta);
            ObrisiOblasti(IdPredmeta);
            using (IDbConnection connection = new System.Data.OleDb.OleDbConnection(CnnString(dbName)))
            {
                connection.Open();
                string s = "DELETE FROM Predmeti Where Id=" + IdPredmeta;
                OleDbCommand command = new OleDbCommand(s, (OleDbConnection)connection);
                command.ExecuteNonQuery();
            }
        }

    }
}

