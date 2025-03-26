using System.Collections.ObjectModel;
using System.Numerics;

namespace Cinnabar.GameMath;

public interface IVector
{
    ReadOnlyCollection<float> Components { get; } 
    double Magnitude { get; }
    int Dimension { get; }
    float this[int index] { get; }


}

public interface IVector<TVector>: IVector
    where TVector: IVector<TVector>
{
    TVector Add(TVector other);
    TVector Subtract(TVector other);
    TVector Multiply(float scalar);
    TVector Divide(float scalar);
    float Dot(TVector other);

    public abstract static TVector operator+(TVector self);
    public abstract static TVector operator-(TVector self);
    public abstract static TVector operator+(TVector self, TVector other);
    public abstract static TVector operator-(TVector self, TVector other);
    public abstract static TVector operator*(TVector self, float other);
    public abstract static TVector operator*(float other, TVector self);
    public abstract static TVector operator/(TVector self, float other);

    public TVector Negate();
    public TVector Normalize();

    // IMatrix<Vector1, TVector> AsRowMatrix();
    // IMatrix<TVector, Vector1> AsColumnMatrix();
}
