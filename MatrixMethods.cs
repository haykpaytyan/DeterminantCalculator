namespace DeterminantCalculator
{
    static class MatrixMethods
    {
        public static double[,] GetMinor(double[,] matrix, int row_i, int column_j = 0) //Get 
        {
            int n = matrix.GetLength(0);
            double[,] minor = new double[n - 1, n - 1];

            // get the minor of the matrix by

            for(int i = 0; i < row_i; ++i)
            {
                for(int j = 0; j < column_j; ++j)
                {
                    minor[i, j] = matrix[i, j];
                }
                for(int k = column_j + 1; k < n; ++k)
                {
                    minor[i, k - 1] = matrix[i, k];
                }
            }

            for (int i = row_i + 1; i < n; ++i)
            {
                for (int j = 0; j < column_j; ++j)
                {
                    minor[i - 1, j] = matrix[i, j];
                }
                for (int k = column_j + 1; k < n; ++k)
                {
                    minor[i - 1, k - 1] = matrix[i, k];
                }
            }

            return minor;
        }

        public static double Determinant(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size <= 0) return 0.0;
            if (size == 1) return matrix[0, 0];
            if (size == 2)
            {
                return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
            }
            if (size == 3) // triangle method
            {
                return (matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] + matrix[0, 2] * matrix[1, 0] * matrix[2, 1]
                       - matrix[2, 0] * matrix[1, 1] * matrix[0, 2] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2] - matrix[0, 0] * matrix[2, 1] * matrix[1, 2]);
            }

            double determinant = 0;

            for (int i = 0; i < size; ++i)
            {
                int sign = ((i + 1 + 1) % 2 == 0) ? 1 : -1;

                determinant += sign * matrix[i, 0] * Determinant(GetMinor(matrix, i, 0));
            }

            return determinant;
        }
    }
}
