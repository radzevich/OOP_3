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
using Serialization.Structure.Instrument;
using Serialization.Services;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InstrumentFactory instrumentFactory;

        private List<MusicalInstrument> instrumentList;

        private Window window;

        public MainWindow()
        {
            InitializeComponent();

            instrumentFactory = new InstrumentFactory();
            instrumentList = new List<MusicalInstrument>();
        }

        private void addNewInstrument(string name)
        {
            var instrument = instrumentFactory.create(name);

            window = WindowFactory.create(instrument);
        }

        private void addNewInstrument()
        {
            addNewInstrument(instrumentFactory.getInstrumentNameCollection()[0]);
        }

        public void instrumentType_onSelect(object sender, string selectedInstrumentName)
        {
            window.Close();

            addNewInstrument(selectedInstrumentName);
        }
    }
}
