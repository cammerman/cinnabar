namespace Cinnabar.GameMath;

public interface ISquareMatrix<TMatrix>
    where TMatrix: IMatrix
{
    public abstract static TMatrix Identity();
}
