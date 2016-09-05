using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Table
    {
        public Table(Model.Table modelTable)
        {
            if (modelTable == null)
                throw new ArgumentNullException(nameof(modelTable));
            ModelTable = modelTable;
        }

        internal Model.Table ModelTable { get; }

        public string SystemId { get { return ModelTable.SystemId; } }
        public string SystemDocTypeId { get { return ModelTable.SystemDocTypeId; } }
        public string SystemName { get { return ModelTable.SystemName; } }
        public string SystemDescription { get { return ModelTable.SystemDescription; } }
        public string SystemVersion { get { return ModelTable.SystemVersion; } }

        public string SystemTableId { get { return ModelTable.SystemTableId; } }
        public string TableId { get { return ModelTable.TableId; } }
        public string TableUniqueId { get { return ModelTable.TableUniqueId; } }
        public string TableName { get { return ModelTable.TableName; } }
        public string TableDescription { get { return ModelTable.TableDescription; } }
    }
}
