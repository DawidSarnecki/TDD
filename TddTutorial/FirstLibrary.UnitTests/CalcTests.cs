
namespace FirstLibrary.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //ref: https://dariuszwozniak.net/2013/06/30/kurs-tdd-czesc-4-nasz-pierwszy-test-jednostkowy/

    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void AddsTwoNumbers_Calculated()
        {
            // arange
            var calc = new Calc();
            // act
            int result = calc.Add(2, 2);
            // assert
            Assert.AreEqual(4, result);

            // the same shortly
            Assert.AreEqual(-1, calc.Add(5, -6));
            Assert.AreEqual(0, calc.Add(-20, 20));
        }

        [DataTestMethod]
        [DataRow(5,- 6, -1)]
        [DataRow(-20, 20, 5)]
        [DataRow(0, 0, 1)]
        public void AddsTwoNumbers_CalculatedUsingDataRow(int a, int b, int result)
        {
            var calc = new Calc();
            Assert.AreEqual(result, calc.Add(a, b));
        }
    }
}
