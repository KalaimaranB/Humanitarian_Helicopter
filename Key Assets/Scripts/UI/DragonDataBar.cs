using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonDataBar : MonoBehaviour
{
    private GameObject SceneControl;
    private SceneController sceneControl;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = sceneControl.NumOfDragons;
        slider.value = sceneControl.LiveNumOfDragons;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
