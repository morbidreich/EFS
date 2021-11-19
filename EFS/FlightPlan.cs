using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFS
{
    [Serializable]
    public class FlightPlan
    {
        private string m_flightRules = "IFR";
        private string m_startPos = "";
        private bool m_isValid = false;

        private string m_eobt = "";

        //tymczasowe
        private bool isVfr = false;
        

        public enum TypLotu { Arr, Dep, Overflight }

        public bool IsVfr { get { return isVfr; } }
        public string Callsign { get; set; }
        public string Typ { get; set; }
        public string ADEP { get; set; }
        public string ADEST { get; set; }
        public string ClearedLvl { get; set; }
        public string StartTime { get; set; }
        public string StartPos 
        {
            get { return m_startPos; }
            set
            {
                this.m_startPos = value;
            }
        }
        public string Squawk { get; set; }
        public string TransponderType { get; set; }
        public string RFL { get; set; }
        public string Route { get; set; }
        public string CTOT { get; set; }
        public string KolorListy { get; set; }
        public string ArrStand { get; set; }
        public string WakeTurbCat { get; set; }
        public string Status { get; set; }
        public string FlightRules
        {
            get { return m_flightRules; }
            set { this.m_flightRules = value; }
        }
        public string EOBT { get { return m_eobt; } set { this.m_eobt = value; } }
        public TypLotu FltType { get; set; }
        public List<SID> SIDs { get; set; }
        public List<string> Runways { get; set; }
        public string ArrRwy { get; set; }
        public string DepRwy { get; set; }



        public bool IsValid
        {
            get { return m_isValid; }
        }

        public FlightPlan()
        {
            m_isValid = true;
        }

        public FlightPlan(string str)
        {

            //if (str.Substring(0, 2) == "FP")
            if (str.Contains("FP "))
            {
                Callsign = StringParser.FindParamValue(str, "FP");
                Typ = StringParser.FindParamValue(str, "TY");
                ADEP = StringParser.FindParamValue(str, "DP");
                ADEST = StringParser.FindParamValue(str, "DN");
                ClearedLvl = StringParser.FindParamValue(str, "CL");
                if (ClearedLvl.StartsWith("F"))
                    ClearedLvl = ClearedLvl.Insert(1, "L");
                StartTime = StringParser.FindParamValue(str, "TI");
                StartPos = StringParser.FindParamValue(str, "SP");
                Squawk = StringParser.FindParamValue(str, "SA");
                TransponderType = StringParser.FindParamValue(str, "SF");
                RFL = StringParser.FindParamValue(str, "RQ");
                if (RFL.StartsWith("F"))
                    RFL = RFL.Insert(1, "L");
                Route = StringParser.FindParamValue(str, "RO");
                KolorListy = StringParser.FindParamValue(str, "DC");
                ArrStand = StringParser.FindParamValue(str, "ID");

                //aktywne pasy
                ArrRwy = Bay.ArrRwy;
                DepRwy = Bay.DepRwy;

                //Swistak dopisal w bescie do kazdego lotu w polu freetext kilka info - eobt, slot, status, flightrules jesli vfr.
                //ta dodatkowa linia w pliku .dax zaczyna sie od "CM" i w niej szukam w/w wartosci

                string additionalParameters = StringParser.FindLineByParam(str, "CM");

                if (additionalParameters.Length > 3)
                {
                    CTOT = LookForCTOT(additionalParameters);
                    Status = LookForStatus(additionalParameters);
                    //FlightRules = LookForFlightRules(additionalParameters);
                    EOBT = LookForEOBT(additionalParameters);

                    
                    isVfr = LookForVFR(additionalParameters);
                }

                

                //wszystko wczytane, plan lotu poprawny, mozna wrzucac na paski
                m_isValid = true;
            }

            // tekst do tworzenia planu lotu nie zaczyna sie od liter "FP" wiec albo pojazd, albo inne smieci z pliku .dax
            //nadal tworzymy obiekt, ale oflagowany jako 'nie samolot'

            else m_isValid = false;
        }

        //tymczasowe
        private bool LookForVFR(string additionalParameters)
        {
            bool vfr = false;

            string[] values = additionalParameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains("VFR") || values[i].Contains("vfr"))
                {
                    vfr =  true;
                }
                
            }

            return vfr;
        }

        private string LookForStatus(string additionalParameters)
        {
            string status = "";

            string[] values = additionalParameters.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith("STS"))
                {
                    if (values[i].Length > 4)
                        status = values[i].Substring(4);
                    else
                        status = "";
                }
            }

            return status;
        }

        private string LookForFlightRules(string additionalParameters)
        {
            string status = "";

            string[] values = additionalParameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith("VFR"))
                {
                    status = values[i].Substring(4);
                }
            }

            return status;
        }

        private string LookForEOBT(string additionalParameters)
        {
            string eobt = "";

            string[] values = additionalParameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith("EOBT"))
                {
                    if (values[i].Length == 9)
                        eobt = values[i].Substring(5);
                    else
                        eobt = "";
                }
            }

            return eobt;
        }

        private string LookForCTOT(string additionalParameters)
        {
            string ctot = "";

            string[] values = additionalParameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith("CTOT"))
                {
                    if (values[i].Length == 9)
                        ctot = values[i].Substring(5);
                    else
                        ctot = "";
                }
            }

            return ctot;
        }

        private string znajdzWartosc(string str, string p)
        {
            string linia;
            string[] wynik = null;
            
            StringReader sr = new StringReader(str);
            while ((linia = sr.ReadLine()) != null)
            {
                if (linia.Substring(0, 2) == p)
                {
                    wynik = linia.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (wynik.Length >= 2)
                    {
                        return wynik[1];
                        
                    }
                    else return "????";
                }
            }

            return wynik[1];

        }

        internal void PrzypiszGodzStartu(DateTime m_czasStartu)
        {
            // z plikow besta startowa godzina wczytywana jest w postaci 00:00:00 (h:min:ss)
            // teraz zamieniam postac na 0000 (hhmm) uwzgledniajac czas startu cwiczenia
            DateTime czasTemp = m_czasStartu;
            
            int h0 = czasTemp.Hour;
            int m0 = czasTemp.Minute;

            int dH = int.Parse(this.StartTime.Substring(0, 2));
            int dM = int.Parse(this.StartTime.Substring(3, 2));

            czasTemp = czasTemp.AddHours(dH);
            czasTemp = czasTemp.AddMinutes(dM);

            string strH = czasTemp.Hour.ToString();
            string strM = czasTemp.Minute.ToString();

            if (strH.Length == 1)
                strH = "0" + strH;

            if (strM.Length == 1)
                strM = "0" + strM;

            StartTime =  strH + strM;
        }
    }
}
