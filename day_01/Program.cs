﻿using System.Runtime.CompilerServices;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\ttse\adventofcode2023\day_01\Day01Input.txt";
            IEnumerable<string> inputList = File.ReadLines(filePath);
            // IEnumerable<string> inputList = new List<string> {"2fiveshtds4oneightsjg"};
            IList<string> parsedInputList = [];
            IList<int> answerList = [];
            int answerSum = 0;

            Dictionary<string, int> substringToDigit = new()
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

            foreach (string input in inputList)
            {
                Dictionary<string, List<int>> indexDict = new();
                string inputInLoop = input;

                foreach (string key in substringToDigit.Keys)
                {
                    int startIndex = 0;
                    while ((startIndex = input.IndexOf(key, startIndex)) != -1)
                    { 
                        if (!indexDict.ContainsKey(key))
                        {
                            indexDict[key] = new List<int>();
                        }
                        indexDict[key].Add(startIndex);
                        startIndex += key.Length;
                    }
                }

                var sortedIndexDict = indexDict.OrderBy(pair => pair.Value.First()).ToDictionary();
                List<(int, string)> replacements = new List<(int, string)>();
                foreach (KeyValuePair<string, List<int>> pair in indexDict)
                {
                    string keyReplacement = substringToDigit[pair.Key].ToString();
                    foreach (int index in pair.Value)
                    {
                        replacements.Add((index, keyReplacement));
                    }
                }

                // Sort the list in descending order by index
                replacements.Sort((x, y) => y.Item1.CompareTo(x.Item1));

                foreach (var (index, replacement) in replacements)
                {
                    inputInLoop = inputInLoop.Remove(index, replacement.Length).Insert(index, replacement);
                }

                parsedInputList.Add(inputInLoop);
            }

            foreach (string parsedInput in parsedInputList)
            {   
                // Console.WriteLine(parsedInput);
                IList<string> digitList = [];          
                foreach (char c in parsedInput)
                {
                    if (Char.IsDigit(c))
                    {
                        digitList.Add(c.ToString());
                    }
                }
                int answer = int.Parse(digitList[0] + digitList.Last());
                answerList.Add(answer);
            }

            foreach (int answer in answerList)
            {
                answerSum += answer;
            }
            Console.WriteLine(answerSum);
        }
    }
}