// namespace Cinnabar.GameMath;

// public class Matrix2x2:
//     IMatrix<Matrix2x2, Vector2, Vector2>,
//     ITransposableMatrix<Matrix2x2>,
//     ISquareMatrix<Matrix2x2>
// {
//     private static readonly MatrixOrder _order = new MatrixOrder(2, 2);
    
//     private readonly Vector2[] _columns = new Vector2[2];

//     public MatrixOrder Order => _order;

//     public float this[int column, int row] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//     public Matrix2x2(
//         float c00, float c01, // row 0
//         float c10, float c11) // row 1
//     {
//         _columns[0] = new Vector2(c00, c10);
//         _columns[1] = new Vector2(c01, c11);
//     }

//     public Matrix2x2(Matrix2x2 other)
//     {
//         _columns[0] = new Vector2(other.Column(0));
//         _columns[1] = new Vector2(other.Column(1));
//     }
    
//     public static Matrix2x2 FromColumns(Vector2 column0, Vector2 column1)
//     {
//         return new Matrix2x2(
//             column0[0], column1[0],
//             column0[1], column1[1]);
//     }

//     public static Matrix2x2 FromRows(Vector2 row0, Vector2 row1)
//     {
//         return new Matrix2x2(
//             row0[0], row0[1],
//             row1[0], row1[1]);
//     }

//     public Vector2 Column(int column)
//     {
//         return _columns[column];
//     }

//     public Vector2 Row(int row)
//     {
//         return new Vector2(_columns[0][row], _columns[1][row]);
//     }

//     public Matrix2x2 Negate()
//     {
//         return FromColumns(
//             -_columns[0],
//             -_columns[1]);
//     }

//     public Matrix2x2 Add(Matrix2x2 other)
//     {
//         return FromColumns(
//             _columns[0] + other._columns[0],
//             _columns[1] + other._columns[1]);
//     }

//     public Matrix2x2 Subtract(Matrix2x2 other)
//     {
//         return FromColumns(
//             _columns[0] - other._columns[0],
//             _columns[1] - other._columns[1]);
//     }

//     public Matrix2x2 Multiply(float scalar)
//     {
//         return FromColumns(
//             scalar * _columns[0],
//             scalar * _columns[1]);
//     }

//     public Matrix2x2 Divide(float scalar)
//     {
//         return FromColumns(
//             _columns[0] / scalar,
//             _columns[1] / scalar);
//     }

//     public static Matrix2x2 operator +(Matrix2x2 self)
//     {
//         return new Matrix2x2(self);
//     }

//     public static Matrix2x2 operator -(Matrix2x2 self)
//     {
//         return self.Negate();
//     }

//     public static Matrix2x2 operator +(Matrix2x2 self, Matrix2x2 other)
//     {
//         return self.Add(other);
//     }

//     public static Matrix2x2 operator -(Matrix2x2 self, Matrix2x2 other)
//     {
//         return self.Subtract(other);
//     }

//     public static Matrix2x2 operator *(Matrix2x2 self, float scalar)
//     {
//         return self.Multiply(scalar);
//     }

//     public static Matrix2x2 operator *(float scalar, Matrix2x2 self)
//     {
//         return self.Multiply(scalar);
//     }

//     public static Matrix2x2 operator /(Matrix2x2 self, float scalar)
//     {
//         return self.Divide(scalar);
//     }

//     public static Matrix2x2 Zero()
//     {
//         return new Matrix2x2(
//             0, 0,
//             0, 0);
//     }

//     public static Matrix2x2 Identity()
//     {
//         return new Matrix2x2(
//             1, 0,
//             0, 1);
//     }

//     public static Matrix2x2 FromColumns(Vector2[] columns)
//     {
//         return FromColumns(columns[0], columns[1]);
//     }

//     public static Matrix2x2 FromRows(Vector2[] rows)
//     {
//         return FromRows(rows[0], rows[1]);
//     }

//     public Matrix2x2 Transpose()
//     {
//         return FromRows(_columns[0], _columns[1]);
//     }
// }
