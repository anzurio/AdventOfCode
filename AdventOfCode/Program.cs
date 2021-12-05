using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        private const string PuzzleInputFileExt = ".in";

        static void Main(string[] args)
        {
            using (var output = new ConsoleOutput())
            {
                var assemblies = new List<Assembly>();
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var dlls = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll");
                foreach (var dll in dlls)
                {
                    Assembly.LoadFrom(dll);
                }

                var puzzleSolversTypes = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(assembly => assembly.GetTypes())
                        .Where(type => typeof(ISolver).IsAssignableFrom(type) && !type.IsInterface);

                if (!puzzleSolversTypes.Any())
                {
                    output.Write("No Puzzle Solvers were found.");
                    output.WriteNewLine();
                }
                else
                {
                    SolvePuzzles(output, puzzleSolversTypes);
                }
                output.Write("Press any key to exit.");
            }
            Console.Read();
        }

        private static void SolvePuzzles(ConsoleOutput output, IEnumerable<Type> puzzleSolversTypes)
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
            foreach (var puzzleSolverType in puzzleSolversTypes)
            {
                var filename = files.FirstOrDefault(file => file.ToLower().EndsWith(puzzleSolverType.Name.ToLower() + PuzzleInputFileExt));
                if (filename != null)
                {
                    var puzzleConstructor = puzzleSolverType.GetConstructor(new Type[] { });
                    var puzzle = puzzleConstructor?.Invoke(null) as ISolver;
                    if (puzzle != null)
                    {
                        output.Write($"Puzzle Solver: {puzzleSolverType.Name}");
                        output.WriteNewLine();
                        puzzle.ParseInput(new FileInput(filename));
                        puzzle.Solve(output);
                        output.WriteNewLine();
                    }
                }
                else
                {
                    output.Write($"Puzzle Solver {puzzleSolverType.FullName} was found but no puzzle input.");
                    output.WriteNewLine();
                }
            }
        }
    }
}
