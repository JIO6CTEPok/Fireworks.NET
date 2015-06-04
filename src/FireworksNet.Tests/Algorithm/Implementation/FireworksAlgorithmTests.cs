using System;
using Xunit;

using FireworksNet.Extensions;
using System.Collections.Generic;
using FireworksNet.Algorithm.Implementation;
using FireworksNet.Problems;
using FireworksNet.Model;
using FireworksNet.StopConditions;

namespace FireworksNet.Tests.Algorithm.Implementation
{
    public class FireworksAlgorithmTests
    {
        private static readonly TestProblem testProblem = getTestProblem();
        private static readonly FireworksAlgorithm fa = getFireworksAlgorithm();
        private static readonly int positiveValue = 29;
        #region TestProblemClass
        public class TestProblem : Problem
        {
            public TestProblem(IList<Dimension> dimensions, IDictionary<Dimension, Range> initialRanges, Func<IDictionary<Dimension, double>, double> targetFunction, ProblemTarget target)
                : base(dimensions, initialRanges, targetFunction, target)
            {

            }
        }
        #endregion
        #region getTestProblem
        private static TestProblem getTestProblem()
        {
            IList<Dimension> dimensions = new List<Dimension>();
            IDictionary<Dimension, Range> initialRanges = new Dictionary<Dimension, Range>();
            Func<IDictionary<Dimension, double>, double> targetFunction =
                new Func<IDictionary<Dimension, double>, double>(
                    (c) =>
                    {
                        return positiveValue;
                    }
                );
            ProblemTarget target = ProblemTarget.Minimum;

            Range range = new Range(0, 1);
            dimensions.Add(new Dimension(range));
            initialRanges.Add(new KeyValuePair<Dimension, Range>(dimensions[0], range));

            var testProblem = new TestProblem(dimensions, initialRanges, targetFunction, target);

            return testProblem;

        }
        #endregion
        #region getFireworksAlgoritm
        private static FireworksAlgorithm getFireworksAlgorithm()
        {
            var testProblem = getTestProblem();           
            var testStopCondition = new CounterStopCondition(1);
            var testFireworksAlgoritmSetting = new FireworksAlgorithmSettings()
                {
                    LocationsNumber = 1,
                    ExplosionSparksNumberModifier = 1,
                    ExplosionSparksNumberLowerBound = 0.04,
                    ExplosionSparksNumberUpperBound = 0.8,
                    ExplosionSparksMaximumAmplitude = 0.5,
                    SpecificSparksNumber = 1,
                    SpecificSparksPerExplosionNumber = 1
                };

            FireworksAlgorithm fa = new FireworksAlgorithm(testProblem, testStopCondition, testFireworksAlgoritmSetting);

            return fa;
        }
        #endregion
        #region FireworksAlgorithmData
        public static IEnumerable<object[]> ProblemFireworksAlgorithmData
        {
            get
            {
                var testProblem = getTestProblem();             
                var testStopCondition = new CounterStopCondition(1);
                var testFireworksAlgoritmSettings = new FireworksAlgorithmSettings();

                return new[] {
                    new object[] { null,        testStopCondition, testFireworksAlgoritmSettings, "problem"},
                    new object[] { testProblem, null,              testFireworksAlgoritmSettings, "stopCondition"},
                    new object[] { testProblem, testStopCondition, null,                          "settings"}

                };
            }
        }

        public static IEnumerable<object[]> FireworksAlgorithmData
        {
            get
            {                
                return new[] {  new object[] { positiveValue, 2}
               };
            }
        }
        #endregion

        [Theory, MemberData("ProblemFireworksAlgorithmData")]
        public void FireworksAlgoritm_NegativeParams_ArgumentNullExceptionThrown(Problem problem,
            IStopCondition stopCondition,
            FireworksAlgorithmSettings settings,
            string expectedParamName)
        {
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() => new FireworksAlgorithm(problem, stopCondition, settings));

            Assert.NotNull(actualException);
            Assert.Equal(expectedParamName, actualException.ParamName);
        }

        [Theory]
        [InlineData(null, "state")]
        public void MakeStep_NegativeParams_ArgumentNullExceptionThrown(AlgorithmState state, string expectedParamName)
        {
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() => getFireworksAlgorithm().MakeStep(state));

            Assert.NotNull(actualException);
            Assert.Equal(expectedParamName, actualException.ParamName);
        }
        [Theory]
        [InlineData(null, "state")]
        public void GetSolution_NegativeParams_ArgumentNullExceptionThrown(AlgorithmState state, string expectedParamName)
        {
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() => getFireworksAlgorithm().GetSolution(state));

            Assert.NotNull(actualException);
            Assert.Equal(expectedParamName, actualException.ParamName);
        }

        [Theory]
        [InlineData(null, "state")]
        public void ShouldStop_NegativeParams_ArgumentNullExceptionThrown(AlgorithmState state, string expectedParamName)
        {
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() => getFireworksAlgorithm().ShouldStop(state));

            Assert.NotNull(actualException);
            Assert.Equal(expectedParamName, actualException.ParamName);
        }
        // TODO: check Algoritm setting
        /*
        [Theory, MemberData("FireworksAlgorithmData")]
        public void Solve_Calculation_PositiveExpected(double expectedValue, int precision)
        {
            double value = getFireworksAlgorithm().Solve().Quality;
            Assert.Equal(expectedValue, value, precision);
        }*/


    }
}
