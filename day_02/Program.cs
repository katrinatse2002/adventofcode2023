using System.Runtime.CompilerServices;
using System.Linq;
using System.Formats.Asn1;

namespace Day02
{
    class Program
    {
        static int Part01()
        {
            string filePath = @"C:\Users\ttse\adventofcode2023\day_02\Day02Input.txt";
            IEnumerable<string> inputList = File.ReadLines(filePath);
            // IEnumerable<string> inputList = ["Game 1: 7 red, 5 green; 4 red, 16 green; 3 red, 11 green"];
            char[] separators = [':', ';', ','];
            Dictionary<int, Dictionary<string, int>> gameDict = new();
            IList<List<string>> gameList = new List<List<string>>();
            Dictionary <string, int> cubeDict = new()
                                                {
                                                    {"red", 12},
                                                    {"green", 13},
                                                    {"blue", 14}
                                                };
            int gameID;
            string gameIDString;
            IList<int> answerList = [];
            int answerSum = 0;

            foreach (string game in inputList)
            {
                Dictionary<string, List<int>> colorDict = new();
                List<string> gameResults = game.Split(separators).ToList();
                IList<int> boolList = [];
                
                gameIDString = gameResults[0].Trim();
                gameID = int.Parse(gameResults[0].Substring(5));

                foreach (string gameResult in gameResults)
                {
                    foreach (string key in cubeDict.Keys)
                    {
                        if (gameResult.Contains(key))
                        {
                            string[] gameResultSplit = gameResult.Split(' ');
                            int cubeNumber = int.Parse(gameResultSplit[1]);

                            if (colorDict.ContainsKey(key))
                            {
                                colorDict[key].Add(cubeNumber);
                            }
                            else
                            {
                                colorDict.Add(key, [cubeNumber]);
                            }
                        }
                        
                    }
                }

                foreach (string key in colorDict.Keys)
                {
                    List<int> numbers = colorDict[key];
                    int maxNumber = numbers.Max();

                    if (maxNumber <= cubeDict[key])
                    {
                        
                        boolList.Add(1);
                    }
                    else
                    {
                        boolList.Add(0);                  
                    }

                }

                if (boolList.All(x => x == 1))
                {
                    answerList.Add(gameID);
                }
            }
        foreach (int id in answerList)
        {
            Console.WriteLine(id);
            answerSum += id;
        }
        return answerSum;
        }

        static int Part02()
        {
            
        }
    }
}
