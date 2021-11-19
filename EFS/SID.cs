using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFS
{
    [Serializable]
    public class SID
    {
        private string m_sidName;
        private string m_sidRwy;
        private string m_sidAirport;
        private string str;

        public string RWY { get { return m_sidRwy; } }
        public string ProcName { get { return m_sidName; } }
        public string Airport { get { return m_sidAirport; } }


        public SID(string name, string rwy, string airport)
        {
            m_sidName = name;
            m_sidRwy = rwy;
            m_sidAirport = airport;
        }

        public SID(string str)
        {
            m_sidName = StringParser.FindParamValue(str, "PD");

            string[] temp = StringParser.FindLineByParam(str, "AY").Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            m_sidAirport = temp[1];
            m_sidRwy = temp[2];
        }
    }
}
