using SearchProductCatalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProductCatalogue.Infrastructure
{
    public interface IDatabase
    {
        void Add(Product product);
    }
}
