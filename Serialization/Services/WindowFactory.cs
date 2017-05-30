using System.Collections.Generic;
using System.Windows.Controls;
using Serialization.Structure.Instrument;
using Serialization.Structure;
using System.Windows;

namespace Serialization.Services
{
    public class WindowFactory
    {
        private Window window; 

        public virtual void initializeWindowStructure(Window window)
        {
            var mainGrid = new Grid() { Name = "MainGrid" };
           
            mainGrid.RowDefinitions.Add(createRowDefinition(90, mainGrid));
            mainGrid.RowDefinitions.Add(createRowDefinition(10, mainGrid));

            var workGrid = new Grid() { Name = "WorkGrid" };

            workGrid.ColumnDefinitions.Add(createColumnDefinition(50, workGrid));
            workGrid.ColumnDefinitions.Add(createColumnDefinition(50, workGrid));

            var editGrid = new Grid() { Name = "EditGrid" };

            editGrid.ColumnDefinitions.Add(createColumnDefinition());
            editGrid.ColumnDefinitions.Add(createColumnDefinition());

            var listBox = new ListBox() { Name = "ListBox" };

            var buttonsGrid = new Grid() { Name = "ButtonsGrid" };

            workGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            workGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            workGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));
            workGrid.ColumnDefinitions.Add(createColumnDefinition(25, workGrid));

            var addButton = new Button { Name = "AddButton" };
            var serializeButton = new Button { Name = "SerializeButton" };
            var deserializeButton = new Button { Name = "DeserializeButton" };
            var removeButton = new Button { Name = "RemoveButton" };

            Grid.SetColumn(listBox, 1);
            Grid.SetColumn(serializeButton, 1);
            Grid.SetColumn(deserializeButton, 2);
            Grid.SetColumn(removeButton, 3);
            Grid.SetRow(workGrid, 1);

            buttonsGrid.Children.Add(addButton);
            buttonsGrid.Children.Add(serializeButton);
            buttonsGrid.Children.Add(deserializeButton);
            buttonsGrid.Children.Add(removeButton);
            editGrid.Children.Add(listBox);
            workGrid.Children.Add(editGrid);
            workGrid.Children.Add(workGrid);
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
            return createColumnDefinition(parent.Height * percent / 100);
        }


        public virtual void setWindowStyle(Window window)
        {
            
        }

        public virtual void intializeWindowFields()
        {

        }
    }
}
