
using System.Collections.ObjectModel;

namespace Cinnabar.GameMath;

public struct Vector1: IVector<Vector1>, IMatrix<Vector1, Vector1, Vector1>
{
    private float _x;

    public float X {
        get => _x;
        set => _x = value;
    }

    public double Magnitude => X;

    public ReadOnlyCollection<float> Components => new float[] { _x }.AsReadOnly();

    public int Dimension => 1;

    public MatrixOrder Order => throw new NotImplementedException();

    public float this[int column, int row] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public float this[int index]
    {
        get {
            return index switch {
                0 => _x,
                _ => throw new IndexOutOfRangeException()
            };
        }
        set {
            if (index == 0) _x = value;
            else throw new IndexOutOfRangeException();
        }
    }

    public Vector1(float x)
    {
        _x = x;
    }

    public Vector1(Vector1 other)
        :this(other.X)
    {
    }

    public Vector1 Add(Vector1 other)
    {
        return new Vector1(this._x + other.X);
    }

    public Vector1 Subtract(Vector1 other)
    {
        return new Vector1(this._x - other.X);
    }

    public Vector1 Multiply(float scalar)
    {
        return new Vector1(this._x * scalar);
    }

    public Vector1 Divide(float scalar)
    {
        return new Vector1(this._x / scalar);
    }

    public float Dot(Vector1 other)
    {
        return this.X * other.X;
    }

    public Vector1 Negate()
    {
        return new Vector1(-_x);
    }

    public static Vector1 Zero()
    {
        return new Vector1(0);
    }

    Vector1 IMatrix<Vector1, Vector1, Vector1>.Column(int column)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0);
        return new Vector1(_x);
    }

    Vector1 IMatrix<Vector1, Vector1, Vector1>.Row(int row)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0);
        return new Vector1(_x);
    }

    static Vector1 IMatrix<Vector1, Vector1, Vector1>.FromColumns(Vector1[] columns)
    {
        return new Vector1(columns[0].X);
    }

    static Vector1 IMatrix<Vector1, Vector1, Vector1>.FromRows(Vector1[] rows)
    {
        return new Vector1(rows[0].X);
    }

    public static Vector1 operator+(Vector1 self)
    {
        return new Vector1(self.X);
    }

    public static Vector1 operator-(Vector1 self)
    {
        return new Vector1(-self.X);
    }

    public static Vector1 operator+(Vector1 self, Vector1 other)
    {
        return self.Add(other);
    }

    public static Vector1 operator-(Vector1 self, Vector1 other)
    {
        return self.Subtract(other);
    }

    public static Vector1 operator*(Vector1 self, float other)
    {
        return self.Multiply(other);
    }

    public static Vector1 operator*(float other, Vector1 self)
    {
        return self.Multiply(other);
    }

    public static Vector1 operator/(Vector1 self, float other)
    {
        return self.Divide(other);
    }
}
