using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Structure.Instrument;
using Serialization.Services;
using Serialization.Services.Templates;
using Microsoft.Win32;
using System;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MusicalInstrument> instrumentList;
        private InstrumentFactory instrumentFactory;
        private WindowFactory windowFactory;
        private BaseWindow window;
        private MusicalInstrument instrument;

        private delegate void listChangedEventHandler();
        private event listChangedEventHandler listChanged;

        public List<MusicalInstrument> InstrumentList
        {
            get { return instrumentList; }
            set
            {
                instrumentList = value;
                listChanged?.Invoke();
            }
        }

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                instrumentFactory = new InstrumentFactory();
                windowFactory = new WindowFactory();
                instrumentList = new List<MusicalInstrument>();

                listChanged += refreshListBox;

                addNewInstrument(this);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void addNewInstrument(Window sender, string name)
        {
            instrument = instrumentFactory.create(name);
            var handler = new SelectionChangedEventHandler(comboBox_onTypeSelect);

            if (sender == this)
            {
                window = windowFactory.create(instrument, handler);
                sender.Hide();
                window.Show();

                window.AddButton.Click += new RoutedEventHandler(addButton_onClick);
                window.SerializeButton.Click += new RoutedEventHandler(serializeButton_onClick);
                window.DeserializeButton.Click += new RoutedEventHandler(deserializeButton_onClick);
                window.DeleteButton.Click += new RoutedEventHandler(deleteButton_onClick);
                window.ObjectListBox.SelectionChanged += new SelectionChangedEventHandler(listBox_onSelectionChanged);
                window.Closed += new EventHandler(window_onClose); 
            }
            else
            {
                windowFactory.reinitialize(window, instrument, handler);
            }
        }

        private void addNewInstrument(Window sender)
        {
            addNewInstrument(sender, instrumentFactory.getInstrumentNameCollection()[0]);
        }

        public void comboBox_onTypeSelect(object sender, SelectionChangedEventArgs e)
        {
            addNewInstrument(window, (string)e.AddedItems[0]);
        }

        public void addButton_onClick(object sender, RoutedEventArgs e)
        {
            instrumentList.Add(instrument);
            listChanged?.Invoke();
        }

        public void serializeButton_onClick(object sender, RoutedEventArgs e)
        {
            var path = getFolderPath();
            if (path.Length != 0)
            {
                var serializator = new Serializator.Serializator();
                try
                {
                    serializator.Serialize(instrumentList, path);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        public void deleteButton_onClick(object sender, RoutedEventArgs e)
        {
            int index = window.ObjectListBox.SelectedIndex;
            instrumentList.RemoveAt(window.ObjectListBox.SelectedIndex);
            listChanged?.Invoke(); 
        }

        public void listBox_onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int index = (sender as ListBox).SelectedIndex;

                if (index > 0)
                {
                    instrument = instrumentList[(sender as ListBox).SelectedIndex];
                    var handler = new SelectionChangedEventHandler(comboBox_onTypeSelect);
                    windowFactory.reinitialize(window, instrument, handler);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void deserializeButton_onClick(object sender, RoutedEventArgs e)
        {
            var path = getPath();
            if (path.Length != 0)
            {
                var serializator = new Serializator.Serializator();
                try
                {
                    instrumentList = (List<MusicalInstrument>)serializator.Deserialize(path);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            listChanged?.Invoke();
        }

        public void window_onClose(object sender, EventArgs e)
        {
            Close();
        }

        public string getPath()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.ShowDialog();
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;

            return myDialog.FileName;
        }

        public string getFolderPath()
        {
            return "C:\\Users\\Aleksey\\Desktop\\file1.txt";
        }

        public void refreshListBox()
        {
            window.ObjectListBox.Items.Clear();

            foreach (MusicalInstrument instrument in instrumentList)
            {
                window.ObjectListBox.Items.Add(instrument.Value);
            }
        }
    }
}
