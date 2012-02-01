namespace Violations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static Func<string, IEnumerable<string>> fileEnumerator;

        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                return;
            }

            fileEnumerator = s => Directory.EnumerateFiles(args[0], s, SearchOption.AllDirectories);

            SolutionFileIsNotInAlphabetOrder();
            ProjectFileIsNotInAlphabetOrder();
            ProjectFileThatHaveEmptyItemGroupTags();
            ProjectFileThatHaveExpandedCompileTags();
            SourceFilesThatDoNotEndWithNewLine();
            SourceFilesThatHaveTrailingSpaces();
            SourceFilesThatHaveTabs();
        }

        private static void SolutionFileIsNotInAlphabetOrder()
        {
            Console.WriteLine("Solution order");

            var solutionFiles = fileEnumerator("*.sln");
            var startingMarker = "}\") = \"";
            var endingMarker = "\", \"";

            foreach (var solutionFile in solutionFiles)
            {
                var content = File.ReadAllLines(solutionFile);

                var projectLines = content.Where(l => l.StartsWith("Project(\"{"));
                var projects = projectLines
                    .Select(l => l.Replace(l.Substring(0, l.IndexOf(startingMarker) + startingMarker.Length), String.Empty))
                    .Select(l => l.Substring(0, l.IndexOf(endingMarker)));

                if (!projects.SequenceEqual(projects.OrderBy(p => p)))
                {
                    Console.WriteLine(solutionFile);
                }
            }

            Console.WriteLine();
        }

        private static void ProjectFileIsNotInAlphabetOrder()
        {
            Console.WriteLine("Project order");

            var projectFiles = fileEnumerator("*.csproj");
            var startingMarker = "<Compile Include=\"";
            var endingMarker = "\" ";

            foreach (var projectFile in projectFiles)
            {
                var content = File.ReadAllLines(projectFile);

                var fileLines = content.Where(l => l.TrimStart().StartsWith(startingMarker));
                var files = fileLines
                    .Select(l => l.Replace(l.Substring(0, l.IndexOf(startingMarker) + startingMarker.Length), String.Empty))
                    .Select(l => l.Substring(0, l.IndexOf(endingMarker)))
                    .Select(l => l.Replace("_", "~"));

                if (!files.SequenceEqual(files.OrderBy(f => f, new StringOrdinalComparer())))
                {
                    Console.WriteLine(projectFile);
                    foreach (var tuple in files.Zip(files.OrderBy(f => f, new StringOrdinalComparer()), Tuple.Create))
                    {
                        if (tuple.Item1 != tuple.Item2)
                        {
                            Console.WriteLine(" s  " + tuple.Item1);
                            //Console.WriteLine("  l " + tuple.Item2);
                        }
                    }
                }
            }

            /*
            foreach (var s in new[] { " ", "!", "\"", "\\", "a", "n", "z", "|", "~" }.OrderBy(s => s, new StringOrdinalComparer()))
            {
                Console.WriteLine(s);
            }
            */

            Console.WriteLine();
        }

        private class StringOrdinalComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return String.CompareOrdinal(x, y);
            }
        }

        private static void ProjectFileThatHaveExpandedCompileTags()
        {
            Console.WriteLine("Expaned Compile tags");

            var projectFiles = fileEnumerator("*.csproj");

            foreach (var projectFile in projectFiles)
            {
                var content = File.ReadAllLines(projectFile);
                for (var i = 0; i < content.Length; i++)
                {
                    if (content[i].TrimStart().StartsWith("<Compile") && !content[i].TrimEnd().EndsWith("/>"))
                    {
                        Console.WriteLine(projectFile + ":" + (i + 1));
                    }
                }
            }

            Console.WriteLine();
        }

        private static void ProjectFileThatHaveEmptyItemGroupTags()
        {
            Console.WriteLine("Empty ItemGroup tags");

            var projectFiles = fileEnumerator("*.csproj");

            foreach (var projectFile in projectFiles)
            {
                var content = File.ReadAllLines(projectFile);
                for (var i = 0; i < content.Length; i++)
                {
                    if (content[i].TrimStart().StartsWith("<ItemGroup") && content[i].TrimEnd().EndsWith("/>"))
                    {
                        Console.WriteLine(projectFile + ":" + (i + 1));
                    }
                }
            }

            Console.WriteLine();
        }

        private static void SourceFilesThatDoNotEndWithNewLine()
        {
            Console.WriteLine("No new line at the end of the file");

            var sourceFiles = fileEnumerator("*.cs");

            foreach (var projectFile in sourceFiles)
            {
                var content = File.ReadAllText(projectFile);

                if (!content.EndsWith(Environment.NewLine))
                {
                    Console.WriteLine(projectFile);
                }
            }

            Console.WriteLine();
        }

        private static void SourceFilesThatHaveTrailingSpaces()
        {
            Console.WriteLine("Trailing spaces");

            var sourceFiles = fileEnumerator("*.cs");
            var assemblyInfoSkipLines = new[] { 5, 17, 18, 28, 32 };

            foreach (var projectFile in sourceFiles)
            {
                var content = File.ReadAllLines(projectFile);
                for (var i = 0; i < content.Length; i++)
                {
                    if (content[i].EndsWith(" ") && !(projectFile.EndsWith(@"\Properties\AssemblyInfo.cs") && assemblyInfoSkipLines.Contains(i + 1)))
                    {
                        Console.WriteLine(projectFile + ":" + (i + 1));
                    }
                }
            }

            Console.WriteLine();
        }

        private static void SourceFilesThatHaveTabs()
        {
            Console.WriteLine("Contains tabs");

            var sourceFiles = fileEnumerator("*.cs");

            foreach (var projectFile in sourceFiles)
            {
                var content = File.ReadAllLines(projectFile);
                for (var i = 0; i < content.Length; i++)
                {
                    if (content[i].Contains("\t"))
                    {
                        Console.WriteLine(projectFile + ":" + (i + 1));
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
