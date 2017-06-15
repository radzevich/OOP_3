using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Services;
using Microsoft.Win32;
using System;
using Serialization.Structure.Instruments;

namespace Serialization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ItemInfo> _itemInfo = new List<ItemInfo>();
        private MusicalInstrument _instrument;
        private List<MusicalInstrument> Instruments = new List<MusicalInstrument>();

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

            Content = new Grid();
            ((Grid) Content).Children.Add(windowDecorator.GetWindowContent(this, _itemInfo));

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
            var serializer = new Serializer();

            serializer.Serialize(Instruments, GetPathToSave());
        }

        public void DeserializeButtonClicked(object sender, EventArgs e)
        {
            var serializer = new Serializer();

            Instruments = (List<MusicalInstrument>) serializer.Deserialize(GetPathToLoad());
        }

        #endregion


        #region Logic

        private void AddToList()
        {
            var instrument = new InstrumentFactory().Create(_itemInfo);

            Instruments.Add(instrument);
        }

        private void RemoveFromList()
        {
            Instruments.Remove(_instrument);
        }

        private void SerializeeFromList()
        {
            Instruments.Remove(_instrument);
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

    #endregion
    }
}
