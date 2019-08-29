using System;
using UnityEngine;

public class LineGraph : Graph
{
    public LineFunctionName function = 0;

    public override int functionIndex
    {
        get => (int)function;
        set { function = (LineFunctionName)value; }
    }
    public override string[] functionNames => Enum.GetNames(typeof(LineFunctionName));

    protected override int domainLength => LineFunctions.DOMAIN_LENGTH;

    protected override float Function(Vector3 position, float time)
    {
        return LineFunctions.LineFunction(function, position.x, time);
    }
}
