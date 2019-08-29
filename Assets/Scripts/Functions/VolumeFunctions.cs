using UnityEngine;

public enum VolumeFunctionName 
{
    Cylinder,
    CoolerCylinder,
    WobblyCylinder,
    Vase,
    Barrel,
    TwistedWobblyCylinder,
    Sphere,
    PulsingSphere,
    Torus,
    WobblyPulsingTorus
}

public static class VolumeFunctions
{
    public const int DOMAIN_LENGTH = 2;

    public static Vector3 VolumeFunction(VolumeFunctionName name, float u, float v, float t)
    {
        switch(name)
        {
            case VolumeFunctionName.Cylinder:
                return Cylinder(u, v, t);
            case VolumeFunctionName.CoolerCylinder:
                return CoolerCylinder(u, v, t);
            case VolumeFunctionName.WobblyCylinder:
                return WobblyCylinder(u, v, t);
            case VolumeFunctionName.Vase:
                return Vase(u, v, t);
            case VolumeFunctionName.Barrel:
                return Barrel(u, v, t);
            case VolumeFunctionName.TwistedWobblyCylinder:
                return TwistedWobblyCylinder(u, v, t);
            case VolumeFunctionName.Sphere:
                return Sphere(u, v, t);
            case VolumeFunctionName.PulsingSphere:
                return PulsingSphere(u, v, t);
            case VolumeFunctionName.Torus:
                return Torus(u, v, t);
            case VolumeFunctionName.WobblyPulsingTorus:
                return WobblyPulsingTorus(u, v, t);
            default:
                return Vector3.zero;
        }
    }

    public static Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;

        float r = DOMAIN_LENGTH / 2f;

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 CoolerCylinder(float u, float v, float t)
    {
        Vector3 p;

        float r = DOMAIN_LENGTH / 2f;

        p.x = r * Mathf.Sin(Mathf.PI * (u + t) + v);
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t) + v);

        return p;
    }

    public static Vector3 WobblyCylinder(float u, float v, float t)
    {
        Vector3 p;

        float r = DOMAIN_LENGTH / 2f + Mathf.Sin(6f * Mathf.PI * u) * 0.2f;

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 Vase(float u, float v, float t)
    {
        Vector3 p;

        float r = DOMAIN_LENGTH / 2f + Mathf.Sin(2f * Mathf.PI * v) * 0.1f;

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 Barrel(float u, float v, float t)
    {
        Vector3 p;

        float r = Mathf.Cos(Mathf.PI * 0.25f * v);

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 TwistedWobblyCylinder(float u, float v, float t)
    {
        Vector3 p;

        float r = DOMAIN_LENGTH / 2f * 0.8f + Mathf.Sin(Mathf.PI * (6f * u + 2f * v + t)) * 0.2f;

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = v;
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;

        float r = Mathf.Cos(Mathf.PI * 0.5f * v);

        p.x = r * Mathf.Sin(Mathf.PI * (u + t));
        p.y = Mathf.Sin(Mathf.PI * 0.5f * v);
        p.z = r * Mathf.Cos(Mathf.PI * (u + t));

        return p;
    }

    public static Vector3 PulsingSphere(float u, float v, float t)
    {
        Vector3 p;

        float r = 0.8f + Mathf.Sin(Mathf.PI * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(Mathf.PI * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(Mathf.PI * 0.5f * v);

        p.x = s * Mathf.Sin(Mathf.PI * u);
        p.y = r * Mathf.Sin(Mathf.PI * 0.5f * v);
        p.z = s * Mathf.Cos(Mathf.PI * u);

        return p;
    }

    public static Vector3 Torus(float u, float v, float t)
    {
        Vector3 p;

        float r1 = 1f;
        float r2 = 0.5f;
        float s = r2 * Mathf.Cos(Mathf.PI * v) + r1;

        p.x = s * Mathf.Sin(Mathf.PI * u + t);
        p.y = r2 * Mathf.Sin(Mathf.PI * v);
        p.z = s * Mathf.Cos(Mathf.PI * u + t);

        return p;
    }

    public static Vector3 WobblyPulsingTorus(float u, float v, float t)
    {
        Vector3 p;

        float r1 = 0.65f + Mathf.Sin(Mathf.PI * (6f * u + t)) * 0.1f;
        float r2 = 0.2f + Mathf.Sin(Mathf.PI * (4f * v + t)) * 0.05f;
        float s = r2 * Mathf.Cos(Mathf.PI * v) + r1;

        p.x = s * Mathf.Sin(Mathf.PI * u);
        p.y = r2 * Mathf.Sin(Mathf.PI * v);
        p.z = s * Mathf.Cos(Mathf.PI * u);

        return p;
    }
}
