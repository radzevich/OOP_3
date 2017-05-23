using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Serialization.Structure.Instrument;
using Serialization.Services.Templates;
using static Serialization.MainWindow;

namespace Serialization.Services
{
    public class WindowFactory
    {
        public Window create(MusicalInstrument instrument, onTypeSelectEventHandler handler)
        {
            var window = new BaseWindow();
            var controlList = addControlsFromDescription(window.EditField, instrument);

            for (int i = 0; i < controlList.Count; i++)
            {
                window.fields.Add((ComboBox)controlList[i], instrument.description[i]);
            }

            ((ComboBox)controlList[0]).SelectionChanged += new SelectionChangedEventHandler(handler);
            return window;
        }
        

        private List<Control> addControlsFromDescription(Grid grid, MusicalInstrument instrument)
        {
            var editingFields = new List<Control>();
            
            for (int i = 0; i < instrument.description.Count; i++)
            {
                var comboBox = new ComboBox();
                var textBlock = new TextBlock();

                textBlock.Text = instrument.description[i].Name;

                if (instrument.description[i].Value != null)
                {
                    initializeComboBoxFromFile(comboBox, instrument.description[i].LibPath, instrument.description[i].Value);
                }
                else
                {
                    initializeComboBoxFromFile(comboBox, instrument.description[i].LibPath);
                }

                addControlToGrid(grid, comboBox, textBlock);
                editingFields.Add(comboBox);
            }

            return editingFields;
        }


        private void addControlToGrid(Grid grid, Control control, TextBlock text)
        {
            grid.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(text, 0);
            Grid.SetColumn(control, 1);
            Grid.SetRow(text, grid.RowDefinitions.Count - 1);
            Grid.SetRow(control, grid.RowDefinitions.Count - 1);

            grid.Children.Add(text);
            grid.Children.Add(control);            
        }


        private void initializeComboBoxFromFile(ComboBox comboBox, string path)
        {
            var reader = new FileReader();

            foreach (string line in reader.read(path))
            {
                comboBox.Items.Add(line);
            }
        }


        private void initializeComboBoxFromFile(ComboBox comboBox, string path, string selectedItem)
        {
            var reader = new FileReader();

            foreach (string line in reader.read(path))
            {
                comboBox.Items.Add(line);
                if (selectedItem == line)
                {
                    comboBox.SelectedIndex = comboBox.Items.CurrentPosition;
                }
            }
        }
    }
}
