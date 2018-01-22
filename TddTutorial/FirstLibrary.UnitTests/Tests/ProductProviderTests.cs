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
        private IProduct _product;
        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IProduct>();
            mock.SetupGet(x => x.Name).Returns("name");
            mock.SetupGet(x => x.Price).Returns(15M);
            mock.SetupGet(x => x.Unit).Returns("kg");
            mock.SetupGet(x => x.ExpiredDate).Returns("2018/01/01");
            _product = mock.Object;
        }

        [TestMethod]
        public void WhenPropertiesReturnsIncorrectValue_Fails()
        {
            IProductProvider provider = new ProductProvider(_product);
            var properties = _product.GetType().GetProperties().Where(x => x.PropertyType.Name != "Mock");

            foreach (var prop in properties)
            {
                var actualValue = provider.GetType().GetProperty(prop.Name)?.GetValue(provider);
                var expectedValue = prop?.GetValue(_product);

                Assert.IsTrue(expectedValue == actualValue, $"{prop.Name}, expectedValue={expectedValue}, actualValue={actualValue}");
                //Assert.IsTrue(object.Equals(expectedValue, actualValue), $"{prop.Name}, expectedValue={expectedValue}, actualValue={actualValue}");
            }
        }

        [TestMethod]
        // is can't work correctly - null value is a default value in some cases 
        // default values in c#: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/default-values-table
        public void WhenPropertiesSet_Pass()
        {
            IProductProvider provider = new ProductProvider(_product);
            PropertyInfo[] properties = provider.GetType().GetProperties();

            //bool hasEmptyProperty = properties.Select(x => x.GetValue(provider)).Any(y => y.IsNullOrEmpty());
            //Assert.IsFalse(hasEmptyProperty);
            //var hasProperty = properties.Select(x => x.GetValue(this, null))
            //                    .Any(y => y != null && !String.IsNullOrWhiteSpace(y.ToString()));
            foreach (var property in properties)
            {
                var defaultValue = property.PropertyType.GetDefaultValue();
                var actualValue = property.GetValue(provider);
                Debug.WriteLine($"{property.Name}, defaultValue={defaultValue}, actualValue={actualValue}");

                Assert.IsTrue(actualValue != defaultValue, $"{property.Name}, defaultValue={defaultValue}, actualValue={actualValue}");
                Assert.IsFalse(actualValue.IsNullOrEmpty(), $"{"IsNullOrEmpty"}={actualValue.IsNullOrEmpty()}");
            }
    }

        /// ref: https://stackoverflow.com/questions/2490244/default-value-of-a-type-at-runtime
        object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
    }

    //ref: https://stackoverflow.com/questions/2490244/default-value-of-a-type-at-runtime
    public static class TypeExtensions
    {
        public static object GetDefaultValue(this Type t)
        {
            if (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                return Activator.CreateInstance(t);
            else
                return null;
        }
    }

    public static class Extensions
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null || String.IsNullOrWhiteSpace(obj.ToString());
        }
    }
}
