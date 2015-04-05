using System;
using System.Collections.Generic;
using System.Linq;

namespace OmniSharp.MSBuild
{
    public static class SolutionPicker
    {
        public static string ChooseSolution(Action<string> logInfo,
                                            Action<string> logError,
                                            string path,
                                            IEnumerable<string> solutions)
        {
            switch (solutions.Length)
            {
                case 0:
                    logInfo(string.Format("No solution files found in '{0}'", path));
                    return null;
                case 1:
                    return solutions[0];
                case 2:
                    var unitySolution = solutions.FirstOrDefault(s => s.EndsWith("-csharp.sln"));
                    if (unitySolution != null)
                    {
                        return unitySolution;
                    }
                    logError("Could not determine solution file");
                    return null;
                default:
                    logError("Could not determine solution file");
                    return null;
            }
        }
    }
}