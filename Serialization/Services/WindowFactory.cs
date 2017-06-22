using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms.VisualStyles;

namespace Serialization.Services
{
    public class WindowFactory
    {
        #region Constants

        private bool COL = true;
        private bool ROW = false;
        public static string AddText = "добавить..";

        #endregion

        #region WindowStructureCreating

        public virtual Grid GetWindowContent(Window window, List<ItemInfo> itemInfo)
        {
            var parent = (MainWindow) window;

            //Creating of window carcass.
            var mainGrid = CreateGrid(parent, "MainGrid", ROW, new List<int> {80, 20});
            var workGrid = CreateGrid(mainGrid, "WorkGrid", COL, new List<int> { 50, 50 });
            var editGrid = CreateGrid(workGrid, "EditGrid", COL, new List<int> { 20, 30 });
            var buttonsGrid = CreateGrid(mainGrid, "ButtonsGrid", COL, new List<int> { 15, 15, 15, 15 }, 1, 1);

            //Initialization of comboBoxes.
            Initialize(window, editGrid, itemInfo);

            //Creating of listBox for created items displaing.
            var listBox = new ListBox() { Name = "ObjectList", Width = workGrid.ColumnDefinitions[1].Width.Value, Height = workGrid.Height };
            parent.ListChanged += parent.ListBox_ListChanged;
            listBox.SelectionChanged += parent.ListBox_SelectionChanged;
            parent.ObjectListBox = listBox;
            Grid.SetColumn(listBox, 1);

            //Buttons creating.
            var addButton = CreateButton("AddButton", "Сохранить", parent.AddButtonClicked, 0, 0);
            var serializeButton = CreateButton("SerializeButton", "Сериализовать", parent.SerializeButtonClicked, 1, 0);
            var deserializeButton = CreateButton("DeserializeButton", "Десериализовать", parent.DeserializeButtonClicked, 2, 0);
            var removeButton = CreateButton("RemoveButton", "Удалить", parent.RemoveButtonClicked, 3, 0);

            AddChildren(buttonsGrid, new List<FrameworkElement> { addButton, serializeButton, deserializeButton, removeButton });
            AddChildren(mainGrid, new List<FrameworkElement> { workGrid, buttonsGrid });
            AddChildren(workGrid, new List<FrameworkElement> { listBox, editGrid });
            
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

        protected virtual void AddChildren(Grid parent, List<FrameworkElement> childs)
        {
            foreach (FrameworkElement child in childs)
            {
                parent.Children.Add(child);
            }
        }

        public virtual void SetWindowStyle(Window window)
        {
            
        }

        #endregion

        #region WindowInitialization

        public void Initialize(Window window, Grid grid, List<ItemInfo> itemInfo)
        {

            foreach (var field in itemInfo)
            {
                int index = itemInfo.IndexOf(field);

                var comboBox = CreateComboBox(field);
                var label = CreateLabel(field);

                InitializeComboBox(comboBox, field.Items);

                if (index != 0)
                    comboBox.SelectionChanged += ((MainWindow) window).ItemTypeSelectionChanged;
                else
                    comboBox.SelectionChanged += ((MainWindow) window).InstrumentTypeSelectionChanged;
                
                Grid.SetColumn(comboBox, 1);
                Grid.SetColumn(label, 0);
                Grid.SetRow(label, index);
                Grid.SetRow(comboBox, index);

                grid.RowDefinitions.Add(CreateRowDefinition(30));
                grid.Children.Add(label);
                grid.Children.Add(comboBox);
            }
        }

        protected virtual ComboBox CreateComboBox(ItemInfo item)
        {
            var comboBox = new ComboBox
            {
                Name = item.Type,
            };

            if (item.Value != null)
            {
                comboBox.SelectedItem = item.Value;
            }

            return comboBox;
        }

        protected virtual Label CreateLabel(ItemInfo item)
        {
            var label = new Label() { Content = item.Name };

            return label;
        }

        protected virtual Grid CreateGrid(FrameworkElement parent, string name, bool colOrRow, List<int> parts)
        {
            var grid = new Grid { Name = name, Height = parent.Height, Width = parent.Width };

            if (colOrRow)
            {
                foreach (int part in parts)
                {
                    grid.ColumnDefinitions.Add(CreateColumnDefinition(part, grid));
                }
            }
            else
            {
                foreach (int part in parts)
                {
                    grid.RowDefinitions.Add(CreateRowDefinition(part, grid));
                }
            }

            return grid;
        }

        protected virtual Grid CreateGrid(FrameworkElement parent, string name, bool colOrRow, List<int> parts,
            int colPosition, int rowPosition)
        {
            var grid = CreateGrid(parent, name, colOrRow, parts);

            Grid.SetColumn(grid, colPosition);
            Grid.SetRow(grid, rowPosition);

            return grid;
        }

        protected virtual Button CreateButton(string name, string content, RoutedEventHandler handler, int colPosition, int rowPosition)
        {
            var button = new Button { Name = name, Content = content };

            button.Click += handler;

            Grid.SetColumn(button, colPosition);
            Grid.SetRow(button, rowPosition);

            return button;
        }

        private void InitializeComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }

            comboBox.Items.Add(AddText);
        }

        #endregion
    }
}
