using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary
{
    public class ProductProvider : IProductProvider
    {
        private string _providerName;
        private string _name;
        private string _unit;
        private string _expiredDate;
        private decimal _price;


        public ProductProvider(IProduct product)
        {
            _providerName = "provider";
            _name = product.Name;
            _unit = product.Unit;
            _expiredDate = product.ExpiredDate;
            _price = product.Price;
        }

        public string ProviderName => _providerName;

        public string Name => _name;

        public string Unit => _unit;

        public string ExpiredDate => _expiredDate;

        public decimal Price => _price;
    }
}
