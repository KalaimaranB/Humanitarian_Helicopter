using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
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
    }

    void Update()
    {
        if (sceneControl.Win == false)
        {
            CurrentPlayer = sceneControl.CurrentPlayer;
            slider.maxValue = CurrentPlayer.GetComponent<BasicHelicopterController>().MaxHealth;
            slider.value = CurrentPlayer.GetComponent<BasicHelicopterController>().CurrentHealth;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }


}
