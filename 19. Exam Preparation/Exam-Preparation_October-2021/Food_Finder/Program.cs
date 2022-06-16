using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            {
                "pear", "flour", "pork", "olive"
            };

            var vowels = new Queue<char>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            var consonants = new Stack<char>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            while (consonants.Count != 0)
            {
                char currVowel = vowels.Dequeue();
                vowels.Enqueue(currVowel);
                char currConsonants = consonants.Pop();

                for (int i = 0; i < words.Count; i++)
                {
                    string currWord = words[i];

                    if (currWord.Contains(currVowel))
                    {
                        int index = currWord.IndexOf(currVowel);
                        currWord = currWord.Remove(index, 1);
                    }
                    if (currWord.Contains(currConsonants))
                    {
                        int index = currWord.IndexOf(currConsonants);
                        currWord = currWord.Remove(index, 1);
                    }

                    words[i] = currWord;
                    if (String.IsNullOrWhiteSpace(words[i]))
                    {
                        words.Remove(words[i]);
                    }
                }
            }

            var createdWords = new List<string>()
            {
                "pear", "flour", "pork", "olive"
            };


            foreach (string word in words)
            {
                foreach (string finalWord in createdWords)
                {
                    // TODO: find correct word 
                }
            }

            Console.WriteLine($"Words found: {createdWords.Count}");
            Console.WriteLine(string.Join("\n", createdWords));
        }
    }
}
