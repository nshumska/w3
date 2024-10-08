using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace W3
{
    public partial class MainWindow : Window
    {
        private const int ChessBoardSize = 8;   // Розмір шахової дошки
        private int currentRow = 0;             // Поточний рядок
        private int currentCol = 0;             // Поточний стовпець
        private Border[,] cells = new Border[ChessBoardSize, ChessBoardSize];

        public MainWindow()
        {
            InitializeComponent();
            CreateChessBoard();  // Створюємо дошку
            HighlightCell(currentRow, currentCol);  // Виділяємо початкову клітинку
        }

        private void CreateChessBoard()
        {
            ChessGrid.Children.Clear();

            for (int row = 0; row < ChessBoardSize; row++)
            {
                for (int col = 0; col < ChessBoardSize; col++)
                {
                    Border cell = new Border
                    {
                        Background = (row + col) % 2 == 0 ? Brushes.White : Brushes.Black,
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(0.5),
                    };

                    ChessGrid.Children.Add(cell);
                    cells[row, col] = cell;
                }
            }
        }

        //  для виділення поточної клітинки
        private void HighlightCell(int row, int col)
        {
            // Скидаємо виділення для всіх клітинок
            foreach (var cell in cells)
            {
                cell.BorderBrush = Brushes.Red;
                cell.BorderThickness = new Thickness(0.5);
            }

            // Виділяємо поточну клітинку
            cells[row, col].BorderBrush = Brushes.Blue;  // Робимо рамку cиньою
            cells[row, col].BorderThickness = new Thickness(3);  // Товста рамка
        }

        // Обробка натискання клавіш для навігації
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (currentCol > 0)
                        currentCol--;  //  вліво
                    break;
                case Key.Right:
                    if (currentCol < ChessBoardSize - 1)
                        currentCol++;  //  вправо
                    break;
                case Key.Up:
                    if (currentRow > 0)
                        currentRow--;  //  вгору
                    break;
                case Key.Down:
                    if (currentRow < ChessBoardSize - 1)
                        currentRow++;  //  вниз
                    break;
            }

            // Після переміщення оновлюємо виділення
            HighlightCell(currentRow, currentCol);
        }
    }
}
