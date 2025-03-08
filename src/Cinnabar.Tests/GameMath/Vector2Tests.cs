using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;
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
    public void Constructor(double x, double y)
    {
        var v = new Vector2(x, y);
        Assert.Equal(x, v.X);
        Assert.Equal(y, v.Y);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Negate(double x, double y)
    {
        var v = new Vector2(x, y);
        var result = -v;
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Add(double x1, double y1, double x2, double y2)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);
        
        var result = v1 + v2;

        Assert.Equal(v1.X + v2.X, result.X);
        Assert.Equal(v1.Y + v2.Y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Subtract(double x1, double y1, double x2, double y2)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);
        
        var result = v1 - v2;

        Assert.Equal(v1.X - v2.X, result.X);
        Assert.Equal(v1.Y - v2.Y, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyVectorByScalar(double x, double y, double s)
    {
        var v = new Vector2(x, y);

        var result = v * s;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyScalarByVector(double s, double x, double y)
    {
        var v = new Vector2(x, y);

        var result = s * v;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void DivideVectorByScalar(double x, double y, double s)
    {
        var v = new Vector2(x, y);

        var result = v / s;

        Assert.Equal(x / s, result.X);
        Assert.Equal(y / s, result.Y);
    }
}