using UnityEngine;

public class LineGraph : Graph
{
    public LineFunctionName function = 0;

    protected override int _domainLength => LineFunctions.DOMAIN_LENGTH;

    protected override float _Function(Vector3 position, float time)
    {
        return LineFunctions.LineFunction(function, position.x, time);
    }
}
