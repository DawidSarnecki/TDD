using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary
{
    public class ProductValidator
    {
        public bool ValidateExpiredTime(IProduct product)
        {
            return product.ExpiredDate > DateTime.Now ? true : false;
        }

        public bool ValidatePrice(IProduct product)
        {
            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product.Price > 0 ? true : false;
            
        }
    }
}
