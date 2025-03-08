namespace Cinnabar.GameMath;

public class Vector1
{
    private double _x;

    public Vector1(double x)
    {
        _x = x;
    }

    public double X {
        get => _x;
        set { _x = value; }
    }

    public double Amplitude => _x;

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
        return new Vector1(self.X + other.X);
    }

    public static Vector1 operator-(Vector1 self, Vector1 other)
    {
        return new Vector1(self.X - other.X);
    }

    public static Vector1 operator*(Vector1 self, double other)
    {
        return new Vector1(self.X * other);
    }

    public static Vector1 operator*(double other, Vector1 self)
    {
        return new Vector1(self.X * other);
    }

    public static Vector1 operator/(Vector1 self, double other)
    {
        return new Vector1(self.X / other);
    }
}
