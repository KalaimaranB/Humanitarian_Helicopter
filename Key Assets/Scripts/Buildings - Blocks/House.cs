using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject ThankYou;
    private Vector3 Offset = new Vector3(0,1,0);
    public int RequiredCrates = 1;
    public int ReceivedCrates = 0;
    private bool Fixed = false;
    private int CrateContents;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if (ReceivedCrates>=RequiredCrates && Fixed == false)
        {
            Fixed = true;
            Instantiate(ThankYou, transform.position + Offset, ThankYou.transform.rotation);
            MessageBoard.SendMessageToBoard("Completed delivery to House!");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SupplyCrate")
        {
            CrateContents = GameObject.FindObjectOfType<TransportCopter>().CrateContent;
            ReceivedCrates += CrateContents;
        }
    }
}
