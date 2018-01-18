using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary
{
    public interface IProductProvider: IProduct
    {
        string ProviderName { get; }
    }
}
