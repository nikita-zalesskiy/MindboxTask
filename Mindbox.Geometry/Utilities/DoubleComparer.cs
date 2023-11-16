namespace Mindbox.Geometry;

internal static class DoubleComparer
{
    public const double DefaultTolerance = 1e-10d;

    public static bool IsNearZero(double value, double epsilon = DefaultTolerance)
    {
        return Math.Abs(value) < epsilon;
    }
}
