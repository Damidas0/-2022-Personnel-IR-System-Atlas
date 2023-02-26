using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace InfoRetrieval.Model
{
    /// <summary>
    /// Index for data stored in files in a ZIP archive
    /// </summary>
    [Serializable]
    public class Index
    {
        public String ZIPName{ get; set; }    
        
        public Dictionary<String, List<int>> index { get; private set; }
        public List<String> mapName { get; private set; }
        private int currentMapIndex;


        //List of too recurent word 
        private int maxRec = 500; 


        //Define a list of filter (wich are list of number (docs)
        public List<List<int>> filters{ get; private set; }
        
        

        public Index()
        {
            this.index = new Dictionary<String, List<int>>();
            this.mapName = new List<String>();
            this.currentMapIndex= -1;
        }

        public Index(String ZIPname) : base()
        {
            this.ZIPName= ZIPname;
        }

        /// <summary>
        /// Index all the files of the current ZIP Archive
        /// </summary>
        public String IndexZip()
        {
            Stopwatch stopwatch = new Stopwatch();

            StreamReader reader= null;
            stopwatch.Start();

            //Mise stop words
            String[] stop_words = File.ReadAllLines(@"..\..\Data\StopWordsFr.txt");

            using (ZipArchive zip = ZipFile.Open("..\\..\\Data\\" + this.ZIPName.ToLower() + "\\" + this.ZIPName.ToLower()+".zip", ZipArchiveMode.Read, Encoding.UTF8))
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if(entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase)){
                        reader = new StreamReader(entry.Open());
                        Indexation(entry.Name, reader.ReadToEnd(), stop_words);
                    }
                }
            stopwatch.Stop();

            return IndexToString(stopwatch.Elapsed);
        }


        //Pattern ou index pour cette fonction? 
        public List<String> resResearch(String query)
        {
            List<List<int>> listResult = searchMult(query);

            List<int> result = new List<int>();

            
            //intersection
            result = intersectRes(listResult, result);
            if (result == null) result = unionRes(listResult, result);

            List<String> stringResult = getNoms(result);
            return stringResult;
        }



        public List<List<int>> searchMult(String query)
        {
            String[] splitQuery = query.Split(' ');
            List<List<int>> listResult = new List<List<int>>();

            foreach (String s in splitQuery)
            {
                List<int> tmp = new List<int>();

                foreach (String key in this.index.Keys)
                {
                    if (key.Contains(Tokenize(s))) listResult.Add(this.index[key]);
                    listResult = listResult.Distinct().ToList();
                }
                listResult.Add(tmp);
            }
            return listResult;
        }


        private List<int> intersectRes(List<List<int>> listResult, List<int> result)
        {
            result = listResult[0];
            foreach (List<int> l in listResult)
            {
                result.AsQueryable().Intersect(l);
            }
            return result;
        }


        private List<int> unionRes(List<List<int>> listResult, List<int> result)
        {
            foreach (List<int> l in listResult)
            {
                result.AddRange(l);
                result = result.Distinct().ToList();
            }
            return result;
        }

        public List<String> recherche(String query)
        {
            String[] splitQuery = query.Split(' ');
            //List<List<int>> listResult = new List<List<int>>();
            List<int> listResult = new List<int>();
            foreach(String s in splitQuery)
            {
                //nouvelle list
                foreach (String key in this.index.Keys)
                {
                    if(key.Contains(Tokenize(s))) listResult.AddRange(this.index[key]);
                    listResult = listResult.Distinct().ToList();
                }
                //TODO : make the research part
            }
            List<int> result= new List<int>();//TODO : make the intersection of the list
                                              //if intersection empty: make the union

            List<String> stringResult = getNoms(result);
            return stringResult;
        }

        public List<String> getNoms(List<int> listMap)
        {
            List<String> listResult = new List<string>();
            foreach(int docCode in listMap)
            {
                listResult.Add(this.mapName[docCode]);
            }
            return listResult;
        }

        

        /// <summary>
        /// Index a file with its content
        /// </summary>
        /// <param name="name">Name of the document being indexed</param>
        /// <param name="text">Content of the document being indexed</param>
        private void Indexation(String name, String text, String[] stop_words)
        {
            //Separator
            char[] separator = {' ', '.', ',', ';', '(', ')', '!', '\'', '<', '>',
                               '{', '}', '[', ']', '/', ':', '\"', '@', '&', '_',
                               '?', '*', '\n', '\r'};

            //Adding the file to the map 
            this.currentMapIndex++;
            this.mapName.Add(name);

            String[] list_text = text.Split(separator);
            List<String> stopWordSpec = new List<string>();

            //Boucle d'application, 
            foreach (String word in list_text) {
                String tokenized_word = Tokenize(word);
                
                if (tokenized_word.Length > 2)
                {
                    //If not a stop word
                    if (!stopWordSpec.Contains(tokenized_word) && !stop_words.Contains(tokenized_word))
                    {
                        //if key exist
                        if (this.index.ContainsKey(tokenized_word)){
                            //check actual list
                            if (this.index[tokenized_word].Count > this.maxRec)
                            {
                                stopWordSpec.Add(tokenized_word);
                                this.index.Remove(tokenized_word);
                            }
                            else
                            {
                                if (!this.index[tokenized_word].Contains(currentMapIndex))
                                {
                                    this.index[tokenized_word].Add(currentMapIndex);
                                }
                            }
                                 
                        }
                        else
                        {
                            List<int> tmp = new List<int>{ currentMapIndex };
                            this.index.Add(tokenized_word, tmp);
                        }
                    }   
                }
            }
        }


        
        /// <summary>
        /// Remove diacritics and lower the word
        /// </summary>
        /// <param name="word">Word to tokenize</param>
        /// <returns>Tokenized (<=> normalized) word</returns>
        private string Tokenize(String word)
        {
            return RemoveDiacritics(word).ToLower();
        }


        /// <summary>
        /// Fonction qui supprime les accents et autres signes diacritiques, source http://www.developpez.net/forums/d286030/dotnet/langages/csharp/supprimer-accents-lettre/
        /// </summary>
        /// <param name="stIn"></param>
        /// <returns></returns>
        private string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        /*public String TestReg()
        {
            //Entrée : 
            String textTest = "Je m'appelle Jérémï @le bg";
            //Indexation("Abc", textTest);
            
            return IndexToString(new TimeSpan());
            
        }*/

        public String IndexToString(TimeSpan elapsedTime)
        {
            String res = "";
            res += this.index.Count() + "\n";
            //res += this.index.ToString() + "\n";
            res += elapsedTime.Hours +":"+elapsedTime.Minutes+":"+elapsedTime.Seconds+"."+elapsedTime.Milliseconds+"\n";
            /*foreach (KeyValuePair<String, List<int>> kvp in index)
            {
                res += String.Format("Key = {0}, Value = {1}", kvp.Key, String.Join(", ", kvp.Value)) + "\n";
            }
            res += mapName[0];*/

            return res;
        }
    }
}


/*
Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Thread.Sleep(5000);
stopwatch.Stop();

TimeSpan ts = stopwatch.Elapsed;

Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);*/