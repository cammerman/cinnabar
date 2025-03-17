using System.Runtime.CompilerServices;

namespace Cinnabar.GameMath;

public interface IMatrix {}

public interface IMatrix<TMatrix, TRowVector, TColumnVector> : IMatrix
    where TMatrix: IMatrix<TMatrix, TRowVector, TColumnVector>
    where TRowVector : IVector<TRowVector>
    where TColumnVector : IVector<TColumnVector>
{
    MatrixOrder Order { get; }
    float this[int column, int row] { get; }

    TColumnVector Column(int column);
    TRowVector Row(int row);

    TMatrix Negate();
    TMatrix Add(TMatrix other);
    TMatrix Subtract(TMatrix other);
    TMatrix Multiply(float scalar);
    TMatrix Divide(float scalar);

    public abstract static TMatrix operator+(TMatrix self);
    public abstract static TMatrix operator-(TMatrix self);
    public abstract static TMatrix operator+(TMatrix self, TMatrix other);
    public abstract static TMatrix operator-(TMatrix self, TMatrix other);
    public abstract static TMatrix operator*(TMatrix self, float scalar);
    public abstract static TMatrix operator*(float scalar, TMatrix self);
    public abstract static TMatrix operator/(TMatrix self, float scalar);

    public abstract static TMatrix Zero();
}
