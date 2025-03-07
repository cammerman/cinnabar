namespace Cinnabar.GameMath;

public class Vector2
{
    private double _x;
    private double _y;
    private double _amplitude;

    public Vector2(double x, double y)
    {
        _x = x;
        _y = y;
        UpdateAmplitude();
    }

    public Vector2(Vector2 other)
        :this(other.X, other.Y)
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

    public double Amplitude => _amplitude;

    public static Vector2 operator+(Vector2 self)
    {
        return new Vector2(self);
    }

    public static Vector2 operator-(Vector2 self)
    {
        return new Vector2(-self.X, -self.Y);
    }

    public static Vector2 operator+(Vector2 self, Vector2 other)
    {
        return new Vector2(self.X + other.X, self.Y + other.Y);
    }

    public static Vector2 operator-(Vector2 self, Vector2 other)
    {
        return new Vector2(self.X - other.X, self.Y - other.Y);
    }

    public static Vector2 operator*(Vector2 self, double other)
    {
        return new Vector2(self.X * other, self.Y * other);
    }

    public static Vector2 operator*(double other, Vector2 self)
    {
        return new Vector2(self.X * other, self.Y * other);
    }

    public static Vector2 operator/(Vector2 self, double other)
    {
        return new Vector2(self.X / other, self.Y / other);
    }
}