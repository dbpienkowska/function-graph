using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class BurstGraph : Graph
{
    [SerializeField]
    protected BurstGraphInitializer initializer;

    protected new TransformAccessArray _points;
    protected JobHandle _handle;

    private Transform[] _parents;

    protected void LateUpdate()
    {
        _handle.Complete();
    }

    protected void OnDestroy()
    {
        _points.Dispose();
    }

    protected override float _Function(Vector3 position, float time)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        if(_parents == null)
        {
            _parents = new Transform[initializer.parentsCount];
            for(int i = 0; i < _parents.Length; i++)
                _parents[i] = _points[i].parent;
        }
        else
        {
            foreach(Transform parent in _parents)
                parent.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach(Transform parent in _parents)
            parent.gameObject.SetActive(false);
    }
}
