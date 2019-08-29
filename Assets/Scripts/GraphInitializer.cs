using UnityEngine;

public abstract class GraphInitializer : MonoBehaviour
{
    public int resolution;
    public Transform pointPrefab;
    public float minPointLength = 0.1f;

    public abstract Transform[] Initialize(int domainLength);
}
