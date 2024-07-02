using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float Damage = 25;
    public AudioClip Hit;
    private AudioSource source;
    private bool Contact;
    private GameObject Coll;


    private GameObject GameManagement;
    private GameManagement gameManagement;
    private void Start()
    {
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth > 0)
        {
            source.PlayOneShot(Hit, gameManagement.SoundEffectVolume);
            Coll = collision.gameObject;
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth -= Damage;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    void Update()
    {
            
    }
}
