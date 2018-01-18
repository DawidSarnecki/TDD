
namespace FirstLibrary.UnitTests
{
    // ref: https://github.com/Moq/moq4/wiki/Quickstart
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ProductValidatorTests
    {
        [TestMethod]
        public void WhenPriceIsLessThan0_ValidationFails()
        {
            var validator = new ProductValidator();
            var product = new Mock<IProduct>();
            product.Setup(x => x.Price).Returns(-1);

            bool validate = validator.ValidatePrice(product.Object);

            Assert.IsFalse(validate);
        }

        [TestMethod]
        public void WhenPriceIsMoreThan0_ValidationPass()
        {
            var validator = new ProductValidator();
            var product = Mock.Of<IProduct>(x => x.Price == 1);

            bool validate = validator.ValidatePrice(product);

            Assert.IsTrue(validate);
        }

        [TestMethod]
        public void WhenProductIsSetByDefaultValues_ValidationFails()
        {
            var validator = new ProductValidator();
            Mock<IProduct> productMock = new Mock<IProduct>(); //Mock for type T with defoult values;
            IProduct product = productMock.Object; //Object of type T

            bool validate = validator.ValidatePrice(product);

            Assert.IsFalse(validate);
        }
    }
}
