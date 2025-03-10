namespace Cinnabar.GameMath;

public class Matrix3x3 :
    IMatrix<Matrix3x3>,
    ITransposableMatrix<Matrix3x3>,
    ISquareMatrix<Matrix3x3>
{
    private static readonly MatrixOrder _order = new MatrixOrder(3, 3);
    
    private readonly Vector3[] _columns = new Vector3[3];

    public MatrixOrder Order => _order;

    public float this[int column, int row]
    {
        get => _columns[column][row]; 
        set => _columns[column][row] = value;
    }

    public Matrix3x3(
        float c00, float c01, float c02, // row 0
        float c10, float c11, float c12, // row 1
        float c20, float c21, float c22) // row 2
    {
        _columns[0] = new Vector3(c00, c10, c20);
        _columns[1] = new Vector3(c01, c11, c21);
        _columns[2] = new Vector3(c02, c12, c22);
    }

    public Matrix3x3(Matrix3x3 other)
    {
        _columns[0] = new Vector3(other.Column(0));
        _columns[1] = new Vector3(other.Column(1));
        _columns[2] = new Vector3(other.Column(2));
    }
    
    public static Matrix3x3 FromColumns(Vector3 column0, Vector3 column1, Vector3 column2)
    {
        return new Matrix3x3(
            column0[0], column1[0], column2[0],
            column0[1], column1[1], column2[1],
            column0[2], column1[2], column2[2]
        );
    }

    public static Matrix3x3 FromRows(Vector3 row0, Vector3 row1, Vector3 row2)
    {
        return new Matrix3x3(
            row0[0], row0[1], row0[2],
            row1[0], row1[1], row1[2],
            row2[0], row2[1], row2[2]
        );
    }

    public Vector3 Column(int column)
    {
        return _columns[column];
    }

    public Vector3 Row(int row)
    {
        return new Vector3(_columns[0][row], _columns[1][row], _columns[2][row]);
    }

    public Matrix3x3 Negate()
    {
        return FromColumns(
            -_columns[0],
            -_columns[1],
            -_columns[2]);
    }

    public Matrix3x3 Add(Matrix3x3 other)
    {
        return FromColumns(
            _columns[0] + other._columns[0],
            _columns[1] + other._columns[1],
            _columns[2] + other._columns[2]);
    }

    public Matrix3x3 Subtract(Matrix3x3 other)
    {
        return FromColumns(
            _columns[0] - other._columns[0],
            _columns[1] - other._columns[1],
            _columns[2] - other._columns[2]);
    }

    public Matrix3x3 Multiply(float scalar)
    {
        return FromColumns(
            scalar * _columns[0],
            scalar * _columns[1],
            scalar * _columns[2]);
    }

    public Matrix3x3 Divide(float scalar)
    {
        return FromColumns(
            _columns[0] / scalar,
            _columns[1] / scalar,
            _columns[2] / scalar);
    }

    public static Matrix3x3 operator +(Matrix3x3 self)
    {
        return new Matrix3x3(self);
    }

    public static Matrix3x3 operator -(Matrix3x3 self)
    {
        return self.Negate();
    }

    public static Matrix3x3 operator +(Matrix3x3 self, Matrix3x3 other)
    {
        return self.Add(other);
    }

    public static Matrix3x3 operator -(Matrix3x3 self, Matrix3x3 other)
    {
        return self.Subtract(other);
    }

    public static Matrix3x3 operator *(Matrix3x3 self, float scalar)
    {
        return self.Multiply(scalar);
    }

    public static Matrix3x3 operator *(float scalar, Matrix3x3 self)
    {
        return self.Multiply(scalar);
    }

    public static Matrix3x3 operator /(Matrix3x3 self, float scalar)
    {
        return self.Divide(scalar);
    }

    public Matrix3x3 Transpose()
    {
        return FromRows(_columns[0], _columns[1], _columns[2]);
    }

    public static Matrix3x3 Zero()
    {
        return new Matrix3x3(
            0, 0, 0,
            0, 0, 0,
            0, 0, 0);
    }

    public static Matrix3x3 Identity()
    {
        return new Matrix3x3(
            1, 0, 0,
            0, 1, 0,
            0, 0, 1
        );
    }
}
