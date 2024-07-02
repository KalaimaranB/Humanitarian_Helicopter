using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public int PeopleCount;
    public float RemainingTime  = 500;

    public float TotalRetrieveTime =500;

    [Header("People")]
    public GameObject Person1;
    public GameObject Person2;
    public GameObject Person3;
    public GameObject Person4;
    public GameObject Person5;

    public bool Loading = false;

    public GameObject LoadingCanvas;

    private void Start()
    {
        RemainingTime = TotalRetrieveTime;
        if (RemainingTime !=500)
        {
            Debug.LogWarning("The people might not load properly. Please make sure TotalRetrieveTime = 500");
        }
        if (PeopleCount != 5)
        {
            Debug.LogWarning("The total people must be 5. It can not be anything else.");
        }
    }

    void Update()
    {
        if (RemainingTime <=400)
        {
            Destroy(Person1);
        }
        if (RemainingTime  <= 300)
        {
            Destroy(Person2);
        }
        if (RemainingTime  <= 200)
        {
            Destroy(Person3);
        }
        if (RemainingTime  <= 100)
        {
            Destroy(Person4);
        }
        if (RemainingTime  <=0)
        {
            Destroy(Person5);
        }

        if (Loading == true)
        {
            LoadingCanvas.SetActive(true);
        }
        else if (Loading == false)
        {
            LoadingCanvas.SetActive(false);
        }
    }

    public void ActivateLoading()
    {
        Loading = true;
    }
}
