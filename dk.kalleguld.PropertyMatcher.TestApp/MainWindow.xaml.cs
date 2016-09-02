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

            var inputProperties = new Model.PropertyCollection<Model.InputProperty>
            {
                Name = "A",
                Properties = new List<Model.InputProperty>
                {
                    new Model.InputProperty { Name= "Navn", },
                    new Model.InputProperty { Name= "Adresse", },
                    new Model.InputProperty { Name= "Tlf", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                    new Model.InputProperty { Name=" Test Property", },
                },
            };

            var outputProperties = new Model.PropertyCollection<Model.OutputProperty>
            {
                Name = "B",
                Properties = new List<Model.OutputProperty>
                {
                    new Model.OutputProperty { Name = "Name", ConnectedTo = new Model.Connection(inputProperties.Properties[0], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Street", ConnectedTo = new Model.Connection(inputProperties.Properties[1], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Zipcode", ConnectedTo = new Model.Connection(inputProperties.Properties[1], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Country", ConnectedTo = new Model.Connection(inputProperties.Properties[1], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Phone", ConnectedTo = new Model.Connection(inputProperties.Properties[2], Model.Connection.Creator.Auto) },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },
                    new Model.OutputProperty { Name = "Test Property", ConnectedTo = null },

                },
            };

            var viewModel = new ViewModel.PropertyMatcherViewModel(inputProperties, outputProperties);

            //var viewModel = new ViewModel.PropertyMatcherViewModel();
            PropertyMatcherView.DataContext = viewModel;
        }
    }
}
