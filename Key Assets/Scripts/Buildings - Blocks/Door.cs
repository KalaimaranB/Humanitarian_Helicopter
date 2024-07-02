using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float DestructTime;
    private GameObject Player;

    private GameObject SceneControl;
    private SceneController sceneControl;

    public GameObject LoadingCanvas;
    public bool opening = false;

    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DestructTime<=0)
        {
            Player.GetComponent<BasicHelicopterController>().KeyCount -= 1;
            MessageBoard.SendMessageToBoard("Unlocked Door!");
            Destroy(gameObject);
        }

        if (opening == true)
        {
            LoadingCanvas.SetActive(true);
        }
        else if (opening == false)
        {
            LoadingCanvas.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().KeyCount>0)
        {
            Player = collision.gameObject;
            DestructTime -= 1;
            opening = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter" && collision.gameObject.GetComponent<BasicHelicopterController>().KeyCount > 0)
        {
            opening = false;
        }
    }
}
