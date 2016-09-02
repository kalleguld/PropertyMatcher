using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class DesignTimeViewModel : PropertyMatcherViewModel
    {
        public DesignTimeViewModel()
            : this(GetCtorData())
        {

        }

        private DesignTimeViewModel(CtorData cd)
            : base(cd.Inputs, cd.Outputs, cd.Connections)
        {

        }

        private static CtorData GetCtorData()
        {
            var result = new CtorData
            {
                Inputs = new Model.PropertyCollection
                {
                    Name = "Input Data",
                    Properties = new List<Model.Property>
                    {
                        new Model.Property { Name= "Navn", },
                        new Model.Property { Name= "Adresse", },
                        new Model.Property { Name= "Tlf", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                        new Model.Property { Name=" Test Property", },
                    }
                },
                Outputs = new Model.PropertyCollection
                {
                    Name = "B",
                    Properties = new List<Model.Property>
                    {
                        new Model.Property { Name = "Name" },
                        new Model.Property { Name = "Street" },
                        new Model.Property { Name = "Zipcode" },
                        new Model.Property { Name = "Country" },
                        new Model.Property { Name = "Phone" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },
                        new Model.Property { Name = "Test Property" },

                    },
                }
            };

            result.Connections = new List<Model.Connection>
            {
                new Model.Connection(result.Inputs.Properties[0], result.Outputs.Properties[0], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Properties[1], result.Outputs.Properties[1], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Properties[1], result.Outputs.Properties[2], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Properties[1], result.Outputs.Properties[3], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Properties[2], result.Outputs.Properties[4], Model.Connection.Creator.Auto),
            };

            return result;
        }

        private class CtorData
        {
            internal Model.PropertyCollection Inputs;
            internal Model.PropertyCollection Outputs;
            internal IEnumerable<Model.Connection> Connections;
        }
    }
}
