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
        public delegate void ListChangedEventHandler();
        public event ListChangedEventHandler ListChanged;
        public ListBox ObjectListBox;

        private List<ItemInfo> _itemInfo = new List<ItemInfo>();
        private MusicalInstrument _instrument;
        private List<MusicalInstrument> _instruments = new List<MusicalInstrument>();

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

        private void Initialize(string name)
        {
            var windowDecorator = new WindowFactory();
            var instrumentViewer = new InstrumentViewer();

            if (name != null)
                _itemInfo = instrumentViewer.GetInstrumentInfo(instrumentViewer.GetTypeThrowName(name));
            else
                _itemInfo = instrumentViewer.GetInstrumentInfo(instrumentViewer.GetFirstTypeName());

            _itemInfo[0].Value = name;

            Content = new Grid();
            ((Grid) Content).Children.Add(windowDecorator.GetWindowContent(this, _itemInfo));

            ListChanged();

            //_windowDecorator.Initialize();
        }

        #region Controllers

        //Reinitialize window on instrument type changing.
        public void InstrumentTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];

            if (selectedItem != WindowFactory.AddText)
            {
                Initialize(e.AddedItems[0] as string);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        //Fill object properie on selection changing.
        public void ItemTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];

            if (selectedItem != WindowFactory.AddText)
            {
                var senderName = ((ComboBox) sender).Name;

                foreach (ItemInfo field in _itemInfo)
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
                throw new NotImplementedException();
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

        #endregion


        #region Logic

        private void AddToList()
        {
            var instrument = new InstrumentFactory().Create(_itemInfo);

            _instruments.Add(instrument);
            
            OnListChanged();
        }

        private void RemoveFromList()
        {
            _instruments.Remove(_instrument);

            OnListChanged();
        }

        private void Serialize()
        {
            var serializer = new Serializer();

            serializer?.Serialize(_instruments, GetPathToSave());

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
