using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellFireMissile : MonoBehaviour
{
    public float Speed;
    public float Damage;
    private GameObject GameManagement;
    private GameManagement gameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManager = GameManagement.GetComponent<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManagement.GetComponent<AudioSource>().Play();
        if (collision.gameObject.tag == "Dragon" && collision.gameObject.GetComponent<BasicDragonControl>().CurrentHealth>0)
        {
            collision.gameObject.GetComponent<BasicDragonControl>().CurrentHealth -= Damage;
        }
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth > 0)
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth -= Damage;
        }
        Destroy(gameObject);
    }
}
