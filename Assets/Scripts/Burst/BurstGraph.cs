using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class BurstGraph : Graph
{
    [SerializeField]
    protected BurstGraphInitializer initializer;

    protected new TransformAccessArray points;
    protected JobHandle handle;

    private Transform[] parents;

    protected void LateUpdate()
    {
        handle.Complete();
    }

    protected void OnDestroy()
    {
        points.Dispose();
    }

    protected override float Function(Vector3 position, float time)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        pointsCount = points.length;

        if(parents == null)
        {
            parents = new Transform[initializer.parentsCount];
            for(int i = 0; i < parents.Length; i++)
                parents[i] = points[i].parent;
        }
        else
        {
            foreach(Transform parent in parents)
                parent.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach(Transform parent in parents)
            parent.gameObject.SetActive(false);
    }
}
