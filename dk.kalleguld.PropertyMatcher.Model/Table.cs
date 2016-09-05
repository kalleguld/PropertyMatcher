using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.Model
{
    public class Table
    {
        public string SystemId { get; set; }
        public string SystemDocTypeId { get; set; }
        public string SystemName { get; set; }
        public string SystemDescription { get; set; }
        public string SystemVersion { get; set; }

        public string SystemTableId { get; set; }
        public string TableId { get; set; }
        public string TableUniqueId { get; set; }
        public string TableName { get; set; }
        public string TableDescription { get; set; }


        public List<Field> Fields { get; set; }
    }
}
