    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace P06.Songs_Queue
    {
        class Program
        {
            static void Main(string[] args)
            {
                Queue<string> songs = new Queue<string>
                    (Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

                while (songs.Count() != 0)
                {
                    string command = Console.ReadLine();

                    if (command.StartsWith("Play"))
                    {
                        songs.Dequeue();
                    }
                    else if (command.StartsWith("Add"))
                    {
                        string givenSong = command.Substring(4);

                        if (songs.Contains(givenSong))
                        {
                            Console.WriteLine($"{givenSong} is already contained!");
                            continue;
                        }

                        songs.Enqueue(givenSong);
                    }
                    else if (command.StartsWith("Show"))
                    {
                        Console.WriteLine(string.Join(", ", songs));
                    }
                }

                Console.WriteLine("No more songs!");
            }
        }
    }
