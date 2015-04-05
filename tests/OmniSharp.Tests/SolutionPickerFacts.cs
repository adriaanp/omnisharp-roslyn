using System;
using System.Collections.Generic;
using System.Linq;
using OmniSharp.MSBuild;
using Xunit;

namespace OmniSharp.Tests
{
    public class SolutionPickerFacts
    {
        private string _infoMessage, _errorMessage;
        private Action<string> _logInfo, _logError;

        public SolutionPickerFacts()
        {
            _logError = msg => _infoMessage = msg;
            _logError = msg => _errorMessage = msg;
        }

        [Fact]
        public void SolutionPicker_picks_unity_solution()
        {
            var solutions = new[] { "unity.sln", "unity-csharp.sln" };
            var solution = SolutionPicker.ChooseSolution(_logInfo, _logError, null, solutions);

            Assert.Equal("unity-csharp.sln", solution);
        }

        [Fact]
        public void SolutionPicker_picks_only_solution()
        {
            var solutions = new[] { "unity.sln" };
            var solution = SolutionPicker.ChooseSolution(_logInfo, _logError, null, solutions);

            Assert.Equal("unity.sln", solution);
        }

        [Fact]
        public void SolutionPicker_logs_info_when_no_solutions_found()
        {
            var solutions = Enumerable.Empty<string>();
            var solution = SolutionPicker.ChooseSolution(_logInfo, _logError, null, solutions);

            Assert.Null(solution);
        }
    }
}