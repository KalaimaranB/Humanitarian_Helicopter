using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private GameObject SceneControl;
    private SceneController sceneControl;
    private GameObject CurrentPlayer;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
        CurrentPlayer = sceneControl.CurrentPlayer;
        SetMaxFuel(sceneControl.CurrentPlayer.GetComponent<BasicHelicopterController>().MaxFuel);
    }

    void Update()
    {
        if (sceneControl.Win == false)
        {
            CurrentPlayer = sceneControl.CurrentPlayer;
            slider.value = CurrentPlayer.GetComponent<BasicHelicopterController>().CurrentFuel;
            slider.maxValue = CurrentPlayer.GetComponent<BasicHelicopterController>().MaxFuel;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

    public void SetMaxFuel(float fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;

        fill.color = gradient.Evaluate(1f);
    }


}
