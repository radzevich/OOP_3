using System.Collections.Generic;
using System.Windows.Controls;
using Serialization.Structure.Instrument;
using Serialization.Structure;
using System.Windows;

namespace Serialization.Services
{
    public class WindowDecorator
    {
        private Window window; 

        public virtual Grid getWindowStructure(Window window)
        {
            var mainGrid = new Grid() { Name = "MainGrid", Height = window.Height, Width = window.Width };  
            mainGrid.RowDefinitions.Add(createRowDefinition(90, mainGrid));
            mainGrid.RowDefinitions.Add(createRowDefinition(10, mainGrid));

            var workGrid = new Grid() { Name = "WorkGrid", Height = mainGrid.RowDefinitions[0].Height.Value, Width = mainGrid.Width };   
            workGrid.ColumnDefinitions.Add(createColumnDefinition(50, workGrid));
            workGrid.ColumnDefinitions.Add(createColumnDefinition(50, workGrid));

            var editGrid = new Grid() { Name = "EditGrid", Width = workGrid.ColumnDefinitions[0].Width.Value, Height = workGrid.Height };
            editGrid.ColumnDefinitions.Add(createColumnDefinition());
            editGrid.ColumnDefinitions.Add(createColumnDefinition());

            var listBox = new ListBox() { Name = "ListBox", Width = workGrid.ColumnDefinitions[1].Width.Value, Height = workGrid.Height };
            
            var buttonsGrid = new Grid() { Name = "ButtonsGrid", Height = mainGrid.RowDefinitions[1].Height.Value, Width = mainGrid.Width };
            buttonsGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            buttonsGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));

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

        protected RowDefinition createRowDefinition()
        {
            var rowDefinition = new RowDefinition();

            rowDefinition.Height = GridLength.Auto;

            return rowDefinition;
        }

        protected RowDefinition createRowDefinition(double height)
        {
            var rowDefinition = new RowDefinition();

            rowDefinition.Height = new GridLength(height);

            return rowDefinition;
        }

        protected RowDefinition createRowDefinition(double percent, Grid parent)
        {
            return createRowDefinition(parent.Height * percent / 100);
        }

        protected ColumnDefinition createColumnDefinition()
        {
            var columnDefinition = new ColumnDefinition();

            columnDefinition.Width = GridLength.Auto;

            return columnDefinition;
        }

        protected ColumnDefinition createColumnDefinition(double height)
        {
            var columnDefinition = new ColumnDefinition();

            columnDefinition.Width = new GridLength(height);

            return columnDefinition;
        }

        protected ColumnDefinition createColumnDefinition(double percent, Grid parent)
        {
            return createColumnDefinition(parent.Width * percent / 100);
        }


        public virtual void setWindowStyle(Window window)
        {
            
        }

        public virtual void intializeWindowFields()
        {

        }

        public List<ComboBox> getComboBoxList(IDescription item)
        {
            var comboBoxList = new List<ComboBox>();

            foreach (Description description in item.getDescription())
            {
                var comboBox = new ComboBox();
                initializeComboBox(comboBox, description);
                comboBoxList.Add(comboBox);
            }

            return comboBoxList;
        }

        private void initializeComboBox(ComboBox comboBox, Description description)
        {
            
        }
    }
}
