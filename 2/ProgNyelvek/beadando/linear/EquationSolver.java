package linear;

import linear.algebra.GaussianElimination;

public class EquationSolver {
	public static void main(String[] args) {
		double[][] matrix = stringsToDoubles(args);
		GaussianElimination gauss = new GaussianElimination(matrix.length, matrix[0].length, matrix);

		gauss.print();
		gauss.rowEchelonForm();
		gauss.print();
		gauss.backSubstitution();
		gauss.print();
	}

	public static double[][] stringsToDoubles(String[] array) {
		double[][] doublegauss = new double[array.length][];
		for (int i = 0; i < array.length; ++i) {
			String[] row = array[i].split(",");
			double[] doubleArray = new double[row.length];
			for (int j = 0; j < row.length; ++j)
				doubleArray[j] = Double.parseDouble(row[j]);
			doublegauss[i] = doubleArray;
		}
		return doublegauss;
	}
}
