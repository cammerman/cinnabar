
using System.Collections.ObjectModel;

namespace Cinnabar.GameMath;

public struct Vector1: IVector<Vector1>
{
    private float _x;

    public float X {
        get => _x;
        set => _x = value;
    }

    public double Magnitude => X;

    public ReadOnlyCollection<float> Components => new float[] { _x }.AsReadOnly();

    public int Dimension => 1;

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
