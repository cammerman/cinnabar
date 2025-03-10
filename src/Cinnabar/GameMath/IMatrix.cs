namespace Cinnabar.GameMath;

public interface IMatrix
{
    MatrixOrder Order { get; }
    float this[int column, int row] { get; set; }
}

public interface IMatrix<TMatrix>: IMatrix
    where TMatrix: IMatrix<TMatrix>
{
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
