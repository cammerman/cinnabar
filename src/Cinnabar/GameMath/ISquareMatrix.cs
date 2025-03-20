namespace Cinnabar.GameMath;

public interface ISquareMatrix<TVector>
    where TVector: IVector<TVector>
{
    public abstract static IMatrix<TVector, TVector> Identity();
}
