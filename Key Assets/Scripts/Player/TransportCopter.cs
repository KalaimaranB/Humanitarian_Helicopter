using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCopter : MonoBehaviour
{
    public GameObject SupplyCrate;
    private Vector3 CratePosOffset = new Vector3(0, -2, 0);
    public int MaxNumOfCrates = 1;

    private GameObject CurrentPlayer;

    public int MaxPeople = 10;
    public int CurrentPeople;
    public int CrateContent;
    private int PeopleToPickUp;


    private GameObject SceneControl;
    private SceneController sceneControl;
    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPlayer = sceneControl.CurrentPlayer;

        if (gameObject == CurrentPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                if (GameObject.FindGameObjectsWithTag("SupplyCrate").Length < MaxNumOfCrates)
                {
                    Instantiate(SupplyCrate, transform.position + CratePosOffset, SupplyCrate.transform.rotation);
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "People")
        {
            if (CurrentPeople<MaxPeople)
            {
                collision.gameObject.GetComponent<People>().RemainingTime  -= 1;
                collision.gameObject.GetComponent<People>().ActivateLoading();
            }

            if (collision.gameObject.GetComponent<People>().RemainingTime <=0)
            {
                CurrentPeople += collision.gameObject.GetComponent<People>().PeopleCount;
                MessageBoard.SendMessageToBoard("All people have been now rescued!");
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "People")
        {
            collision.gameObject.GetComponent<People>().Loading = false;
        }
    }
}
