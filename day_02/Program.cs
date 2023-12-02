using System.Runtime.CompilerServices;
using System.Linq;
using System.Formats.Asn1;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            int part1Ans = Part01();
            int part2Ans = Part02();

            Console.WriteLine("Part 1 Answer: " + part1Ans.ToString());
            Console.WriteLine("Part 2 Answer: " + part2Ans.ToString());

        }
        static int Part01()
        {
            string filePath = "Day02Input.txt";
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
                // Console.WriteLine(id);
                answerSum += id;
            }
            return answerSum;
        }

        static int Part02()
        {
            string filePath = "Day02Input.txt";
            IEnumerable<string> inputList = File.ReadLines(filePath);
            // IEnumerable<string> inputList = ["Game 1: 4 blue, 7 red, 5 green; 3 blue, 4 red, 16 green; 3 red, 11 green"];
            char[] separators = [':', ';', ','];
            Dictionary<int, Dictionary<string, int>> gameDict = new();
            IList<List<string>> gameList = new List<List<string>>();
            IList<string> cubeColours = ["red", "blue", "green"];
        
            int gameID;
            string gameIDString;
            IList<int> answerList = [];
            int answer = 0;
            int answerSum = 0;

            foreach (string game in inputList)
            {
                Dictionary<string, List<int>> colorDict = new();
                List<string> gameResults = game.Split(separators).ToList();
                IList<int> boolList = [];
                IList<int> maxNumberList = [];
                
                gameIDString = gameResults[0].Trim();
                gameID = int.Parse(gameResults[0].Substring(5));

                foreach (string gameResult in gameResults)
                {
                    foreach (string colour in cubeColours)
                    {
                        if (gameResult.Contains(colour))
                        {
                            string[] gameResultSplit = gameResult.Split(' ');
                            int cubeNumber = int.Parse(gameResultSplit[1]);

                            if (colorDict.ContainsKey(colour))
                            {
                                colorDict[colour].Add(cubeNumber);
                            }
                            else
                            {
                                colorDict.Add(colour, [cubeNumber]);
                            }
                        }
                        
                    }
                }

                foreach (string key in colorDict.Keys)
                {
                    List<int> numbers = colorDict[key];
                    int maxNumber = numbers.Max();

                    maxNumberList.Add(maxNumber);
                    
                }

                if (maxNumberList.Count == 3)
                {
                    answer = maxNumberList[0] * maxNumberList[1] * maxNumberList[2];
                    answerList.Add(answer);
                }

            }
            foreach (int number in answerList)
            {
                Console.WriteLine(number);
                answerSum += number;
            }
            return answerSum;
        
        }
    }
}
