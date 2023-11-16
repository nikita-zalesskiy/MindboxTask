namespace Mindbox.Geometry;

// Overflow is not considered.

public sealed class Triangle : IHasArea
{
    private Triangle(double a, double b, double c)
    {
        _a = a;

        _b = b;
        
        _c = c;
    }

    private readonly double _a;

    private readonly double _b;

    private readonly double _c;

    public double GetArea()
    {
        var semiperimeter = (_a + _b + _c) / 2.0;

        var squaredArea = semiperimeter
            * (semiperimeter - _a)
            * (semiperimeter - _b)
            * (semiperimeter - _c);

        return Math.Sqrt(squaredArea);
    }

    internal bool IsDegenerate()
    {
        return DoubleComparer.IsNearZero(GetArea());
    }

    public bool IsOrthogonal()
    {
        if (IsDegenerate())
        {
            return false;
        }

        var (a, b, c) = (_a, _b, _c);

        if (a > c)
        {
            (a, c) = (c, a);
        }

        if (b > c)
        {
            (b, c) = (c, b);
        }

        return DoubleComparer.IsNearZero(c * c - a * a - b * b);
    }
    
    internal static bool IsTriangle(double a, double b, double c)
    {
        return !double.IsInfinity(a)
            && !double.IsInfinity(b)
            && !double.IsInfinity(c)
            && a + b >= c && a + c >= b && b + c >= a;
    }

    public static Triangle FromThreeSides(double a, double b, double c)
    {
        if (!IsTriangle(a, b, c))
        {
            throw new GeometryException();
        }

        return new(a, b, c);
    }
}
