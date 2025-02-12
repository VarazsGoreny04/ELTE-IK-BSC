package linear.algebra;

public class GaussianElimination {
	private int rows;
	private int cols;
	private double[][] matrix;

	public GaussianElimination(int rows, int cols, double[][] matrix) {
		this.rows = rows;
		this.cols = cols;
		this.matrix = matrix;
	}

	public int getRows() {
		return rows;
	}

	public int getCols() {
		return cols;
	}

	public double[][] getMatrix() {
		double[][] copy = new double[rows][cols];
		for (int i = 0; i < rows; ++i) {
			for (int j = 0; j < cols; ++j) {
				copy[i][j] = matrix[i][j];
			}
		}
		return copy;
	}

	private void checkMatrixDimensions(double[][] matrix) {
		if (matrix.length != rows || matrix[0].length != cols)
			throw new IllegalArgumentException();
	}

	public void setMatrix(double[][] matrix) {
		checkMatrixDimensions(matrix);
		rows = matrix.length;
		cols = matrix[0].length;
		for (int i = 0; i < rows; ++i) {
			for (int j = 0; j < cols; ++j) {
				this.matrix[i][j] = matrix[i][j];
			}
		}
	}

	public void rowEchelonForm() {
		int h = 0, k = 0, max;
		while (h < rows && k < cols) {
			max = argMax(h, k);
			if (matrix[max][k] != 0) {
				swapRows(h, max);
				for (int i = h + 1; i < rows; ++i)
					multiplyAndAddRow(i, h, k);
				multiplyRow(h, k);
				++h;
			}
			++k;
		}
	}

	private int argMax(int row, int col) {
		int index = row;
		for (int i = row + 1; i < rows; ++i) {
			if (Math.abs(matrix[i][col]) > Math.abs(matrix[index][col]))
				index = i;
		}
		return index;
	}

	private void swapRows(int row1, int row2) {
		double[] save = matrix[row1];
		matrix[row1] = matrix[row2];
		matrix[row2] = save;
	}

	private void multiplyAndAddRow(int i, int h, int k) {
		double mul = matrix[i][k] / matrix[h][k];
		matrix[i][k] = 0;
		for (int j = k + 1; j < cols; ++j)
			matrix[i][j] -= matrix[h][j] * mul;
	}

	private void multiplyRow(int row, int col) {
		double div = matrix[row][col];
		for (int j = 0; j < cols; ++j)
			matrix[row][j] /= div;
	}

	public void backSubstitution() {
		for (int i = rows - 1; i >= 0; --i) {
			if (matrix[i][i] == 0)
				throw new IllegalArgumentException();
			for (int j = 0; j < i; ++j)
				multiplyAndAddRow(j, i, i);
		}
	}

	public void print() {
		char sign;
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < rows; ++i) {
			sign = 'x';
			for (int j = 0; j < cols - 1; ++j) {
				if (matrix[i][j] >= 0)
					sb.append("+");
				sb.append(matrix[i][j]).append(sign);
				if (sign == 'z')
					sign = 'a';
				else
					++sign;
			}
			sb.append("=").append(matrix[i][cols - 1]).append("\n");
		}
		System.out.print(sb + "\n");
	}
}