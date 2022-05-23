using System;
using Shop; // !!!
using Marketing; // !!!
using Spectre.Console;

namespace P00.Namespaces_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Area area = new Area(); // or -> Shop.Area area = new Shop.Area();
            Shop.Area.TotalArea = 200;

            Marketing.Ad ad = new Marketing.Ad();
            /// TO DO...
            /// 


            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green bold underline]Number of fruits[/]")
                .CenterLabel()
                .AddItem("Apple", 12, Color.Yellow)
                .AddItem("Orange", 54, Color.Green)
                .AddItem("Banana", 33, Color.Red));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Create the tree
            var root = new Tree("Root");

            // Add some nodes
            var foo = root.AddNode("[yellow]Foo[/]");
            var table = foo.AddNode(new Table()
                .RoundedBorder()
                .AddColumn("First")
                .AddColumn("Second")
                .AddRow("1", "2")
                .AddRow("3", "4")
                .AddRow("5", "6"));

            table.AddNode("[blue]Baz[/]");
            foo.AddNode("Qux");

            var bar = root.AddNode("[yellow]Bar[/]");
            bar.AddNode(new Calendar(2020, 12)
                .AddCalendarEvent(2020, 12, 12)
                .HideHeader());

            // Render the tree
            AnsiConsole.Write(root);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var calendar = new Calendar(2022, 5);
            calendar.Culture("sv-SE");
            AnsiConsole.Write(calendar);
        }
    }
}
