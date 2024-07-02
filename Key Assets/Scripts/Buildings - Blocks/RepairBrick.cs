using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBrick : MonoBehaviour
{
    private float RepairSpeed;
    private GameObject SceneControl;
    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        RepairSpeed = SceneControl.GetComponent<SceneController>().RepairRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth < collision.gameObject.GetComponent<BasicHelicopterController>().MaxHealth)
        {

            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth += RepairSpeed;
        }

    }
}
