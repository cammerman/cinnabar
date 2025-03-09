using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;
using Cinnabar.GameMath;
using Xunit;

namespace Cinnabar.Test.GameMath;

public class Vector3Tests
{
    public static IEnumerable<object[]> GetSingleVectors()
    {
        yield return new object[] { 5d, 94d, 98342d };
        yield return new object[] { 939393d, 89d, 83d };
        yield return new object[] { 0.012413d, 0.02323d, 0.8333d };
        yield return new object[] { 1d, 3442d, 93d };
        yield return new object[] { 0d, 23932d, 879d };
        yield return new object[] { 9394324d, 1d, 3d };
        yield return new object[] { 38474d, 0d, 87d };
        yield return new object[] { -100d, -3141d, -87d };
    }

    public static IEnumerable<object[]> GetVectorPairs()
    {
        yield return new object[] { 5d, 94d, 941d, 9023d, 3485d, 2309d };
        yield return new object[] { 939393d, 89d, 644d, 9484d, 98d, 2093d };
        yield return new object[] { 0.012413d, 0.02323d, 0.2324d, 0.0005d, 0.72378d, 0.234d };
        yield return new object[] { 1d, 3442d, 5934d, 0d, 898d, 45d };
        yield return new object[] { 0d, 23932d, 949234d, 2d, 7283d, 876d };
        yield return new object[] { 9394324d, 1d, 934d, 23d, 965d, 98d };
        yield return new object[] { 38474d, 0d, 942d, 924d, 456d, 8738d };
        yield return new object[] { -100d, -3141d, -23349d, -3434d, -32d, -833d };
    }

    public static IEnumerable<object[]> GetVectorScalarPairs()
    {
        yield return new object[] { 5d, 94d, 9023d, 867d };
        yield return new object[] { 939393d, 89d, 9484d, 33d };
        yield return new object[] { 0.012413d, 0.2324d, 0.0005d, 0.6767d };
        yield return new object[] { 1d, 3442d, 5934d, 756d };
        yield return new object[] { 0d, 23932d, 2d, 8686d };
        yield return new object[] { 1d, 934d, 23d, 87d };
        yield return new object[] { 38474d, 0d, 924d, 465d };
        yield return new object[] { -100d, -23349d, -3434d, -6373d };
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Constructor(float x, float y, float z)
    {
        var v = new Vector3(x, y, z);
        Assert.Equal(x, v.X);
        Assert.Equal(y, v.Y);
        Assert.Equal(z, v.Z);
    }

    [Theory]
    [MemberData(nameof(GetSingleVectors))]
    public void Negate(float x, float y, float z)
    {
        var v = new Vector3(x, y, z);
        var result = -v;
        Assert.Equal(-x, result.X);
        Assert.Equal(-y, result.Y);
        Assert.Equal(-z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Add(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        var v1 = new Vector3(x1, y1, z1);
        var v2 = new Vector3(x2, y2, z2);
        
        var result = v1 + v2;

        Assert.Equal(v1.X + v2.X, result.X);
        Assert.Equal(v1.Y + v2.Y, result.Y);
        Assert.Equal(v1.Z + v2.Z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorPairs))]
    public void Subtract(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        var v1 = new Vector3(x1, y1, z1);
        var v2 = new Vector3(x2, y2, z2);
        
        var result = v1 - v2;

        Assert.Equal(v1.X - v2.X, result.X);
        Assert.Equal(v1.Y - v2.Y, result.Y);
        Assert.Equal(v1.Z - v2.Z, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyVectorByScalar(float x, float y, float z, float s)
    {
        var v = new Vector3(x, y, z);

        var result = v * s;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
        Assert.Equal(z * s, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void MultiplyScalarByVector(float s, float x, float y, float z)
    {
        var v = new Vector3(x, y, z);

        var result = s * v;

        Assert.Equal(x * s, result.X);
        Assert.Equal(y * s, result.Y);
        Assert.Equal(z * s, result.Z);
    }

    [Theory]
    [MemberData(nameof(GetVectorScalarPairs))]
    public void DivideVectorByScalar(float x, float y, float z, float s)
    {
        var v = new Vector3(x, y, z);

        var result = v / s;

        Assert.Equal(x / s, result.X);
        Assert.Equal(y / s, result.Y);
        Assert.Equal(z / s, result.Z);
    }
}