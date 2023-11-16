using Mindbox.Geometry;
using Xunit;

namespace Mindbox.Tests.Geometry;

public sealed class CircleTests
{
    [Theory]
    [InlineData(-1.0)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    public void DetectsNotCircles(double radius)
    {
        Assert.Throws<GeometryException>(() => Circle.FromRadius(radius));
    }

    [Theory]
    [InlineData(0.0, 0.0)]
    [InlineData(0.56418958354775628, 1.0)]
    [InlineData(1.0, 3.1415926535897931)]
    public void FindsArea(double radius, double expected)
    {
        var circle = Circle.FromRadius(radius);

        var area = circle.GetArea();

        Assert.Equal(expected, area, 1e-10d);
    }
}
