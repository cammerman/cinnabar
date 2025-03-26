// namespace Cinnabar.GameMath
// {
//     public class Matrix1x1 : IMatrix<Matrix1x1, Vector1, Vector1>, IMatrix<Vector1, Vector1>
//     {
//         private float _m11;

//         public Matrix1x1(float m11)
//         {
//             _m11 = m11;
//         }
//     }

//     public class Matrix2x1 : IMatrix<Matrix2x1, Vector1, Vector2>, IMatrix<Vector1, Vector2>
//     {
//         private float _m11;
//         private float _m21;

//         public Matrix2x1(
//             float m11,
//             float m21)
//         {
//             _m11 = m11;
//             _m21 = m21;
//         }






//         public float this[int column, int row] => throw new NotImplementedException();

//         public MatrixOrder Order => throw new NotImplementedException();

//         public static Matrix2x1 Zero()
//         {
//             throw new NotImplementedException();
//         }

//         public Matrix2x1 Add(Matrix2x1 other)
//         {
//             throw new NotImplementedException();
//         }

//         public Vector2 Column(int column)
//         {
//             throw new NotImplementedException();
//         }

//         public Matrix2x1 Divide(float scalar)
//         {
//             throw new NotImplementedException();
//         }

//         public Matrix2x1 Multiply(float scalar)
//         {
//             throw new NotImplementedException();
//         }

//         public IMatrix<Vector2, TOtherRowVector> Multiply<TOther, TOtherRowVector>(TOther other)
//             where TOther : IMatrix<TOther, TOtherRowVector, Vector1>
//             where TOtherRowVector : IVector<TOtherRowVector>
//         {
//             throw new NotImplementedException();
//         }

//         public Matrix2x1 Negate()
//         {
//             throw new NotImplementedException();
//         }

//         public Vector1 Row(int row)
//         {
//             throw new NotImplementedException();
//         }

//         public Matrix2x1 Subtract(Matrix2x1 other)
//         {
//             throw new NotImplementedException();
//         }

//         Vector1 IMatrix<Vector1, Vector2>.Column(int column)
//         {
//             throw new NotImplementedException();
//         }

//         Vector2 IMatrix<Vector1, Vector2>.Row(int row)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator +(Matrix2x1 self)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator +(Matrix2x1 self, Matrix2x1 other)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator -(Matrix2x1 self)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator -(Matrix2x1 self, Matrix2x1 other)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator *(Matrix2x1 self, float scalar)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator *(float scalar, Matrix2x1 self)
//         {
//             throw new NotImplementedException();
//         }

//         public static Matrix2x1 operator /(Matrix2x1 self, float scalar)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }