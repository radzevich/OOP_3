using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Services;
using Microsoft.Win32;
using System;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowDecorator _windowDecorator;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                InitializeStructure();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void InitializeStructure()
        {
            _windowDecorator = new WindowDecorator();
            Content = new Grid();
            (Content as Grid).Children.Add(_windowDecorator.GetWindowStructure(this));
        }

    }
}
