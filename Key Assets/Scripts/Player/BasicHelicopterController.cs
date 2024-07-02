using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHelicopterController : MonoBehaviour
{
    public float StartSpeed;
    public float Speed;
    [Header("Fuel")]
    public float MaxFuel;
    public float CurrentFuel;
    public float FuelPercent;
    public float FuelConsumptionRate;
    [Header("Health")]
    public float MaxHealth;
    public float CurrentHealth;
    private SceneController sceneController;
    private GameObject CurrentPlayer;
    [Header("Key")]
    public int KeyCount;
    [Header("Player")]
    public bool TransportCopter;
    public bool AttackCopter;
    Rigidbody rb;
    AudioSource AS;


    private GameObject SceneControl;
    private SceneController sceneControl;
    private GameObject GameManagement;
    private GameManagement gameManagement;
    // Start is called before the first frame update
    void Start()
    {
        StartSpeed = Speed;
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
        rb = GetComponent<Rigidbody>();

        AS = GetComponent<AudioSource>();
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();
        AS.volume = gameManagement.SoundEffectVolume;

        CurrentFuel = MaxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        AS.volume = gameManagement.SoundEffectVolume;
        CurrentPlayer = sceneControl.CurrentPlayer;
        if (gameObject == CurrentPlayer)
        {
            if (Input.GetKey(KeyCode.RightArrow) && CurrentFuel > 0)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                MoveAndUseFuel(Vector3.forward);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && CurrentFuel > 0)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                MoveAndUseFuel(Vector3.back);
            }
            if (Input.GetKey(KeyCode.UpArrow) && CurrentFuel > 0)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                MoveAndUseFuel(Vector3.up);
            }
            if (Input.GetKey(KeyCode.DownArrow) && CurrentFuel > 0)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                MoveAndUseFuel(Vector3.down);
            }
            if (!Input.anyKey)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
            FuelPercent = Mathf.Round((CurrentFuel * 100) / MaxFuel);
        }
    }


    private void MoveAndUseFuel(Vector3 moveDirection)
    {
        transform.Translate(moveDirection * Time.deltaTime * Speed);
        CurrentFuel -= FuelConsumptionRate;
    }
}
