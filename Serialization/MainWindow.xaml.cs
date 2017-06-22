using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Services;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using Serialization.Structure.Instruments;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int INVALID_INDEX = -1;

        public delegate void ListChangedEventHandler();
        public event ListChangedEventHandler ListChanged;
        public ListBox ObjectListBox;

        private List<ItemInfo> _instrumentInfo = new List<ItemInfo>();
        private List<MusicalInstrument> _instruments = new List<MusicalInstrument>();
        private int _index = INVALID_INDEX;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                Initialize(null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //Window structure initializtion.
        private void Initialize(string name)
        {
            var windowDecorator = new WindowFactory();
            var instrumentViewer = new InstrumentViewer();

            //Getting instrument class information through it's name.
            //If window haven't been initialized than we use the type of the first instrument in list 
            //because user haven't selected instrument type yet.
            if (name == null)
            {
                _instrumentInfo = instrumentViewer.GetInstrumentInfo(instrumentViewer.GetFirstTypeName());
            }
            //Else we get instrument class info from InstrumentViewer
            else
            {
                _instrumentInfo = instrumentViewer.GetInstrumentInfo(instrumentViewer.GetTypeThrowName(name));

                //Non-negative value means that instrument is already created and some properties 
                //of object might be initialized, that's why we should display it.
                if (_index >= 0)
                {
                    new InstrumentFactory().Initialize(_instrumentInfo, _instruments[_index]);
                }
            }

            _instrumentInfo[0].Value = name;

            //Window structure creating.
            Content = new Grid();
            ((Grid) Content).Children.Add(windowDecorator.GetWindowContent(this, _instrumentInfo));

            OnListChanged();

            //_windowDecorator.Initialize();
        }

        #region Controllers

        //Reinitialize window on instrument type changing.
        public void InstrumentTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];

            //If type of instrument changed than we should create new object 
            //and add it to list but not to change any one.
            _index = INVALID_INDEX;

            if ((string)selectedItem != WindowFactory.AddText)
            {
                Initialize(e.AddedItems[0] as string);
            }
            else
            {
                var pluginManager = new PluginManager(GetPathToLoad());
                pluginManager.AddToHierarchy();
            }
        }

        //Fill object properie on selection changing.
        public void ItemTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];

            if ((string)selectedItem != WindowFactory.AddText)
            {
                var senderName = ((ComboBox) sender).Name;

                foreach (ItemInfo field in _instrumentInfo)
                {
                    if (field.Type == senderName)
                    {
                        field.Value = selectedItem as string;
                        break;
                    }
                }
            }
            else
            {
                var addWindow = new AddItemWindow(new List<string> { _instrumentInfo[0].Type, ((FrameworkElement)sender).Name });

                addWindow.Show();
            }
        }

        public void AddButtonClicked(object sender, EventArgs e)
        {
            AddToList();
        }

        public void RemoveButtonClicked(object sender, EventArgs e)
        {
            RemoveFromList();
        }

        public void SerializeButtonClicked(object sender, EventArgs e)
        {
            Serialize();
        }

        public void DeserializeButtonClicked(object sender, EventArgs e)
        {
            Deserialize();
        }

        protected virtual void OnListChanged()
        {
            ListChanged?.Invoke();
        }

        public void ListBox_ListChanged()
        {
            InitializeListBox();
        }

        public void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ListBox) sender).SelectedIndex;

            if (index >= 0)
            {
                _index = index;
                Initialize((string)e.AddedItems[0]);
            }
        }

        #endregion


        #region Logic

        private void AddToList()
        {
            var instrument = new InstrumentFactory().Create(_instrumentInfo);

            if (_index > 0)
            {
                _instruments[_index] = instrument;
            }
            else
            {
                _instruments.Add(instrument);
            }

            OnListChanged();
        }

        private void RemoveFromList()
        {
            if ((_index >= 0) & (_index < _instruments.Count))
            {
                _instruments?.RemoveAt(_index);

                _index = INVALID_INDEX;

                OnListChanged();
            }
        }

        private void Serialize()
        {
            var serializer = new Serializer();

            serializer.Serialize(_instruments, GetPathToSave());

            OnListChanged();
        }

        private void Deserialize()
        {
            var serializer = new Serializer();

            _instruments = (List<MusicalInstrument>)serializer?.Deserialize(GetPathToLoad());

            OnListChanged();
        }

        private string GetPathToLoad()
        {
            var myDialog = new OpenFileDialog();
            myDialog.ShowDialog();
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            
            return myDialog.FileName;
        }

        private string GetPathToSave()
        {
            using (var saveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveFileDialog.ShowDialog();
                
                return saveFileDialog.FileName;
            }
        }

        private void InitializeListBox()
        {
            ObjectListBox.Items.Clear();
            
            foreach (MusicalInstrument instrument in _instruments)
            {
                ObjectListBox.Items.Add(instrument.Value);
            }
        }

    #endregion

    }
}
