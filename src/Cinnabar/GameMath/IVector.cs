using System.Collections.ObjectModel;

namespace Cinnabar.GameMath;

public interface IVector
{
    ReadOnlyCollection<float> Components { get; } 
    double Magnitude { get; }
    int Dimension { get; }
    float this[int index] { get; set; }
}

public interface IVector<TVector>: IVector
    where TVector: IVector<TVector>
{
    TVector Add(TVector other);
    TVector Subtract(TVector other);
    TVector Multiply(float scalar);
    TVector Divide(float scalar);

    public abstract static TVector operator+(TVector self);
    public abstract static TVector operator-(TVector self);
    public abstract static TVector operator+(TVector self, TVector other);
    public abstract static TVector operator-(TVector self, TVector other);
    public abstract static TVector operator*(TVector self, float other);
    public abstract static TVector operator*(float other, TVector self);
    public abstract static TVector operator/(TVector self, float other);
}
