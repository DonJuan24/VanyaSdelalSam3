using System;
using System.IO;

namespace LibMas
{
	public static class Maxim
	{

		static Random _random = new Random();
		public static int[,] Open(string path)
		{
			StreamReader reader = new StreamReader(path);
			int[,] matrix = new int[int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine())];

			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = int.Parse(reader.ReadLine());

			return matrix;
		}

		public static void Save(string path, int[,] matrix)
		{
			StreamWriter writer = new StreamWriter(path);

			writer.WriteLine(matrix.GetLength(0));
			writer.WriteLine(matrix.GetLength(1));

			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					writer.WriteLine(matrix[i, j]);
		}

		public static void Fill(int[,] matrix, int min, int max)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = _random.Next(min, max);
				}
			}
		}

		public static void Clear(int[,] matrix)
		{
			Fill(matrix, 0, 0);
		}
	}
}
