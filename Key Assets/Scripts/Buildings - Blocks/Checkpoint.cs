using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [Header("Fuel")]
    public float CheckPointMaxFuel = 1000;
    public float CheckPointCurrentFuel = 1000;
    public float CheckPointRefuelRate = 0.1f;
    private float RefuelSpeed;
    public GameObject FuelText;
    public Slider fuelSlider;
    public Gradient fuelGradient;
    public Image fuelFill;

    [Header("Health")]
    public float CheckPointMaxHealth = 500;
    public float CheckPointCurrentHealth = 500;
    private float RepairSpeed;
    public GameObject HealthText;
    public Slider healthSlider;
    public Gradient healthGradient;
    public Image healthFill;


    private bool Colliding = false;
    private GameObject SceneControl;
    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        RepairSpeed = SceneControl.GetComponent<SceneController>().RepairRate;
        RefuelSpeed = SceneControl.GetComponent<SceneController>().RefuelRate;

        CheckPointCurrentFuel = CheckPointMaxFuel;
        SetMaxFuel(CheckPointMaxFuel);

        CheckPointCurrentHealth = CheckPointMaxHealth;
        SetMaxHealth(CheckPointMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckPointCurrentFuel<CheckPointMaxFuel && Colliding == false)
        {
            CheckPointCurrentFuel += CheckPointRefuelRate;
        }
        fuelSlider.value = CheckPointCurrentFuel;
        fuelFill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);
        FuelText.GetComponent<Text>().text = "Fuel: " + Mathf.Round(CheckPointCurrentFuel);

        healthSlider.value = CheckPointCurrentHealth;
        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
        HealthText.GetComponent<Text>().text = "Health: " + Mathf.Round(CheckPointCurrentHealth);
    }

    private void OnCollisionStay(Collision collision)
    {
        Colliding = true;
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentFuel < collision.gameObject.GetComponent<BasicHelicopterController>().MaxFuel && CheckPointCurrentFuel>0)
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentFuel += RefuelSpeed;
            CheckPointCurrentFuel -= RefuelSpeed;
        }
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth< collision.gameObject.GetComponent<BasicHelicopterController>().MaxHealth && CheckPointCurrentHealth > 0)
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth += RepairSpeed;
            CheckPointCurrentHealth -= RepairSpeed;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Colliding = false;
    }
    public void SetMaxFuel(float fuel)
    {
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;

        fuelFill.color = fuelGradient.Evaluate(1f);
    }
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(1f);
    }
}
