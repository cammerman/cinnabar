using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Markup;

namespace Cinnabar.GameMath;

public struct Vector2: IVector<Vector2>
{
    private float _x;
    private float _y;
    private double _magnitude;
    private bool _isMagnitudeDirty = true;

    public float X {
        get => _x;
        set {
            _isMagnitudeDirty = value != _x;
            _x = value;
        }
    }

    public float Y {
        get => _y;
        set {
            _isMagnitudeDirty = value != _y;
            _y = value;
        }
    }

    public double Magnitude {
        get {
            if (_isMagnitudeDirty) {
                UpdateMagnitude();
                _isMagnitudeDirty = false;
            }

            return _magnitude;
        }
    }

    public ReadOnlyCollection<float> Components => new float[] { _x, _y }.AsReadOnly();

    public int Dimension => 2;

    public float this[int index]
    {
        get {
            return index switch {
                0 => _x,
                1 => _y,
                _ => throw new IndexOutOfRangeException()
            };
        }
        set {
            if (index == 0) _x = value;
            else if (index == 1) _y = value;
            else throw new IndexOutOfRangeException();
        }
    }

    public Vector2(float x, float y)
    {
        _x = x;
        _y = y;
    }

    public Vector2(Vector2 other)
        :this(other.X, other.Y)
    {}

    private void UpdateMagnitude()
    {
        var square = Math.FusedMultiplyAdd(_x, _x, _y * _y);
        var root = Math.ReciprocalSqrtEstimate(square);
        _magnitude = root * square;
    }

    public Vector2 Add(Vector2 other)
    {
        return new Vector2(
            _x + other.X,
            _y + other.Y);
    }

    public Vector2 Subtract(Vector2 other)
    {
        return new Vector2(
            _x - other.X,
            _y - other.Y);
    }

    public Vector2 Multiply(float scalar)
    {
        return new Vector2(
            _x * scalar,
            _y * scalar);
    }

    public Vector2 Divide(float scalar)
    {
        return new Vector2(
            _x / scalar,
            _y / scalar);
    }

    public static Vector2 operator+(Vector2 self)
    {
        return new Vector2(self.X, self.Y);
    }

    public static Vector2 operator-(Vector2 self)
    {
        return new Vector2(-self.X, -self.Y);
    }

    public static Vector2 operator+(Vector2 self, Vector2 other)
    {
        return self.Add(other);
    }

    public static Vector2 operator-(Vector2 self, Vector2 other)
    {
        return self.Subtract(other);
    }

    public static Vector2 operator*(Vector2 self, float other)
    {
        return self.Multiply(other);
    }

    public static Vector2 operator*(float other, Vector2 self)
    {
        return self.Multiply(other);
    }

    public static Vector2 operator/(Vector2 self, float other)
    {
        return self.Divide(other);
    }
}