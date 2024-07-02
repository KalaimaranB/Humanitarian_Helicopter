using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public UpgradesManager.UpgradeLevels currentLevel = UpgradesManager.UpgradeLevels.Level0;
    public GameObject Level1, Level2, Level3;
    public Text Level1Cost, Level2Cost, Level3Cost;
    public int L1Price, L2Price, L3Price;


    [HideInInspector]
    public Button.ButtonClickedEvent Level1Event;
    [HideInInspector]
    public Button.ButtonClickedEvent Level2Event;
    [HideInInspector]
    public Button.ButtonClickedEvent Level3Event;


    public void Start()
    {
        SetValues(L1Price, L2Price, L3Price);
    }

    public void AssignButtonFunctions()
    {
        Level1.GetComponent<Button>().onClick = Level1Event;
        Level2.GetComponent<Button>().onClick = Level2Event;
        if (Level3 != null)
        {
            Level3.GetComponent<Button>().onClick = Level3Event;
        }
    }

    public void SetValues(int L1Cost, int L2Cost, int L3Cost)
    {
        Level1Cost.text = "Cost: " + L1Cost + " Coins";
        Level2Cost.text = "Cost: " + L2Cost + " Coins";
        if (Level3!=null)
        {
            Level3Cost.text = "Cost: " + L3Cost + " Coins";
        }
    }

    public void Upgrade(UpgradesManager.UpgradeLevels level)
    {
        currentLevel = level;
        if (level == UpgradesManager.UpgradeLevels.Level1)
        {
            Level1.SetActive(false);
        }
        else if (level == UpgradesManager.UpgradeLevels.Level2)
        {
            Level2.SetActive(false);
        }
        else if (level == UpgradesManager.UpgradeLevels.Level3)
        {
            Level3.SetActive(false);
        }
    }

    public void UpdateUI(UpgradesManager.UpgradeLevels lvl)
    {
        switch (lvl)
        {
            case UpgradesManager.UpgradeLevels.Level0:
                //No upgrades done, so do nothing
                break;

            case UpgradesManager.UpgradeLevels.Level1:
                Level1.SetActive(false);
                break;

            case UpgradesManager.UpgradeLevels.Level2:
                Level1.SetActive(false);
                Level2.SetActive(false);
                break;

            case UpgradesManager.UpgradeLevels.Level3:
                Level1.SetActive(false);
                Level2.SetActive(false);
                Level3.SetActive(false);
                break;

            default:
                break;
        }
    }
}



