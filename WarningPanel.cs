using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningPanel : MonoBehaviour
{
    public Text warningText;


    public void AssignWarningText(string newText)
    {
        warningText.text = newText;
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
