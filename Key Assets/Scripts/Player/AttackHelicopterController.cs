using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHelicopterController : MonoBehaviour
{
    public GameObject Missile;
    public AudioClip MissileFired;
    public float AudioStrength = 1f;
    private Vector3 Offset = new Vector3(0, -0.1f, 0);
    Rigidbody rb;
    AudioSource AS;

    private GameObject SceneControl;
    private SceneController sceneControl;
    public GameObject CurrentPlayer;


    private GameObject GameManagement;
    private GameManagement gameManagement;
    // Start is called before the first frame update
    void Start()
    {
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();

        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
        rb = GetComponent<Rigidbody>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPlayer = sceneControl.CurrentPlayer;
        if (gameObject == CurrentPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AS.PlayOneShot(MissileFired,gameManagement.SoundEffectVolume);
                Instantiate(Missile, transform.position + Offset, Missile.transform.rotation);
            }
        }
    }
}
