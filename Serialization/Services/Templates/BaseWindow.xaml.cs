using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Structure;

namespace Serialization.Services.Templates
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public Dictionary<ComboBox, Description> fields { get; set; }

        public BaseWindow()
        {
            InitializeComponent();
        }

        public void comboBox_onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fields[sender as ComboBox].Value = (string)e.AddedItems[0];
        }
    }
}
