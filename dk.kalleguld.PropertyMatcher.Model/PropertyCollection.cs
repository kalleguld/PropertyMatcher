using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class PropertyCollection<T> where T : Property
    {
        public string Name { get; set; }
        public IList<T> Properties { get; set; }
    }
}
