using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Structure.Instrument;
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
        private WindowDecorator windowDecorator;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                initializeStructure();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void initializeStructure()
        {
            windowDecorator = new WindowDecorator();
            Content = new Grid();
            (Content as Grid).Children.Add(windowDecorator.getWindowStructure(this));
        }

    }
}
