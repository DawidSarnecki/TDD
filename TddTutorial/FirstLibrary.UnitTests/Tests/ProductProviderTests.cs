using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary.UnitTests.Tests
{
    // ref: https://github.com/Moq/moq4/wiki/Quickstart
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Diagnostics;
    using System.Reflection;

    [TestClass]
    public class ProductProviderTests
    {
        [TestMethod]
        public void WhenPropertiesSet_Pass()
        {
            var mock = new Mock<IProduct>();
            mock.SetupGet(x => x.Name).Returns("name");
            mock.SetupGet(x => x.Price).Returns(15);
            mock.SetupGet(x => x.Unit).Returns("kg");
            mock.SetupGet(x => x.ExpiredDate).Returns(DateTime.Now);
            //mock.SetupAllProperties();
            IProductProvider provider = new ProductProvider(mock.Object);
            PropertyInfo[] properties = provider.GetType().GetProperties();

            foreach (var property in properties)
            {
                Assert.IsInstanceOfType(property.GetValue(provider), property.PropertyType, $"{property.Name}= {property.GetValue(provider)}");
                Assert.IsNotNull(property.GetValue(provider), $"{property.GetValue(provider)}");
            }

            //var program = new Test();
            //PropertyInfo[] properties = program.GetType().GetProperties();
            //foreach (var property in properties)
            //{
            //    Console.WriteLine($"{property.Name}= {property.GetValue(program)}");
            //}
        }
    }
}
