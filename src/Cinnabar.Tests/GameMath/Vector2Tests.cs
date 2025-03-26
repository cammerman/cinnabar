using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;
using AutoFixture.Xunit2;
using Cinnabar.GameMath;
using Xunit;

namespace Cinnabar.Test.GameMath;

public class Vector2Tests
{
    public static IEnumerable<object[]> GetSingleVectors()
    {
        yield return new object[] { 5d, 94d };
        yield return new object[] { 939393d, 89d };
        yield return new object[] { 0.012413d, 0.02323d };
        yield return new object[] { 1d, 3442d };
        yield return new object[] { 0d, 23932d };
        yield return new object[] { 9394324d, 1d };
        yield return new object[] { 38474d, 0d };
        yield return new object[] { -100d, -3141d };
    }

    public static IEnumerable<object[]> GetVectorPairs()
    {
        yield return new object[] { 5d, 94d, 941d, 9023d };
        yield return new object[] { 939393d, 89d, 644d, 9484d };
        yield return new object[] { 0.012413d, 0.02323d, 0.2324d, 0.0005d };
        yield return new object[] { 1d, 3442d, 5934d, 0d };
        yield return new object[] { 0d, 23932d, 949234d, 2d };
        yield return new object[] { 9394324d, 1d, 934d, 23d };
        yield return new object[] { 38474d, 0d, 942d, 924d };
        yield return new object[] { -100d, -3141d, -23349d, -3434d };
    }

    public static IEnumerable<object[]> GetVectorScalarPairs()
    {
        yield return new object[] { 5d, 94d, 9023d };
        yield return new object[] { 939393d, 89d, 9484d };
        yield return new object[] { 0.012413d, 0.2324d, 0.0005d };
        yield return new object[] { 1d, 3442d, 5934d };
        yield return new object[] { 0d, 23932d, 2d };
        yield return new object[] { 1d, 934d, 23d };
        yield return new object[] { 38474d, 0d, 924d };
        yield return new object[] { -100d, -23349d, -3434d };
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Constructor(float x, float y)
    {
        var v = new Vector2(x, y);
        Assert.Equal(x, v.X);
        Assert.Equal(y, v.Y);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void CopyConstructor(float x, float y)
    {
        var v1 = new Vector2(x, y);
        var v2 = new Vector2(v1);
        Assert.Equal(x, v2.X);
        Assert.Equal(y, v2.Y);
    }

    [Theory, AutoData]
    public void Dimension(float x, float y)
    {
        var v = new Vector2(x, y);
        Assert.Equal(2, v.Dimension);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void UnaryPlus(float x, float y)
    {
        var v = new Vector2(x, y);
        var result = +v;
        Assert.Equal(x, result.X);
        Assert.Equal(y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Negate(float x, float y)
    {
        var v = new Vector2(x, y);
        var result = v.Negate();
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void NegateOperator(float x, float y)
    {
        var v = new Vector2(x, y);
        var result = -v;
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Normalize(float x, float y)
    {
        var v = new Vector2(x, y);
        var result = v.Normalize();
        Assert.Equal(1, result.Magnitude, 0.01);
    }

    [Fact]
    public void UnitX()
    {
        var result = Vector2.UnitX();
        Assert.Equal(1, result.X);
        Assert.Equal(0, result.Y);
    }

    [Fact]
    public void UnitY()
    {
        var result = Vector2.UnitY();
        Assert.Equal(0, result.X);
        Assert.Equal(1, result.Y);
    }

    [Fact]
    public void Zero()
    {
        var result = Vector2.Zero();
        Assert.Equal(0, result.X);
        Assert.Equal(0, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Add(float x1, float y1, float x2, float y2)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);
        
        var result = v1 + v2;

        Assert.Equal(v1.X + v2.X, result.X);
        Assert.Equal(v1.Y + v2.Y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Subtract(float x1, float y1, float x2, float y2)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);
        
        var result = v1 - v2;

        Assert.Equal(v1.X - v2.X, result.X);
        Assert.Equal(v1.Y - v2.Y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyVectorByScalar(float x, float y, float s)
    {
        var v = new Vector2(x, y);

        var result = v * s;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyScalarByVector(float s, float x, float y)
    {
        var v = new Vector2(x, y);

        var result = s * v;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void DivideVectorByScalar(float x, float y, float s)
    {
        var v = new Vector2(x, y);

        var result = v / s;

        Assert.Equal(x / s, result.X);
        Assert.Equal(y / s, result.Y);
    }

    [Theory]
    [MemberAutoData(nameof(GetVectorPairs))]
    public void Dot(float x1, float y1, float x2, float y2)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);

        var result = v1.Dot(v2);

        Assert.Equal((x1 * x2) + (y1 * y2), result);
    }

    [Theory, AutoData]
    public void Components(float x, float y)
    {
        var v = new Vector2(x, y);
        var result = v.Components;

        Assert.Equal(result, [x, y]);
    }

    [Theory, AutoData]
    public void Magnitude(float x, float y)
    {
        var v = new Vector2(x, y);
        Assert.Equal(
            Math.Sqrt(x * x + y * y),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void UpdateXMagnitude(float x, float y, float x2)
    {
        var v = new Vector2(x, y);
        v.X = x2;
        Assert.Equal(
            Math.Sqrt(x2 * x2 + y * y),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void UpdateYMagnitude(float x, float y, float y2)
    {
        var v = new Vector2(x, y);
        v.Y = y2;
        Assert.Equal(
            Math.Sqrt(x * x + y2 * y2),
            v.Magnitude,
            0.01);
    }

    [Theory, AutoData]
    public void VectorIndexer(float x, float y)
    {
        var v = new Vector2(x, y);
        Assert.Equal(x, v[0]);
        Assert.Equal(y, v[1]);
    }

    [Theory, AutoData]
    public void VectorIndexer_Throws(float x, float y)
    {
        var v = new Vector2(x, y);
        Assert.Throws<IndexOutOfRangeException>(() => v[3]);
    }

    [Theory, AutoData]
    public void VectorIndexerSet(float x, float y)
    {
        var v = Vector2.Zero();
        v[0] = x;
        v[1] = y;
        Assert.Equal(x, v.X);
        Assert.Equal(y, v.Y);
    }

    [Theory, AutoData]
    public void VectorIndexerSet_Throws(float x)
    {
        var v = Vector2.Zero();
        Assert.Throws<IndexOutOfRangeException>(() => v[3] = x);
    }

    // [Theory, AutoData]
    // public void MatrixIndexer1x2(float x, float y)
    // {
    //     var v = new Vector2(x, y);
    //     var m = v as IMatrix<Vector2, Vector1, Vector2>;
    //     Assert.Equal(x, m[0, 0]);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer1x2_Throws(float x, float y)
    // {
    //     var v = new Vector2(x, y);
    //     var m = v as IMatrix<Vector2, Vector1, Vector2>;
    //     Assert.Throws<ArgumentOutOfRangeException>(() => m[3, 2]);
    // }

    // [Theory, AutoData]
    // public void Matrix1x2_Column(float x, float y)
    // {
    //     var v = new Vector2(x, y) as IMatrix<Vector2, Vector1, Vector2>;
    //     var col = v.Column(0);
    //     Assert.Equal([x, y], col.Components);
    // }

    // [Theory, AutoData]
    // public void Matrix1x2_Row(float x, float y)
    // {
    //     var v = new Vector2(x, y) as IMatrix<Vector2, Vector1, Vector2>;
    //     var row = v.Row(0);
    //     Assert.Equal([x], row.Components);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer2x1(float x, float y)
    // {
    //     var v = new Vector2(x, y);
    //     var m = v as IMatrix<Vector2, Vector2, Vector1>;
    //     Assert.Equal(x, m[0, 0]);
    // }

    // [Theory, AutoData]
    // public void MatrixIndexer2x1_Throws(float x, float y)
    // {
    //     var v = new Vector2(x, y);
    //     var m = v as IMatrix<Vector2, Vector2, Vector1>;
    //     Assert.Throws<ArgumentOutOfRangeException>(() => m[3, 2]);
    // }

    // [Theory, AutoData]
    // public void Matrix2x1_Column(float x, float y)
    // {
    //     var v = new Vector2(x, y) as IMatrix<Vector2, Vector2, Vector1>;
    //     var col = v.Column(0);
    //     Assert.Equal([x], col.Components);
    // }

    // [Theory, AutoData]
    // public void Matrix2x1_Row(float x, float y)
    // {
    //     var v = new Vector2(x, y) as IMatrix<Vector2, Vector2, Vector1>;
    //     var row = v.Row(0);
    //     Assert.Equal([x, y], row.Components);
    // }
}