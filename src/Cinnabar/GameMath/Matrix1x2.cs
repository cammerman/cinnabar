// namespace Cinnabar.GameMath;

// public class Matrix1x2 : IMatrix<Matrix1x2, Vector2, Vector1>
// {
//      private float _m11;
//     private float _m21;

//     private Vector2 _row;

//     public float this[int column, int row]
//     {
//         get {
//         ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(column));
//         return _row[row];
//         }
//     }
        
//     float IRowMatrix.this[int column, int row] {
//         get {
//             ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0, nameof(row));
//             return _row[column];
//         }
//     }

//     public MatrixOrder Order => throw new NotImplementedException();

//     public Matrix1x2(
//         float m11,
//         float m21)
//     {
//         _m11 = m11;
//         _m21 = m21;
//     }


//     public static Matrix1x2 Zero()
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Add(Matrix1x2 other)
//     {
//         throw new NotImplementedException();
//     }

//     public Vector1 Column(int column)
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Divide(float scalar)
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Multiply(float scalar)
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Multiply<TOther, TOtherColumnVector>(TOther other)
//         where TOther : IMatrix<TOther, Vector1, TOtherColumnVector>
//         where TOtherColumnVector : IVector<TOtherColumnVector>
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Negate()
//     {
//         throw new NotImplementedException();
//     }

//     public Vector2 Row(int row)
//     {
//         throw new NotImplementedException();
//     }

//     public Matrix1x2 Subtract(Matrix1x2 other)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator +(Matrix1x2 self)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator +(Matrix1x2 self, Matrix1x2 other)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator -(Matrix1x2 self)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator -(Matrix1x2 self, Matrix1x2 other)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator *(Matrix1x2 self, float scalar)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator *(float scalar, Matrix1x2 self)
//     {
//         throw new NotImplementedException();
//     }

//     public static Matrix1x2 operator /(Matrix1x2 self, float scalar)
//     {
//         throw new NotImplementedException();
//     }
// }