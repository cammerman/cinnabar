
using System.Collections;
using System.Collections.ObjectModel;

namespace Cinnabar.GameMath;

public struct Vector1
{
    private float _x;

    public float X {
        get => _x;
        set => _x = value;
    }

    public double Magnitude => X;

    public ReadOnlyCollection<float> Components => new float[] { _x }.AsReadOnly();

    public int Dimension => 1;

    // public float this[int column, int row]
    // {
    //     get
    //     {
    //         if (column is 0 && row is 0)
    //         {
    //             return _x;
    //         }

    //         throw new IndexOutOfRangeException();
    //     }
    //     set
    //     {
    //         if (column is 0 && row is 0)
    //         {
    //             _x = value;
    //             return;
    //         }
            
    //         throw new IndexOutOfRangeException();
    //     }
    // }

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

    public Vector1 Normalize()
    {
        return new Vector1(1);
    }

    public static Vector1 Zero()
    {
        return new Vector1(0);
    }

    public static Vector1 Unit()
    {
        return new Vector1(1);
    }

    // Vector1 IMatrix<Vector1, Vector1>.Column(int column)
    // {
    //     ArgumentOutOfRangeException.ThrowIfNotEqual(column, 0);
    //     return new Vector1(_x);
    // }

    // Vector1 IMatrix<Vector1, Vector1>.Row(int row)
    // {
    //     ArgumentOutOfRangeException.ThrowIfNotEqual(row, 0);
    //     return new Vector1(_x);
    // }

    // IMatrix<Vector1, TOtherRowVector> IMatrix<Vector1, Vector1, Vector1>.Multiply<TOther, TOtherRowVector>(TOther other)
    // {
    //     var otherRowSize = other.Order.Columns;
    //     var otherRow = other.Row(0).Components;

    //     IMatrix<Vector1, TOtherRowVector>? result = otherRowSize switch {
    //         1 => new Vector1(X * otherRow[0]) as IMatrix<Vector1, TOtherRowVector>,
    //         2 => new Vector2(X * otherRow[0], X * otherRow[1]) as IMatrix<Vector1, TOtherRowVector>,
    //         3 => new Vector3(X * otherRow[0], X * otherRow[1], X * otherRow[2]) as IMatrix<Vector1, TOtherRowVector>,
    //         4 => new Vector4(X * otherRow[0], X * otherRow[1], X * otherRow[2], X * otherRow[3]) as IMatrix<Vector1, TOtherRowVector>,
    //         _ => throw new ArgumentException("Unsupported matrix order.", nameof(other))
    //     };

    //     return result!;
    // }

    public static Vector1 operator+(Vector1 self)
    {
        return new Vector1(self.X);
    }

    public static Vector1 operator-(Vector1 self)
    {
        return self.Negate();
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
