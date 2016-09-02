using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dk.kalleguld.PropertyMatcher.TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var inputProperties = new Model.PropertyCollection
            {
                Name = "A",
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
                },
            };

            var outputProperties = new Model.PropertyCollection
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

            };
            var connections = new List<Model.Connection>
            {
                new Model.Connection(inputProperties.Properties[0], outputProperties.Properties[0], Model.Connection.Creator.Auto),
                new Model.Connection(inputProperties.Properties[1], outputProperties.Properties[1], Model.Connection.Creator.Auto),
                new Model.Connection(inputProperties.Properties[1], outputProperties.Properties[2], Model.Connection.Creator.Auto),
                new Model.Connection(inputProperties.Properties[1], outputProperties.Properties[3], Model.Connection.Creator.Auto),
                new Model.Connection(inputProperties.Properties[2], outputProperties.Properties[4], Model.Connection.Creator.Auto),
            };

            var viewModel = new ViewModel.PropertyMatcherViewModel(inputProperties, outputProperties, connections);

            //var viewModel = new ViewModel.PropertyMatcherViewModel();
            PropertyMatcherView.DataContext = viewModel;
        }
    }
}
