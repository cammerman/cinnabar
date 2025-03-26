using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;
using AutoFixture.Xunit2;
using Cinnabar.GameMath;
using Xunit;

namespace Cinnabar.Test.GameMath;

public class Vector4Tests
{
    public static IEnumerable<object[]> GetSingleVectors()
    {
        yield return new object[] { 5d, 94d, 98342d, 8345d };
        yield return new object[] { 939393d, 89d, 83d, 8323d };
        yield return new object[] { 0.012413d, 0.02323d, 0.8333d, 0.23432d };
        yield return new object[] { 1d, 3442d, 93d, 834d };
        yield return new object[] { 0d, 23932d, 879d, 234d };
        yield return new object[] { 9394324d, 1d, 3d, 33d };
        yield return new object[] { 38474d, 0d, 87d, 98238d };
        yield return new object[] { -100d, -3141d, -87d, -737d };
    }

    public static IEnumerable<object[]> GetVectorPairs()
    {
        yield return new object[] { 5d, 94d, 941d, 9023d, 3485d, 2309d, 349832d, 233d };
        yield return new object[] { 939393d, 89d, 644d, 9484d, 98d, 2093d, 3243d, 89d };
        yield return new object[] { 0.012413d, 0.02323d, 0.2324d, 0.0005d, 0.72378d, 0.234d, 0.35d, 0.2983d };
        yield return new object[] { 1d, 3442d, 5934d, 0d, 898d, 45d, 3245d, 734d };
        yield return new object[] { 0d, 23932d, 949234d, 2d, 7283d, 876d, 9834d, 9834d };
        yield return new object[] { 9394324d, 1d, 934d, 23d, 965d, 98d, 24d, 7884d };
        yield return new object[] { 38474d, 0d, 942d, 924d, 456d, 8738d, 439d, 0d };
        yield return new object[] { -100d, -3141d, -23349d, -3434d, -32d, -833d, -84d, -9723d };
    }

    public static IEnumerable<object[]> GetVectorScalarPairs()
    {
        yield return new object[] { 5d, 94d, 9023d, 867d, 4d };
        yield return new object[] { 939393d, 89d, 33d, 984d, 3242d };
        yield return new object[] { 0.012413d, 0.0005d, 0.6767d, 0.93784d, 0.346d };
        yield return new object[] { 1d, 3442d, 756d, 847d, 498d };
        yield return new object[] { 0d, 23932d, 2d, 843d, 348d };
        yield return new object[] { 1d, 934d, 87d, 7d, 9834d };
        yield return new object[] { 38474d, 0d, 924d, 2342d, 465d };
        yield return new object[] { -100d, -23349d, -3434d, -454d, -6373d };
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Constructor(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        Assert.Equal(w, v.W);
        Assert.Equal(x, v.X);
        Assert.Equal(y, v.Y);
        Assert.Equal(z, v.Z);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void CopyConstructor(float w, float x, float y, float z)
    {
        var v1 = new Vector4(w, x, y, z);
        var v2 = new Vector4(v1);
        Assert.Equal(x, v2.X);
        Assert.Equal(y, v2.Y);
        Assert.Equal(z, v2.Z);
    }

    [Theory, AutoData]
    public void Dimension(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        Assert.Equal(4, v.Dimension);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void UnaryPlus(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var result = +v;
        Assert.Equal(w, result.W);
        Assert.Equal(x, result.X);
        Assert.Equal(y, result.Y);
        Assert.Equal(z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Negate(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var result = v.Negate();
        Assert.Equal(-w, result.W);
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
        Assert.Equal(-z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void NegateOperator(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var result = -v;
        Assert.Equal(-w, result.W);
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
        Assert.Equal(-z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Normalize(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var result = v.Normalize();
        Assert.Equal(1, result.Magnitude, 0.01);
    }

    [Fact]
    public void UnitW()
    {
        var result = Vector4.UnitW();
        Assert.Equal(1, result.W);
        Assert.Equal(0, result.X);
        Assert.Equal(0, result.Y);
        Assert.Equal(0, result.Z);
    }

    [Fact]
    public void UnitX()
    {
        var result = Vector4.UnitX();
        Assert.Equal(0, result.W);
        Assert.Equal(1, result.X);
        Assert.Equal(0, result.Y);
        Assert.Equal(0, result.Z);
    }

    [Fact]
    public void UnitY()
    {
        var result = Vector4.UnitY();
        Assert.Equal(0, result.W);
        Assert.Equal(0, result.X);
        Assert.Equal(1, result.Y);
        Assert.Equal(0, result.Z);
    }

    [Fact]
    public void UnitZ()
    {
        var result = Vector4.UnitZ();
        Assert.Equal(0, result.W);
        Assert.Equal(0, result.X);
        Assert.Equal(0, result.Y);
        Assert.Equal(1, result.Z);
    }

    [Fact]
    public void Zero()
    {
        var result = Vector4.Zero();
        Assert.Equal(0, result.X);
        Assert.Equal(0, result.Y);
        Assert.Equal(0, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Add(float w1, float x1, float y1, float z1, float w2, float x2, float y2, float z2)
    {
        var v1 = new Vector4(w1, x1, y1, z1);
        var v2 = new Vector4(w2, x2, y2, z2);
        
        var result = v1 + v2;

        Assert.Equal(v1.W + v2.W, result.W);
        Assert.Equal(v1.X + v2.X, result.X);
        Assert.Equal(v1.Y + v2.Y, result.Y);
        Assert.Equal(v1.Z + v2.Z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Subtract(float w1, float x1, float y1, float z1, float w2, float x2, float y2, float z2)
    {
        var v1 = new Vector4(w1, x1, y1, z1);
        var v2 = new Vector4(w2, x2, y2, z2);
        
        var result = v1 - v2;

        Assert.Equal(v1.W - v2.W, result.W);
        Assert.Equal(v1.X - v2.X, result.X);
        Assert.Equal(v1.Y - v2.Y, result.Y);
        Assert.Equal(v1.Z - v2.Z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyVectorByScalar(float w, float x, float y, float z, float s)
    {
        var v = new Vector4(w, x, y, z);

        var result = v * s;

        Assert.Equal(w * s, result.W);
        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
        Assert.Equal(z * s, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyScalarByVector(float s, float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);

        var result = s * v;

        Assert.Equal(w * s, result.W);
        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
        Assert.Equal(z * s, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void DivideVectorByScalar(float w, float x, float y, float z, float s)
    {
        var v = new Vector4(w, x, y, z);

        var result = v / s;

        Assert.Equal(w / s, result.W);
        Assert.Equal(x / s, result.X);
        Assert.Equal(y / s, result.Y);
        Assert.Equal(z / s, result.Z);
    }

    [Theory]
    [MemberAutoData(nameof(GetVectorPairs))]
    public void Dot(float w1, float x1, float y1, float z1, float w2, float x2, float y2, float z2)
    {
        var v1 = new Vector4(w1, x1, y1, z1);
        var v2 = new Vector4(w2, x2, y2, z2);

        var result = v1.Dot(v2);

        Assert.Equal((w1 * w2) + (x1 * x2) + (y1 * y2) + (z1 * z2), result);
    }

    [Theory, AutoData]
    public void Components(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var result = v.Components;

        Assert.Equal(result, [w, x, y, z]);
    }

    [Theory, AutoData]
    public void Magnitude(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        var expected = Math.Sqrt(w * w + x * x + y * y + z * z);
        Assert.Equal(
            expected,
            v.Magnitude,
            0.001 * expected);
    }

    [Theory, AutoData]
    public void UpdateWMagnitude(float w, float x, float y, float z, float w2)
    {
        var v = new Vector4(w, x, y, z);
        v.W = w2;
        Assert.Equal(
            Math.Sqrt(w2 * w2 + x * x + y * y + z * z),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void UpdateXMagnitude(float w, float x, float y, float z, float x2)
    {
        var v = new Vector4(w, x, y, z);
        v.X = x2;
        Assert.Equal(
            Math.Sqrt(w * w + x2 * x2 + y * y + z * z),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void UpdateYMagnitude(float w, float x, float y, float y2, float z)
    {
        var v = new Vector4(w, x, y, z);
        v.Y = y2;
        Assert.Equal(
            Math.Sqrt(w * w + x * x + y2 * y2 + z * z),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void UpdateZMagnitude(float w, float x, float y, float z, float z2)
    {
        var v = new Vector4(w, x, y, z);
        v.Z = z2;
        Assert.Equal(
            Math.Sqrt(w * w + x * x + y * y + z2 * z2),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void VectorIndexer(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        Assert.Equal(w, v[0]);
        Assert.Equal(x, v[1]);
        Assert.Equal(y, v[2]);
        Assert.Equal(z, v[3]);
    }

    [Theory, AutoData]
    public void VectorIndexer_Throws(float w, float x, float y, float z)
    {
        var v = new Vector4(w, x, y, z);
        Assert.Throws<IndexOutOfRangeException>(() => v[5]);
    }

    [Theory, AutoData]
    public void VectorIndexerSet(float y)
    {
        var v = Vector4.Zero();
        v[1] = y;
        Assert.Equal(y, v[1]);
    }

    [Theory, AutoData]
    public void VectorIndexerSet_Throws(float x)
    {
        var v = Vector4.Zero();
        Assert.Throws<IndexOutOfRangeException>(() => v[5] = x);
    }

    // [Theory, AutoData]
    // public void MatrixIndexer1x4(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z);
    //     var m = v as IMatrix<Vector4, Vector1, Vector4>;
    //     Assert.Equal(w, m[0, 0]);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer1x4_Throws(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z);
    //     var m = v as IMatrix<Vector4, Vector1, Vector4>;
    //     Assert.Throws<ArgumentOutOfRangeException>(() => m[3, 2]);
    // }

    // [Theory, AutoData]
    // public void Matrix1x4_Column(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z) as IMatrix<Vector4, Vector1, Vector4>;
    //     var col = v.Column(0);
    //     Assert.Equal([w, x, y, z], col.Components);
    // }

    // [Theory, AutoData]
    // public void Matrix1x4_Row(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z) as IMatrix<Vector4, Vector1, Vector4>;
    //     var row = v.Row(0);
    //     Assert.Equal([w], row.Components);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer4x1(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z);
    //     var m = v as IMatrix<Vector4, Vector4, Vector1>;
    //     Assert.Equal(w, m[0, 0]);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer4x1_Throws(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z);
    //     var m = v as IMatrix<Vector4, Vector4, Vector1>;
    //     Assert.Throws<ArgumentOutOfRangeException>(() => m[3, 2]);
    // }

    // [Theory, AutoData]
    // public void Matrix4x1_Column(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z) as IMatrix<Vector4, Vector4, Vector1>;
    //     var col = v.Column(0);
    //     Assert.Equal([w], col.Components);
    // }

    // [Theory, AutoData]
    // public void Matrix4x1_Row(float w, float x, float y, float z)
    // {
    //     var v = new Vector4(w, x, y, z) as IMatrix<Vector4, Vector4, Vector1>;
    //     var row = v.Row(0);
    //     Assert.Equal([w, x, y, z], row.Components);
    // }
}