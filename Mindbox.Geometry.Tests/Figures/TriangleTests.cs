using Mindbox.Geometry;
using Xunit;

namespace Mindbox.Tests.Geometry;

public sealed class TriangleTests
{
    [Theory]
    [InlineData(0.0, 0.0, 0.0)]
    [InlineData(0.5, 0.5, 0.0)]
    [InlineData(1.0, 0.5, 0.5)]
    public void DetectsDegenerateTriangles(double a, double b, double c)
    {
        var triangle = Triangle.FromThreeSides(a, b, c);

        Assert.NotNull(triangle);
    }

    [Theory]
    [InlineData(5.0, 4.0, 0.5)]
    [InlineData(5.0, 4.0, -1.0)]
    [InlineData(5.0, 4.0, double.NaN)]
    [InlineData(5.0, 4.0, double.PositiveInfinity)]
    [InlineData(-1.0, double.PositiveInfinity, double.PositiveInfinity)]
    public void DetectsNotTriangles(double a, double b, double c)
    {
        Assert.Throws<GeometryException>(() => Triangle.FromThreeSides(a, b, c));
    }

    [Theory]
    [InlineData(5.0, 3.0, 4.0)]
    [InlineData(1.0, 5.0 / 13.0, 12.0 / 13.0)]
    public void DetectsOrthogonalTriangles(double a, double b, double c)
    {
        var triangle = Triangle.FromThreeSides(a, b, c);

        var isOrthogonal = triangle.IsOrthogonal();

        Assert.True(isOrthogonal);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0)]
    [InlineData(1.0, 0.5, 0.5)]
    [InlineData(3.0, 0.5, 2.7)]
    [InlineData(2.0, 4.0, 5.0)]
    [InlineData(1.0, 6.0 / 13.0, 12.0 / 13.0)]
    public void DetectsNotOrthogonalTriangles(double a, double b, double c)
    {
        var triangle = Triangle.FromThreeSides(a, b, c);

        var isOrthogonal = triangle.IsOrthogonal();

        Assert.False(isOrthogonal);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0)]
    [InlineData(0.5, 0.5, 0.0, 0.0)]
    [InlineData(1.0, 0.5, 0.5, 0.0)]
    [InlineData(6.0, 5.0, 2.2, 5.28)]
    [InlineData(1.0, 5.0 / 13.0, 12.0 / 13.0, 30.0 / 169.0)]
    public void FindsArea(double a, double b, double c, double expected)
    {
        var triangle = Triangle.FromThreeSides(a, b, c);

        var area = triangle.GetArea();

        Assert.Equal(expected, area, 1e-10d);
    }
}
