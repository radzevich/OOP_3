using System.Collections.Generic;
using System.Windows.Controls;
using Serialization.Structure;
using System.Windows;
using Serialization.Configs;

namespace Serialization.Services
{
    public class WindowDecorator
    {
        //***************************************************MAIN WINDOW STRUCTURE CREATING**************************************************************\\
        public virtual Grid GetWindowStructure(Window window)
        {
            var mainGrid = new Grid() { Name = "MainGrid", Height = window.Height, Width = window.Width };  
            mainGrid.RowDefinitions.Add(CreateRowDefinition(90, mainGrid));
            mainGrid.RowDefinitions.Add(CreateRowDefinition(10, mainGrid));

            var workGrid = new Grid() { Name = "WorkGrid", Height = mainGrid.RowDefinitions[0].Height.Value, Width = mainGrid.Width };   
            workGrid.ColumnDefinitions.Add(CreateColumnDefinition(50, workGrid));
            workGrid.ColumnDefinitions.Add(CreateColumnDefinition(50, workGrid));

            var editGrid = new Grid() { Name = "EditGrid", Width = workGrid.ColumnDefinitions[0].Width.Value, Height = workGrid.Height };
            editGrid.ColumnDefinitions.Add(CreateColumnDefinition());
            editGrid.ColumnDefinitions.Add(CreateColumnDefinition());

            var listBox = new ListBox() { Name = "ListBox", Width = workGrid.ColumnDefinitions[1].Width.Value, Height = workGrid.Height };
            
            var buttonsGrid = new Grid() { Name = "ButtonsGrid", Height = mainGrid.RowDefinitions[1].Height.Value, Width = mainGrid.Width };
            buttonsGrid.ColumnDefinitions.Add(CreateColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(CreateColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(CreateColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(CreateColumnDefinition(25, workGrid));

            var addButton = new Button { Name = "AddButton" };
            var serializeButton = new Button { Name = "SerializeButton" };
            var deserializeButton = new Button { Name = "DeserializeButton" };
            var removeButton = new Button { Name = "RemoveButton" };

            buttonsGrid.Children.Add(addButton);
            buttonsGrid.Children.Add(serializeButton);
            buttonsGrid.Children.Add(deserializeButton);
            buttonsGrid.Children.Add(removeButton);

            Grid.SetColumn(listBox, 1);
            Grid.SetColumn(serializeButton, 1);
            Grid.SetColumn(deserializeButton, 2);
            Grid.SetColumn(removeButton, 3);
            Grid.SetRow(buttonsGrid, 1);

            mainGrid.Children.Add(buttonsGrid);
            workGrid.Children.Add(listBox);
            workGrid.Children.Add(editGrid);
            mainGrid.Children.Add(workGrid);
            
            return mainGrid;
        }

        protected RowDefinition CreateRowDefinition()
        {
            var rowDefinition = new RowDefinition { Height = GridLength.Auto };


            return rowDefinition;
        }

        protected RowDefinition CreateRowDefinition(double height)
        {
            var rowDefinition = new RowDefinition { Height = new GridLength(height) };

            return rowDefinition;
        }

        protected RowDefinition CreateRowDefinition(double percent, Grid parent)
        {
            return CreateRowDefinition(parent.Height * percent / 100);
        }

        protected ColumnDefinition CreateColumnDefinition()
        {
            var columnDefinition = new ColumnDefinition { Width = GridLength.Auto };

            return columnDefinition;
        }

        protected ColumnDefinition CreateColumnDefinition(double height)
        {
            var columnDefinition = new ColumnDefinition { Width = new GridLength(height) };

            return columnDefinition;
        }

        protected ColumnDefinition CreateColumnDefinition(double percent, Grid parent)
        {
            return CreateColumnDefinition(parent.Width * percent / 100);
        }


        public virtual void SetWindowStyle(Window window)
        {
            
        }

        //***************************************************MAIN WINDOW STRUCTURE CREATING**************************************************************\\

        //***************************************************INITIALIZTION OF WINDOW FIELDS***************************************************************\\

        private void Initialize(string instrumentName)
        {
            var viewer = new InstrumentViewer();
            var header = viewer.GetElementThroughValue(instrumentName);

            var fields = viewer.GetSubnodes(header);


        }

        private ComboBox createMainComboBox()
        {
            
        }
        private void initializeInstrumentSelectField(string name)
        {
            
        }

        private void InitializeComboBox(ComboBox comboBox, Description description)
        {
            
        }
    }
}
