using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;
using Lib_8;

namespace Matriсes
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		int[,] matrix;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void FillUp(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(MaxImHeight.Text, out int height) || !int.TryParse(MaxImWidth.Text, out int width) || height <= 0 || width <= 0)
			{
				MessageBox.Show("Данные введены неверно", "Максимальная ошибка");
				return;
			}

			DataTable table = new DataTable();
			DataRow dataRow = table.NewRow();

			matrix = new int[height, width];
			Maxim.Fill(matrix, -10, 9);

			for (int row = 0; row < matrix.GetLength(0); ++row)
			{
				for (int column = 0; column < matrix.GetLength(1); ++column)
				{
					if (row == 0) table.Columns.Add((column + 1).ToString(), typeof(int));
					dataRow[column] = matrix[row, column];
				}

				table.Rows.Add(dataRow);
				dataRow = table.NewRow();
			}

			DataView view = table.DefaultView;
			view.AllowNew = false;
			MaxIm.ItemsSource = view;
		}

		private void Result(object sender, RoutedEventArgs e)
		{
			Count.Text = UniqueFinder.FindCountOfColumnsWithUniqueValues(matrix).ToString();
		}

		private void About(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Иван Сазонов Александрович из ИСП-31 сделал практическую.\n" +
			"Перед ним стояла невероятно сложная задача: ему была дана целочисленная матрица размера M × N, а он должен был найти количество ее столбцов, все элементы которых различны.\n" +
			"И он самостоятельно с этим справился.",
			"Сказ о программе",
			MessageBoxButton.OK,
			MessageBoxImage.Information
			);
		}

		private void Exit(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Максим не старался над этой кнопкой", "", MessageBoxButton.OK, MessageBoxImage.Information);
			Close();
		}
	}
}
