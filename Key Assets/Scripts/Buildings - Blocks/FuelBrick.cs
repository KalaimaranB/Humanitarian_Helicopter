using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBrick : MonoBehaviour
{
    private float RefuelSpeed=1;

    private GameObject SceneControl;
    private SceneController sceneControl;
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();

        RefuelSpeed = SceneControl.GetComponent<SceneController>().RefuelRate;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().CurrentFuel<collision.gameObject.GetComponent<BasicHelicopterController>().MaxFuel)
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentFuel += RefuelSpeed;
        }

    }

}
