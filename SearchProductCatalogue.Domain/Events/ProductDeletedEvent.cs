using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProductCatalogue.Domain.Events
{
    public class ProductDeletedEvent
    {
        public string Id { get; set; }
    }
}
