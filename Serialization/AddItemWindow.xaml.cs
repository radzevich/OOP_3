using System;
using System.Windows;
using Serialization.Services;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private readonly List<string> _path;
        private readonly ComboBox _comboBox;

        public AddItemWindow(ComboBox comboBox, List<string> path)
        {
            var instrumentViewer = new InstrumentViewer();
             
            _path = path;
            _comboBox = comboBox;
            InitializeComponent();
            Title = instrumentViewer.GetNameThroughPath(_path);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Input.Text))
            {
                AddItem(Input.Text);
            }            
        }

        private void AddFromButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = GetPathToLoad();

            if (filePath.Length > 0)
            {
                AddNewContent(filePath);
            }

            this.Close();
        }

        private void AddNewContent(string filePath)
        {
            var pluginManager = new PluginManager(filePath);
            var instrumentViewer = new InstrumentViewer();

            foreach (string item in pluginManager.GetNewContent())
            {
                instrumentViewer.AddItem(_path, item);
            }

            var windowFactory = new WindowFactory();
            windowFactory.ReinitializeComboBox(_comboBox, _path);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItem(string value)
        {
            var instrumentViewer = new InstrumentViewer();

            instrumentViewer.AddItem(_path, value);

            this.Close();
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
