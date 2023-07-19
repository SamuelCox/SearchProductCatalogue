using SearchProductCatalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProductCatalogue.Domain.Events
{
    public class ProductAddedEvent
    {
        public Product Product { get; init; }
    }
}
