using UnityEngine;

public enum LineFunctionName
{
    Linear,
    Square,
    Cubic,
    Sine,
    MultiSine
};

public static class LineFunctions
{
    public const int DOMAIN_LENGTH = 2; // (-1, 1)

    public static float LineFunction(LineFunctionName name, float x, float t)
    {
        switch(name)
        {
            case LineFunctionName.Linear:
                return Linear(x, t);
            case LineFunctionName.Square:
                return Square(x, t);
            case LineFunctionName.Cubic:
                return Cubic(x, t);
            case LineFunctionName.Sine:
                return Sine(x, t);
            case LineFunctionName.MultiSine:
                return MultiSine(x, t);
            default:
                return 0f;
        }
    }

    public static float Linear(float x, float t)
    {
        return (x + t) % DOMAIN_LENGTH - (DOMAIN_LENGTH / 2);
    }

    public static float Square(float x, float t)
    {
        return (x * x + t) % DOMAIN_LENGTH - (DOMAIN_LENGTH / 2);
    }

    public static float Cubic(float x, float t)
    {
        return (x * x * x + t) % DOMAIN_LENGTH - (DOMAIN_LENGTH / 2);
    }
    
    public static float Sine(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    public static float MultiSine(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));

        y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) * 0.5f;
        y *= 2f / 3f;

        return y;
    }
}