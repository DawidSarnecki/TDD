
namespace FirstLibrary.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //ref: https://dariuszwozniak.net/2013/06/30/kurs-tdd-czesc-4-nasz-pierwszy-test-jednostkowy/

    [TestClass]
    public class CalcTests
    {
        private Calc _calc;
        
        [TestInitialize]
        public void Setup()
        {
            // arange - using TestInitialize atribute Setup() is called once before test methods.
            _calc = new Calc();
        }

        [TestMethod]
        public void AddsTwoNumbers_Calculated()
        {
            // act
            int result = _calc.Add(2, 2);
            // assert
            Assert.AreEqual(4, result);

            // the same shortly
            Assert.AreEqual(-1, _calc.Add(5, -6));
            Assert.AreEqual(0, _calc.Add(-20, 20));
        }

        [DataTestMethod]
        [DataRow(5,- 6, -1)]
        [DataRow(-20, 20, 0)]
        [DataRow(0, 0, 0)]
        public void AddsTwoNumbers_CalculatedUsingDataRow(int a, int b, int result)
        {
            Assert.AreEqual(result, _calc.Add(a, b));
        }
    }
}
