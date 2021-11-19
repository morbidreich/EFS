using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFS
{
    class StringParser
    {
        /// <summary>
        /// przeszukuje string w postaci kilku lini tekstu w poszukiwaniu wartosci parametru param
        /// </summary>
        /// <param name="chunk">string z liniaim tekstu</param>
        /// <param name="param">nazwa paranetru ktorego wartosc szukam</param>
        /// <returns></returns>
        public static string FindParamValue(string chunk, string param)
        {
            string linia;
            string returnValue = "";
            string[] wynik = null;

            StringReader sr = new StringReader(chunk);

            while ((linia = sr.ReadLine()) != null)
            {
                if (linia.Length >= 2)
                {
                    if (linia.Substring(0, 2) == param)
                    {
                        try //probuje podzielic na 2 stringi
                        {
                            wynik = linia.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (wynik.Length >= 2)
                            {
                                returnValue = wynik[1];
                            }
                            else return "????";
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

            }

            return returnValue;
        }
        
        /// <summary>
        /// ze stringu zawierajacego kilka lini tekstu zwracam linie zawierajaca okreslony parametr
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string FindLineByParam(string chunk, string param)
        {
            string line = "";
            
            //string[] wynik = null;

            StringReader sr = new StringReader(chunk);

            while ((line = sr.ReadLine()) != null)
                if (line.StartsWith(param))
                    return line;

            return line;
        }
        public static List<string> DivideFileToChunks(string fileContent)
        {
            List<string> chunks = new List<string>();

            string line;
            string chunk = "";

            StringReader sr = new StringReader(fileContent);

            while ((line = sr.ReadLine()) != null)
            {
                chunk += line + "\n";
                if (line == "")
                {
                    chunks.Add(chunk);
                    chunk = "";
                }
            }

            return chunks;
        }
        public static string FindChunkByParam(string chunk)
        {
            string param = "";

            return param;
        }
        
    }
}
