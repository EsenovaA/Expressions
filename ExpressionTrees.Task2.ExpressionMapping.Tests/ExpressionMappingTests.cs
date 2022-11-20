using ExpressionTrees.Task2.ExpressionMapping.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTrees.Task2.ExpressionMapping.Tests
{
    [TestClass]
    public class ExpressionMappingTests
    {
        // todo: add as many test methods as you wish, but they should be enough to cover basic scenarios of the mapping generator

        [TestMethod]
        public void TestMethod1()
        {
            var mapGenerator = new MappingGenerator<Foo, Bar>(x =>
                // Mapping setup for different fields 
                new Bar
                {
                    NumberInString = x.Number.ToString()
                }
            );
            var mapper = mapGenerator.Generate();

            var res = mapper.Map(new Foo
            {
                Id = 1,
                Number = 100
            });

            Assert.IsNotNull(res);
            Assert.AreEqual(1, res.Id);
            Assert.AreEqual(100.ToString(), res.NumberInString);
        }
    }
}
