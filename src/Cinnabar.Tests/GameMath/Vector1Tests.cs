using System.Runtime.Serialization.Formatters;
using Cinnabar.GameMath;
using Xunit;

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
}