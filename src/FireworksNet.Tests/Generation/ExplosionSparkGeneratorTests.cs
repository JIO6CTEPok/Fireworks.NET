using System;
using System.Collections.Generic;
using Xunit;
using FireworksNet.Model;
using FireworksNet.Generation;

namespace FireworksNet.Tests.Generation
{
    public class ExplosionSparkGeneratorTests
    {

        #region TestData
        public static IEnumerable<object[]> ProblemData
        {
            get
            {
                System.Random randomizer = new System.Random();
                var dimensions = new List<Dimension>();

                return new[] {
                    new object[] { null,      randomizer, "dimensions"},
                    new object[] {dimensions, null,       "randomizer" }

                };
            }
        }
        #endregion

        [Theory, MemberData("ProblemData")]
        public void ExplosionSparkGenerator_NegativeParams_ArgumentNullExceptionThrown(IEnumerable<Dimension> dimensions,
            System.Random randomizer,
            string expectedParamName)
        {
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() => new ExplosionSparkGenerator(dimensions, randomizer));
            Assert.NotNull(actualException);
            Assert.Equal(expectedParamName, actualException.ParamName);
        }

    }
}
