using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphManager : MonoBehaviour
{
    public Graph[] graphs;

    public Dropdown graphDropwdown;
    public Dropdown functionDropdown;

    public Slider speedSlider;
    public Text speedText;

    public Text pointsText;

    private int activeGraphIndex;

    private void Start()
    {
        SetGraphDropdown();
        SetFunctionDropdown();
        ActivateGraph(graphDropwdown.value);
    }

    private void SetGraphDropdown()
    {
        graphDropwdown.ClearOptions();

        List<string> options = new List<string>();
        foreach(var graph in graphs)
            options.Add(graph.name);

        graphDropwdown.AddOptions(options);
    }

    private void SetFunctionDropdown()
    {
        functionDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach(var function in graphs[activeGraphIndex].functionNames)
            options.Add(function);

        functionDropdown.AddOptions(options);
    }

    private void OnEnable()
    {
        graphDropwdown.onValueChanged.AddListener(ActivateGraph);
        functionDropdown.onValueChanged.AddListener(SetFunction);
        speedSlider.onValueChanged.AddListener(SetAnimationSpeed);
    }

    private void OnDisable()
    {
        graphDropwdown.onValueChanged.RemoveListener(ActivateGraph);
        functionDropdown.onValueChanged.RemoveListener(SetFunction);
        speedSlider.onValueChanged.RemoveListener(SetAnimationSpeed);
    }

    private void ActivateGraph(int index)
    {
        graphs[activeGraphIndex].gameObject.SetActive(false);

        activeGraphIndex = index;

        SetFunctionDropdown();
        if(functionDropdown.value >= functionDropdown.options.Count)
            functionDropdown.value = 0;
        SetFunction(functionDropdown.value);

        SetAnimationSpeed(speedSlider.value);

        graphs[activeGraphIndex].gameObject.SetActive(true);

        pointsText.text = graphs[activeGraphIndex].pointsCount.ToString();
    }

    private void SetFunction(int index)
    {
        graphs[activeGraphIndex].functionIndex = index;
    }

    private void SetAnimationSpeed(float speed)
    {
        speed = Mathf.Round(speed * 10) / 10;
        graphs[activeGraphIndex].animationSpeed = speed;
        speedText.text = string.Format("{0:F2}", speed);
    }
}
