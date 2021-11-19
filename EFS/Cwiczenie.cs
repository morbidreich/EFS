using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFS
{
    public class Cwiczenie
    {
        // tu siedzi cala nieobrobiona zawartosc pliku .dax
        private string m_zawartoscPliku;
        private string m_nazwaCwiczenia;
        private string m_atis;
        private string m_dapFile;
        private string m_datFile;
        private string m_bkFile;
        private List<string> m_runways;
        private List<SID> m_sids;
        private string m_rwyArr;
        private string m_rwyDep;
        private List<string> m_presetTaxiTo = null;
        private List<string> m_presetStand = null;
        private List<string> m_presetSid = null;
        private List<string> m_presetStar = null;
        private List<string> m_presetObstSymb = null;
        private List<LocalEFSData> m_presetLocalEFS = null;


        public string RwyArr { set { m_rwyArr = value; } get { return m_rwyArr; } }
        public string RwyDep { set { m_rwyDep = value; } get { return m_rwyDep; } }
        public List<string> Runways { get { return m_runways; } }
        public List<SID> SIDs { get { return m_sids; } }
        public string Airfield { get { return m_lotnisko; } }
        public string BkFile { get { return m_bkFile; } set { this.m_bkFile = value; } }
        public List<string> PresetTaxiTo { get { return m_presetTaxiTo; } }
        public List<string> PresetStand { get { return m_presetStand; } }
        public List<string> PresetSid { get { return m_presetSid; } }
        public List<string> PresetStar { get { return m_presetStar; } }
        public List<string> PresetObstSymb { get { return m_presetObstSymb; } }
        public List<LocalEFSData> PresetLocalEFS { get { return m_presetLocalEFS; } }

        private List<FlightPlan> m_planyLotu = new List<FlightPlan>();
        
        //czas startu z naglowka pliku .dax
        private DateTime m_czasStartu;
        private string m_lotnisko;

        public string ATIS
        {
            get { return m_atis; }
            set
            {
                if (value.Length != 1)
                    m_atis = "A";
                else m_atis = value;
            }
        }

        public List<FlightPlan> PlanyLotu
        {
            get { return m_planyLotu; }
        }

        public string Lotnisko
        {
            get { return m_lotnisko; }
            set { this.m_lotnisko = value; }
        }

        public DateTime CzasStartu
        {
            get { return m_czasStartu; }
        }

        public FlightPlan GetFlightPlan(string callsign)
        {
            FlightPlan returnValue = null;

            foreach (FlightPlan fpl in m_planyLotu)
                if (fpl.Callsign == callsign)
                    returnValue = fpl;

            return returnValue;
        }

        /// <summary>
        /// podstawowy konstruktor, tworzy kolekcje obiektow PlanLotu na podstawie zawartosci pliku .dax
        /// </summary>
        /// <param name="zawartoscPliku"></param>
        public Cwiczenie(string nazwaCwiczenia, string zawartoscPlikuCw, string dapFile, string datFile)
        {
            m_nazwaCwiczenia = nazwaCwiczenia;
            m_zawartoscPliku = zawartoscPlikuCw;
            m_dapFile = dapFile;
            m_datFile = datFile;
            

            m_planyLotu = WydzielPlany(m_zawartoscPliku);
            m_lotnisko = OkreslLotnisko(m_zawartoscPliku);

            m_runways = GetRunways(m_lotnisko, datFile);
            m_sids = GetSids(m_lotnisko, datFile);

            

            //ustalam typy planow lotu - arr/dep/over
            foreach (FlightPlan fpl in m_planyLotu)
            {
                if (fpl.ADEP == m_lotnisko)
                    fpl.FltType = FlightPlan.TypLotu.Dep;
                else if (fpl.ADEST == m_lotnisko)
                    fpl.FltType = FlightPlan.TypLotu.Arr;
                else
                    fpl.FltType = FlightPlan.TypLotu.Arr;

                fpl.PrzypiszGodzStartu(m_czasStartu);
                fpl.WakeTurbCat = GetWakeTurbCatByType(fpl.Typ);
                fpl.SIDs = m_sids;
                fpl.Runways = m_runways;
                fpl.DepRwy = Bay.DepRwy;
                fpl.ArrRwy = Bay.ArrRwy;
            }
        }

        private List<SID> GetSids(string m_lotnisko, string datFile)
        {
            List<SID> sids = new List<SID>();
            List<string> chunks = StringParser.DivideFileToChunks(datFile);

            foreach (string str in chunks)
            {
                if (str.Contains("PD ") && str.Contains("AY " + m_lotnisko))
                    sids.Add(new SID(str));
            }

            return sids;
        }

        private List<string> GetRunways(string lotnisko, string datFile)
        {
            List<string> rwys = new List<string>();
            List<string> chunks = StringParser.DivideFileToChunks(datFile);

            foreach (string str in chunks)
            {
                if (str.Contains("AN " + lotnisko) && str.Contains("RU "))
                    rwys.Add(StringParser.FindParamValue(str, "RU"));
            }


            //w niektorych przestrzeniach pasy startowe sie powtarzaja, np TWRRADEPWA, byl 3x pas 29
            //dzieki tej lini usuwam duplikaty i zwracam liste z unikatowymi numerami pasow
            return rwys.Distinct().ToList();
        }

        private string GetWakeTurbCatByType(string acType)
        {
            List<string> chunks = StringParser.DivideFileToChunks(m_dapFile);
            string returnValue = "";
            string[] separator = new string[] { " " };
            //string[] splitResult;

            foreach (string str in chunks)
            {
                if (str.StartsWith("AC " + acType))
                {
                    returnValue = extractWakeTurbCat(str);
                }
            }

            return returnValue;
        }

        private string extractWakeTurbCat(string str)
        {
            string returnValue = "X";
            StringReader sr = new StringReader(str);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("VW"))
                    returnValue = line.Substring(line.Length - 1);
            }
            return returnValue;
        }

        /// <summary>
        /// w pliku z cwiczeniem nigdzie nie jest zapisane lotnisko ktorego to cwiczenie dotyczy. w zwiazku z tym
        /// sam sprawdzam to lotnisko na podstawie czestosci wystepowania kodow lotnisk wystepujacych w planach lotu
        /// 
        /// </summary>
        /// <param name="m_zawartoscPliku"></param>
        /// <returns></returns>
        private string OkreslLotnisko(string zawartoscPliku)
        {
            List<string> lotniska = new List<string>();

            StringReader sr = new StringReader(zawartoscPliku);
            string linia = "";

            while ((linia = sr.ReadLine()) != null)
            {
                if (linia.Length >= 7)
                    if (linia.Substring(0,2) == "DN" || linia.Substring(0,2) == "DP")
                        lotniska.Add(linia.Substring(3,4));
            }

            string lotnisko = WybierzNajczestszeLotnisko(lotniska);

            return lotnisko;
            
        }

        /// <summary>
        /// z listy kodow icao zwraca najczesciej wystepujacy kod
        /// </summary>
        /// <param name="lotniska"></param>
        /// <returns></returns>
        private string WybierzNajczestszeLotnisko(List<string> lotniska)
        {
            //http://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
            var most = (from i in lotniska
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key).First();



            return most.ToString();
        }

        /// <summary>
        /// z pliku .dax z cwiczeniem wybieram fragmenty tekstu stanowiace osobne plany lotu 
        /// i tworze z nich obiekty typu PlanLotu, ktore potem zwracam jako wynik metody
        /// </summary>
        /// <param name="m_zawartoscPliku"></param>
        /// <returns></returns>
        private List<FlightPlan> WydzielPlany(string m_zawartoscPliku)
        {
            List<FlightPlan> tempList = new List<FlightPlan>();
            List<string> tempListString = new List<string>();

            tempListString = podzielStringNaCzesci(m_zawartoscPliku);

            tempList = stworzPlanyLotu(tempListString);

            
            return tempList;
        }

        private List<FlightPlan> stworzPlanyLotu(List<string> tempListString)
        {

            ///////////////////////////////////////////////////////////////////////////////////
            ////
            //// do zrobienia : wyciagnij czas startu cwiczenia  i przypisz do m_czasstartu
            ////
            ///////////////////////////////////////////////////////////////////////////////////
            List<FlightPlan> listTemp = new List<FlightPlan>();

            foreach (string str in tempListString)
            {
                FlightPlan fpl = new FlightPlan(str);
                if (fpl.IsValid)
                    listTemp.Add(new FlightPlan(str));
            }

            return listTemp;
        }

        /// <summary>
        /// dziele zawartosc pliku z cwiczeniem na fragmetny z ktorych nastepnie zostana
        /// wydzielone plany lotu
        /// </summary>
        /// <param name="m_zawartoscPliku"></param>
        /// <returns></returns>
        private List<string> podzielStringNaCzesci(string m_zawartoscPliku)
        {
            string linia;
            string linia2 = "";

            List<string> tempListString = new List<string>();

            StringReader sr = new StringReader(m_zawartoscPliku);

            while ((linia = sr.ReadLine()) != null)
            {
                //wyciagam godzine rozpoczecia cwiczenia
                if (linia.Length > 1 && linia.Substring(0, 2) == "EX")
                    m_czasStartu = GetStartTimeFromString(linia);


                if (linia.Length > 1 && linia.Substring(0, 2) == "FG")
                    continue;

                linia2 += linia + "\n";
                if (linia == "")
                {
                    tempListString.Add(linia2);
                    linia2 = "";
                }

            }

            return tempListString;

        }

        private DateTime GetStartTimeFromString(string linia)
        {
            int godz = int.Parse(linia.Substring(3,2));
            int min = int.Parse(linia.Substring(6,2));

            DateTime godzStart = new DateTime();
            godzStart = godzStart.AddHours(godz);
            godzStart = godzStart.AddMinutes(min);

            return godzStart;

        
        }

        internal void ProcessBkFile(string bkFilePath)
        {
            // UWAGAAAAA!!!!!!!!!!!!!!!
            // !!!!!!!!!!!!!!!!!!!!!!!
            // !!!!!!!!!!!!!!!!!!!!!!!

            //zeby dzialalo jak trzeba w pliku *.bk w ostatniej lini musza byc dwie puste linie!
            // tzn

            // GR STDDEP
            // SD XXX
            // SD XXX
            // <pusta linia>
            // <pusta linia>
            
            // inaczej program pominie ostatni blok w pliku

            //      FORMAT PLIKU:

            // GR STANDS
            // ST 1..
            //
            // GR TAXITO
            // TT A0
            //
            // GR STDDEP
            // SD RH_3000
            //
            // GR STDARR
            // SA N-O-E
            // - TU KONIECZNIE 2 PUSTE LINIE

            // To be continued


            if (bkFilePath != null)
            {
                string bkContent = File.ReadAllText(bkFilePath);

                List<string> chunks = StringParser.DivideFileToChunks(bkContent);
                foreach (string chunk in chunks)
                {
                    if (chunk.StartsWith("GR STANDS"))
                        m_presetStand = GetPresetStands(chunk);
                    else if (chunk.StartsWith("GR TAXITO"))
                        m_presetTaxiTo = GetPresetTaxiTo(chunk);
                    else if (chunk.StartsWith("GR STDDEP"))
                        m_presetSid = GetPresetSid(chunk);
                    else if (chunk.StartsWith("GR STDARR"))
                        m_presetStar = GetPresetStar(chunk);
                    else if (chunk.StartsWith("GR OBSTSYMB"))
                        m_presetObstSymb = GetPresetObstSymb(chunk);
                }



            }
        }

        private List<string> GetPresetObstSymb(string chunk)
        {
            List<string> ret = new List<string>();
            StringReader sr = new StringReader(chunk);
            string line;
            string[] table;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("OS "))
                {
                    table = line.Split(new char[] { ' ' });
                    line = table[table.Length - 1];
                    ret.Add(line);
                }
            }
            if (ret.Count == 0)
                return null;
            else
                return ret;
        }

        private List<string> GetPresetStar(string chunk)
        {
            List<string> ret = new List<string>();
            StringReader sr = new StringReader(chunk);
            string line;
            string[] table;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("SA "))
                {
                    table = line.Split(new char[] { ' ' });
                    line = table[table.Length - 1];
                    ret.Add(line);
                }
            }
            if (ret.Count == 0)
                return null;
            else
                return ret;
        }

        private List<string> GetPresetSid(string chunk)
        {
            List<string> ret = new List<string>();
            StringReader sr = new StringReader(chunk);
            string line;
            string[] table;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("SD "))
                {
                    table = line.Split(new char[] { ' ' });
                    line = table[table.Length - 1];
                    ret.Add(line);
                }
            }
            if (ret.Count == 0)
                return null;
            else
                return ret;
        }

        private List<string> GetPresetTaxiTo(string chunk)
        {
            List<string> ret = new List<string>();
            StringReader sr = new StringReader(chunk);
            string line;
            string[] table;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("TT "))
                {
                    table = line.Split(new char[] { ' ' });
                    line = table[table.Length - 1];
                    ret.Add(line);
                }
            }
            if (ret.Count == 0)
                return null;
            else
                return ret;
        }

        private List<string> GetPresetStands(string chunk)
        {
            List<string> ret = new List<string>();
            StringReader sr = new StringReader(chunk);
            string line;
            string[] table;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("ST "))
                {
                    table = line.Split(new char[] {' '});
                    line = table[table.Length -1];
                    ret.Add(line);
                }
            }
            if (ret.Count == 0)
                return null;
            else
                return ret;
        }
    }
}
