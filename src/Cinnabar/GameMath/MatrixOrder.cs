namespace Cinnabar.GameMath;

public struct MatrixOrder
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public MatrixOrder(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}
