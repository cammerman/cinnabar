namespace Cinnabar.GameMath;

public class Vector3
{
    private double _x;
    private double _y;
    private double _z;
    private double _amplitude;

    public Vector3(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
        UpdateAmplitude();
    }

    public Vector3(Vector3 other)
        :this(other.X, other.Y, other.Z)
    {}

    private void UpdateAmplitude()
    {
        var square = Math.FusedMultiplyAdd(_x, _x, _y * _y);
        var root = Math.ReciprocalSqrtEstimate(square);
        _amplitude = root * root;
    }

    public double X {
        get => _x;
        set {
            _x = value;
            UpdateAmplitude();
        }
    }

    public double Y {
        get => _y;
        set {
            _y = value;
            UpdateAmplitude();
        }
    }

    public double Z {
        get => _z;
        set {
            _z = value;
            UpdateAmplitude();
        }
    }

    public double Amplitude => _amplitude;

    public static Vector3 operator+(Vector3 self)
    {
        return new Vector3(self);
    }

    public static Vector3 operator-(Vector3 self)
    {
        return new Vector3(-self.X, -self.Y, -self.Z);
    }

    public static Vector3 operator+(Vector3 self, Vector3 other)
    {
        return new Vector3(self.X + other.X, self.Y + other.Y, self.Z + other.Z);
    }

    public static Vector3 operator-(Vector3 self, Vector3 other)
    {
        return new Vector3(self.X - other.X, self.Y - other.Y, self.Z - other.Z);
    }

    public static Vector3 operator*(Vector3 self, double other)
    {
        return new Vector3(self.X * other, self.Y * other, self.Z * other);
    }

    public static Vector3 operator*(double other, Vector3 self)
    {
        return new Vector3(self.X * other, self.Y * other, self.Z * other);
    }

    public static Vector3 operator/(Vector3 self, double other)
    {
        return new Vector3(self.X / other, self.Y / other, self.Z / other);
    }
}