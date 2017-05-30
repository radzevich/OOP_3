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
        private List<MusicalInstrument> instrumentList;
        private InstrumentFactory instrumentFactory;
        private WindowFactory windowFactory;
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
                this.AddButton.Click += new RoutedEventHandler(addButton_onClick);
                this.SerializeButton.Click += new RoutedEventHandler(serializeButton_onClick);
                this.DeserializeButton.Click += new RoutedEventHandler(deserializeButton_onClick);
                this.DeleteButton.Click += new RoutedEventHandler(deleteButton_onClick);
                this.ObjectListBox.SelectionChanged += new SelectionChangedEventHandler(listBox_onSelectionChanged);
            }
            else
            {
                //windowFactory.reinitialize(this, instrument, handler);
            }
        }

        private void addNewInstrument(Window sender)
        {
            addNewInstrument(sender, instrumentFactory.getInstrumentNameCollection()[0]);
        }

        public void comboBox_onTypeSelect(object sender, SelectionChangedEventArgs e)
        {
            addNewInstrument(this, (string)e.AddedItems[0]);
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
            int index = this.ObjectListBox.SelectedIndex;
            instrumentList.RemoveAt(this.ObjectListBox.SelectedIndex);
            listChanged?.Invoke(); 
        }

        public void listBox_onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int index = (sender as ListBox).SelectedIndex;

                //if (index > 0)
                {
                    instrument = instrumentList[(sender as ListBox).SelectedIndex];
                    var handler = new SelectionChangedEventHandler(comboBox_onTypeSelect);
                    //windowFactory.reinitialize(this, instrument, handler);
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
            using (var saveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveFileDialog.ShowDialog();

                return saveFileDialog.FileName;
            }
        }

        public void refreshListBox()
        {
            this.ObjectListBox.Items.Clear();

            foreach (MusicalInstrument instrument in instrumentList)
            {
                this.ObjectListBox.Items.Add(instrument.Value);
            }
        }
    }
}
