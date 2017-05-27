using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Serialization.Structure.Instrument;
using Serialization.Services.Templates;
using static Serialization.MainWindow;
using Serialization.Structure;

namespace Serialization.Services
{
    public class WindowFactory
    {
        private BaseWindow window;

        public BaseWindow create(MusicalInstrument instrument, SelectionChangedEventHandler handler)
        {
            window = new BaseWindow();

            initialize(window, instrument, handler);
            
            return window;
        }

        public void reinitialize(BaseWindow window, MusicalInstrument instrument, SelectionChangedEventHandler handler)
        {
            this.window = window;

            window.EditField.RowDefinitions.Clear();
            window.EditField.Children.Clear();

            initialize(window, instrument, handler);
        }   
        
        private void initialize(BaseWindow window, MusicalInstrument instrument, SelectionChangedEventHandler handler)
        {
            var controlList = addControlsFromDescription(window.EditField, instrument);

            window.fields = new Dictionary<ComboBox, Description>();

            for (int i = 0; i < controlList.Count; i++)
            {
                window.fields.Add(controlList[i], instrument.getDescription()[i]);
            }

            controlList[0].SelectionChanged += handler;
        }    

        private List<ComboBox> addControlsFromDescription(Grid grid, MusicalInstrument instrument)
        {
            var editingFields = new List<ComboBox>();
            
            for (int i = 0; i < instrument.getDescription().Count; i++)
            {
                var comboBox = new ComboBox();
                var textBlock = new TextBlock();

                textBlock.Text = instrument.getDescription()[i].Name;

                if (instrument.getDescription()[i].Value != null)
                {
                    initializeComboBoxFromFile(comboBox, instrument.getDescription()[i].LibPath, instrument.getDescription()[i].Value);
                }
                else
                {
                    initializeComboBoxFromFile(comboBox, instrument.getDescription()[i].LibPath);
                }

                addControlToGrid(grid, comboBox, textBlock);
                editingFields.Add(comboBox);
            }

            return editingFields;
        }


        private void addControlToGrid(Grid grid, ComboBox comboBox, TextBlock text)
        {
            grid.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(text, 0);
            Grid.SetColumn(comboBox, 1);
            Grid.SetRow(text, grid.RowDefinitions.Count - 1);
            Grid.SetRow(comboBox, grid.RowDefinitions.Count - 1);

            grid.Children.Add(text);
            grid.Children.Add(comboBox);

            grid.Height = grid.RowDefinitions.Count * comboBox.Height + comboBox.Margin.Top * 2;          
        }


        private void initializeComboBoxFromFile(ComboBox comboBox, string path)
        {
            var reader = new FileReader();

            foreach (string line in reader.read(path))
            {
                comboBox.Items.Add(line);
            }
            comboBox.SelectionChanged += new SelectionChangedEventHandler(window.comboBox_onSelectionChanged);
        }


        private void initializeComboBoxFromFile(ComboBox comboBox, string path, string selectedItem)
        {
            var reader = new FileReader();
            var index = 0;

            foreach (string line in reader.read(path))
            {
                comboBox.Items.Add(line);
                if (selectedItem == line)
                {
                    index = comboBox.Items.Count - 1;
                }
            }

            comboBox.SelectedIndex = index;
        }
    }
}
