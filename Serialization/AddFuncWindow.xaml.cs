using PluginInterface;
using Serialization.Configs;
using Serialization.Services;
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
using System.Windows.Shapes;
using Serialization;
using Services;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для AddFuncWindow.xaml
    /// </summary>
    public partial class AddFuncWindow : Window
    {
        private Formatter _to;
        private Formatter _from;

        public AddFuncWindow(ref Formatter handlerTo, ref Formatter handlerFrom)
        {
            InitializeComponent();
            _to = handlerTo;
            _from = handlerFrom;
        }

        private void initialize()
        {
            var config = new PluginConfig();
            var pluginNames = config.GetNames(typeof(IFuntionalPlugin).Name);

            foreach (var name in pluginNames)
            {
                Selector.Items.Add(name);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var path = GetPathToLoad();

            if (path.Length > 0)
            {
                var pluginManager = new PluginManager(path);
                pluginManager.GetNewFunctionality(ref _to, ref _from);
            }
            this.Close();
        }

        public void AddWindow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pluginConfig = new PluginConfig();
            var plugunManager = new PluginManager(pluginConfig.GetPathThroughName(typeof(IFuntionalPlugin).Name, (string)e.AddedItems[0]));

            plugunManager.GetNewFunctionality(ref _to, ref _from);
        }

        private string GetPathToLoad()
        {
            var myDialog = new System.Windows.Forms.OpenFileDialog();
            myDialog.ShowDialog();
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;

            return myDialog.FileName;
        }
    }
}
