
namespace FirstLibrary.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //ref: https://dariuszwozniak.net/2013/06/30/kurs-tdd-czesc-4-nasz-pierwszy-test-jednostkowy/

    [TestClass]
    public class Calc_Tests
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
    }
}
