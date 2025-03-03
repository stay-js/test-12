using System.Diagnostics;
using System.Windows;
using AlakzatJatek_Lib;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Shape = System.Windows.Shapes.Shape;

namespace AlakzatJatek
{
    public partial class MainWindow : Window
    {
        private const int SHAPE_SIZE = 50;
        
        private ShapesGrid _shapesGrid = new();
        private string _filePath = string.Empty;
        
        public MainWindow() => InitializeComponent();

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                FileName = "proba6rossz.txt",
                Filter = "Text fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*"
            };
            
            if (fileDialog.ShowDialog() != true) return;
            
            _filePath = fileDialog.FileName;
            DrawButton.IsEnabled = true;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_filePath)) return;

            try
            {
                _shapesGrid = new ShapesGrid(File.ReadAllText(_filePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A kiválasztott fájl nem megfelelő.: {ex.Message}",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
            DrawGrid();
        }
        
        private void Shape_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Shape { Tag: (int row, int col) }) return;

            int matchCount = _shapesGrid.CountSameShapeOrColor(row, col);
            
            MessageBox.Show(matchCount > 0
                    ? $"{matchCount} alakzat azonos színű vagy formájú."
                    : "Nincs azonos alak és szín a sorban és az oszlopban.", 
                "Eredmény",
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }

        private void DrawGrid()
        {
            SetUpGrid(_shapesGrid.Size);

            for (int i = 0; i < _shapesGrid.Size; i++)
            {
                for (int j = 0; j < _shapesGrid.Size; j++)
                {
                    var item = CreateItem(i, j);
                    
                    Grid.SetRow(item, i);
                    Grid.SetColumn(item, j);
                    ShapesGrid.Children.Add(item);
                }
            }
        }

        private Border CreateItem(int i, int j)
        {
            var item = _shapesGrid.Shapes[i, j];
            var shape = CreateShape(item);
                    
            shape.Fill = new SolidColorBrush(
                Color.FromArgb(item.Color.A, item.Color.R, item.Color.G, item.Color.B));
            
            shape.Tag = (i, j);
            shape.MouseLeftButtonDown += Shape_Click;
  
            var viewbox = new Viewbox
            {
                Width = SHAPE_SIZE,
                Height = SHAPE_SIZE,
                Stretch = Stretch.Uniform,
                Child = shape
            };
  
            return new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Width = 75,
                Height = 75,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Child = viewbox
            };
        }
        
        private static Shape CreateShape(AlakzatJatek_Lib.Shape shape)
        {
            return shape.Type switch
            {
                AlakzatJatek_Lib.Shape.ShapeType.Circle => new Ellipse { Width = SHAPE_SIZE, Height = SHAPE_SIZE },
                AlakzatJatek_Lib.Shape.ShapeType.Square1 => new Rectangle { Width = SHAPE_SIZE, Height = SHAPE_SIZE },
                AlakzatJatek_Lib.Shape.ShapeType.Triangle1 => new Polygon
                {
                    Points =
                    [
                        new Point(0, SHAPE_SIZE),
                        new Point(SHAPE_SIZE / 2.0, 0),
                        new Point(SHAPE_SIZE, SHAPE_SIZE)
                    ]
                },
                AlakzatJatek_Lib.Shape.ShapeType.Ellipse => new Ellipse { Width = SHAPE_SIZE, Height = 30 },
                AlakzatJatek_Lib.Shape.ShapeType.Square2 => new Rectangle
                {
                    Width = SHAPE_SIZE,
                    Height = SHAPE_SIZE,
                    LayoutTransform = new RotateTransform(45, SHAPE_SIZE / 2.0, SHAPE_SIZE / 2.0)
                },
                AlakzatJatek_Lib.Shape.ShapeType.Triangle2 => new Polygon
                {
                    Points =
                    [
                        new Point(0, SHAPE_SIZE),
                        new Point(SHAPE_SIZE / 2.0, 0),
                        new Point(SHAPE_SIZE, SHAPE_SIZE)
                    ],
                    RenderTransform = new RotateTransform(180, SHAPE_SIZE / 2.0, SHAPE_SIZE / 2.0)
                },
                _ => throw new UnreachableException()
            };
        }
        
        private void SetUpGrid(int size)
        {
            ShapesGrid.Children.Clear();
            ShapesGrid.RowDefinitions.Clear();
            ShapesGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < size; i++)
            {
                ShapesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (int i = 0; i < size; i++)
            {
                ShapesGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
        }
    }
}
