using System.Collections.ObjectModel;

namespace Cinnabar.GameMath;

public struct Vector3: IVector<Vector3>
{
    private float _x;
    private float _y;
    private float _z;
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

    public float Z {
        get => _z;
        set {
            _isMagnitudeDirty = value != _z;
            _z = value;
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

    public ReadOnlyCollection<float> Components => new float[] { _x, _y, _z }.AsReadOnly();

    public int Dimension => 3;

    public float this[int index]
    {
        get {
            return index switch {
                0 => _x,
                1 => _y,
                2 => _z,
                _ => throw new IndexOutOfRangeException()
            };
        }
        set {
            if (index == 0) _x = value;
            else if (index == 1) _y = value;
            else if (index == 2) _z = value;
            else throw new IndexOutOfRangeException();
        }
    }

    public Vector3(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
        UpdateMagnitude();
    }

    public Vector3(Vector3 other)
        :this(other.X, other.Y, other.Z)
    {}

    private void UpdateMagnitude()
    {
        var firstSquare = Math.FusedMultiplyAdd(_x, _x, _y * _y);
        var squareSum = Math.FusedMultiplyAdd(_z, _z, firstSquare);
        var root = Math.ReciprocalSqrtEstimate(squareSum);
        _magnitude = root * squareSum;
    }

    public Vector3 Add(Vector3 other)
    {
        return new Vector3(
            _x + other.X,
            _y + other.Y,
            _z + other.Z);
    }

    public Vector3 Subtract(Vector3 other)
    {
        return new Vector3(
            _x - other.X,
            _y - other.Y,
            _z - other.Z);
    }

    public Vector3 Multiply(float scalar)
    {
        return new Vector3(
            _x * scalar,
            _y * scalar,
            _z * scalar);
    }

    public Vector3 Divide(float scalar)
    {
        return new Vector3(
            _x / scalar,
            _y / scalar,
            _z / scalar);
    }

    public static Vector3 operator+(Vector3 self)
    {
        return new Vector3(self.X, self.Y, self.Z);
    }

    public static Vector3 operator-(Vector3 self)
    {
        return new Vector3(-self.X, -self.Y, -self.Z);
    }

    public static Vector3 operator+(Vector3 self, Vector3 other)
    {
        return self.Add(other);
    }

    public static Vector3 operator-(Vector3 self, Vector3 other)
    {
        return self.Subtract(other);
    }

    public static Vector3 operator*(Vector3 self, float other)
    {
        return self.Multiply(other);
    }

    public static Vector3 operator*(float other, Vector3 self)
    {
        return self.Multiply(other);
    }

    public static Vector3 operator/(Vector3 self, float other)
    {
        return self.Divide(other);
    }
}