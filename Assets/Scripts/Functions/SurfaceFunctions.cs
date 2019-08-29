using UnityEngine;

public enum SurfaceFunctionName
{
    Sine,
    MultiSine,
    Ripple
};

public static class SurfaceFunctions
{
    public static int DOMAIN_LENGTH = 2; // (-1, 1)

    public static float SurfaceFunction(SurfaceFunctionName name, float x, float z, float t)
    {
        switch(name)
        {
            case SurfaceFunctionName.Sine:
                return Sine(x, z, t);
            case SurfaceFunctionName.MultiSine:
                return MultiSine(x, z, t);
            case SurfaceFunctionName.Ripple:
                return Ripple(x, z, t);
            default:
                return 0f;
        }
    }

    public static float Sine(float x, float z, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(Mathf.PI * (z + t));
        y *= 0.5f;

        return y;
    }

    public static float MultiSine(float x, float z, float t)
    {
        float y = 4f * Mathf.Sin(Mathf.PI * (x + z + t * 0.5f));
        y += Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (z + t * 2f)) * 0.5f;
        y *= 1f / 5.5f;

        return y;
    }

    public static float Ripple(float x, float z, float t)
    {
        float d = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sin(Mathf.PI * (4f * d - t));
        y /= 1f + 10f * d;

        return y;
    }
}