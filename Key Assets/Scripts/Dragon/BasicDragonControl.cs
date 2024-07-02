using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDragonControl : MonoBehaviour
{
    public float MaxHealth = 1000;
    public float CurrentHealth = 1000;
    public GameObject HealthBar;
    public GameObject HealthText;

    private Slider slider;
    private Gradient gradient;
    private Image fill;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        slider = HealthBar.GetComponent<DragonHealthBar>().slider;
        gradient = HealthBar.GetComponent<DragonHealthBar>().gradient;
        fill = HealthBar.GetComponent<DragonHealthBar>().fill;
        HealthBar.GetComponent<DragonHealthBar>().SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CurrentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        HealthText.GetComponent<Text>().text = "Health: " + Mathf.Round(CurrentHealth);
    }
}
