namespace Mindbox.Geometry;

// Overflow is not considered.

public sealed class Circle : IHasArea
{
    private Circle(double radius)
    {
        _radius = radius;
    }

    private readonly double _radius;
    
    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    internal static bool IsCircle(double radius)
    {
        return !double.IsInfinity(radius) && radius >= 0.0;
    }

    public static Circle FromRadius(double radius)
    {
        if (!IsCircle(radius))
        {
            throw new GeometryException();
        }

        return new(radius);
    }
}
