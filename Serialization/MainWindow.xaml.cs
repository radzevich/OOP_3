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
            var windowDecorator = new WindowFactory();
            var instrumentViewer = new InstrumentViewer();

            Content = new Grid();
            ((Grid) Content).Children.Add(windowDecorator.GetWindowContent(this, instrumentViewer.GetInstrumentInfo("Electric")));

            InitializeComponent();

            //_windowDecorator.Initialize();
        }

    }
}
