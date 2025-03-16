using Cinnabar.GameMath;
using AutoFixture.Xunit2;

namespace Cinnabar.Test.GameMath;

public class Vector1Tests
{
    public static IEnumerable<object[]> GetSingleVectors()
    {
        yield return new object[] { 5d };
        yield return new object[] { 939393d };
        yield return new object[] { 0.012413d };
        yield return new object[] { 1 };
        yield return new object[] { 0 };
        yield return new object[] { -100 };
    }

    public static IEnumerable<object[]> GetVectorPairs()
    {
        yield return new object[] { 5d, 0.238328d };
        yield return new object[] { 939393d, 9292d };
        yield return new object[] { 0.012413d, 0.1930d };
        yield return new object[] { 0, 101 };
        yield return new object[] { -123, 0 };
        yield return new object[] { -2332, -0.563 };
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Constructor(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(x, v.X);
    }

    [Fact]
    public void Zero()
    {
        var v = Vector1.Zero();
        Assert.Equal(0f, v.X);
    }

    [Theory, AutoData]
    public void Dimension(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(1, v.Dimension);
    }

    [Theory, AutoData]
    public void Order(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(new MatrixOrder(1, 1), v.Order);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Negate(float x)
    {
        var v = new Vector1(x);
        var result = -v;
        Assert.Equal(-x, result.X);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Add(float x1, float x2)
    {
        var v1 = new Vector1(x1);
        var v2 = new Vector1(x2);
        
        var result = v1 + v2;

        Assert.Equal(result.X, v1.X + v2.X);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Subtract(float x1, float x2)
    {
        var v1 = new Vector1(x1);
        var v2 = new Vector1(x2);
        
        var result = v1 - v2;

        Assert.Equal(result.X, v1.X - v2.X);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void MultiplyVectorByScalar(float x1, float x2)
    {
        var v1 = new Vector1(x1);

        var result = v1 * x2;

        Assert.Equal(result.X, x1 * x2);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void MultiplyScalarByVector(float x1, float x2)
    {
        var v1 = new Vector1(x1);

        var result = x2 * v1;

        Assert.Equal(result.X, x1 * x2);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void DivideVectorByScalar(float x1, float x2)
    {
        var v1 = new Vector1(x1);

        var result = v1 / x2;

        Assert.Equal(result.X, x1 / x2);
    }

    [Theory]
    [MemberAutoData(nameof(GetVectorPairs))]
    public void Dot(float x1, float x2)
    {
        var v1 = new Vector1(x1);
        var v2 = new Vector1(x2);

        var result = v1.Dot(v2);

        Assert.Equal(x1 * x2, result);
    }

    [Theory, AutoData]
    public void Components(float x)
    {
        var v = new Vector1(x);
        var result = v.Components;

        Assert.Equal(result, [x]);
    }

    [Theory, AutoData]
    public void Magnitude(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(x, v.Magnitude);
    }

    [Theory, AutoData]
    public void VectorIndexer(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(x, v[0]);
    }

    [Theory, AutoData]
    public void VectorIndexer_Throws(float x)
    {
        var v = new Vector1(x);
        Assert.Throws<IndexOutOfRangeException>(() => v[3]);
    }

    [Theory, AutoData]
    public void VectorIndexerSet(float x)
    {
        var v = Vector1.Zero();
        v[0] = x;
        Assert.Equal(x, v[0]);
    }

    [Theory, AutoData]
    public void VectorIndexerSet_Throws(float x)
    {
        var v = Vector1.Zero();
        Assert.Throws<IndexOutOfRangeException>(() => v[3] = x);
    }

    [Theory, AutoData]
    public void MatrixIndexer(float x)
    {
        var v = new Vector1(x);
        Assert.Equal(x, v[0, 0]);
    }

    [Theory, AutoData]
    public void MatrixIndexer_Throws(float x)
    {
        var v = new Vector1(x);
        Assert.Throws<IndexOutOfRangeException>(() => v[3, 2]);
    }

    [Theory, AutoData]
    public void MatrixIndexerSet(float x)
    {
        var v = Vector1.Zero();
        v[0, 0] = x;
        Assert.Equal(x, v.X);
    }

    [Theory, AutoData]
    public void MatrixIndexerSet_Throws(float x)
    {
        var v = Vector1.Zero();
        Assert.Throws<IndexOutOfRangeException>(() => v[3, 2] = x);
    }

    [Theory, AutoData]
    public void Column(float x)
    {
        var v = new Vector1(x) as IMatrix<Vector1, Vector1, Vector1>;
        var col = v.Column(0);
        Assert.Equal(x, col[0]);
    }

    [Theory, AutoData]
    public void Row(float x)
    {
        var v = new Vector1(x) as IMatrix<Vector1, Vector1, Vector1>;
        var col = v.Row(0);
        Assert.Equal(x, col[0]);
    }
}