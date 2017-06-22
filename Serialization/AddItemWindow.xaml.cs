using System;
using System.Windows;
using Serialization.Services;
using System.Collections.Generic;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private readonly List<string> _path;
        private readonly InstrumentViewer _instrumentViewer;

        public AddItemWindow(List<string> path)
        {
            this._path = path;
            this._instrumentViewer = new InstrumentViewer();

            InitializeComponent();
            this.Title = _instrumentViewer.GetNameThroughPath(_path);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Input.Text))
            {
                addItem(Input.Text);
            }            
        }

        private void AddFromButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addItem(string value)
        {
            var instrumentViewer = new InstrumentViewer();

            instrumentViewer.AddItem(_path, value);

            this.Close();
        }
    }
}
