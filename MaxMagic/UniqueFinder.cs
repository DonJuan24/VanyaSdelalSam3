namespace Lib_8
{
	public static class UniqueFinder
	{
		public static int FindCountOfColumnsWithUniqueValues(int[,] matrix)
		{
			int count = 0;

			for (int column = 0; column < matrix.GetLength(1); column++)
			{
				bool unique = true;

				for (int row = 0; row < matrix.GetLength(0); row++)
				{
					if (!unique)
						break;

					for (int thisRow = row + 1; thisRow < matrix.GetLength(0); thisRow++)
					{
						if (matrix[row, column] == matrix[thisRow, column])
						{
							unique = false;
							break;
						}
					}
				}

				if (unique)
					count++;
			}

			return count;
		}
	}
}
