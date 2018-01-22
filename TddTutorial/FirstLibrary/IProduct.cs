using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary
{
    public interface IProduct
    {
        string Name { get; }
        string Unit { get; }
        string ExpiredDate { get; }
        decimal Price { get; }
    }
}
