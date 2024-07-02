using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{

    /*
     - Have this manager somehow find the upgradeUIs upon start, so that it will find any required references
     - Every time you leave this scene, local references are lost, so they need to be reassigned. 
     */
    [HideInInspector]
    public GameManagement gm;
    public enum UpgradeLevels { Level0, Level1, Level2, Level3 };


    [Header("Upgrade Max People")]
    public UpgradeUI UpgradeMaxPeopleUI;
    public UpgradeLevels UTHMPCurrentLevel;

    [Header("Upgrade TH Fuel Efficiency")]
    public UpgradeUI UpgradeTHFuelEfficiencyUI;
    public UpgradeLevels UTHFECurrentLevel;

    [Header("Upgrade TH Max Fuel")]
    public UpgradeUI UpgradeTHMaxFuelUI;
    public UpgradeLevels UTHMFCurrentLevel;

    [Header("Upgrade TH Crate Content")]
    public UpgradeUI UpgradeTHCrateContentUI;
    public UpgradeLevels UTCCCurrentLevel;

    public WarningPanel warningPanel;

    public delegate void upgradeDelegate();
    public upgradeDelegate IncreaseTHelicopterMaxPeople;
    public upgradeDelegate IncreaseTHFuelEfficiency;
    public upgradeDelegate IncreaseTHMaxFuel;
    public upgradeDelegate IncreaseTHCrateContent;

    // Start is called before the first frame update
    void Start()
    {
        IncreaseTHelicopterMaxPeople = delegate {
            gm.THMaxPeople += 5;
	    };
        IncreaseTHFuelEfficiency = delegate {
            gm.THFuelEfficiency -= 0.1f;
    	};
        IncreaseTHMaxFuel = delegate
        {
            gm.THMaxFuel += 1000;
        };
        IncreaseTHCrateContent = delegate {

            gm.THCrateContent += 1;
    	};


        if (gameObject.GetComponent<GameManagement>())
        {
            gm = gameObject.GetComponent<GameManagement>();
        }
        else
        {
            Debug.LogWarning("The upgrade manager component should be on the gameManagement component! Please place it on the right gameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateUpgradeButtonUIs()
    {
        UpgradeMaxPeopleUI.Level1Event.AddListener(delegate { UpgradeMaxPeopleLvl(1); });
        UpgradeMaxPeopleUI.Level2Event.AddListener(delegate { UpgradeMaxPeopleLvl(2); });
        UpgradeMaxPeopleUI.Level3Event.AddListener(delegate { UpgradeMaxPeopleLvl(3); });
        UpgradeMaxPeopleUI.AssignButtonFunctions();

        UpgradeTHFuelEfficiencyUI.Level1Event.AddListener(delegate { UpgradeTHFuelEfficiency(1); });
        UpgradeTHFuelEfficiencyUI.Level2Event.AddListener(delegate { UpgradeTHFuelEfficiency(2); });
        UpgradeTHFuelEfficiencyUI.Level3Event.AddListener(delegate { UpgradeTHFuelEfficiency(3); });
        UpgradeTHFuelEfficiencyUI.AssignButtonFunctions();

        UpgradeTHMaxFuelUI.Level1Event.AddListener(delegate { UpgradeTHMaxFuel(1); });
        UpgradeTHMaxFuelUI.Level2Event.AddListener(delegate { UpgradeTHMaxFuel(2); });
        UpgradeTHMaxFuelUI.Level3Event.AddListener(delegate { UpgradeTHMaxFuel(3); });
        UpgradeTHMaxFuelUI.AssignButtonFunctions();

        UpgradeTHCrateContentUI.Level1Event.AddListener(delegate { UpgradeTHCrateContent(1); });
        UpgradeTHCrateContentUI.Level2Event.AddListener(delegate { UpgradeTHCrateContent(2); });
        UpgradeTHCrateContentUI.AssignButtonFunctions();
    }

    public void UpgradeTHMaxFuel(int level)
    {
        CompleteUpgrade(level, IncreaseTHMaxFuel, UpgradeTHMaxFuelUI, ref UTHMFCurrentLevel);
    }

    public void UpgradeTHCrateContent(int level)
    {
        CompleteUpgrade(level, IncreaseTHCrateContent, UpgradeTHCrateContentUI, ref UTCCCurrentLevel);
    }

    public void UpgradeMaxPeopleLvl(int level)
    {
        CompleteUpgrade(level, IncreaseTHelicopterMaxPeople, UpgradeMaxPeopleUI, ref UTHMPCurrentLevel);
    }

    public void UpgradeTHFuelEfficiency(int level)
    {
        CompleteUpgrade(level, IncreaseTHFuelEfficiency, UpgradeTHFuelEfficiencyUI, ref UTHFECurrentLevel);
    }

    private void UpgradeLevel(UpgradeLevels level, UpgradeUI uI)
    {
        switch (level)
        {
            case UpgradeLevels.Level1:
                gm.Coins -= uI.L1Price;
                uI.Level1.SetActive(false);
                break;

            case UpgradeLevels.Level2:
                gm.Coins -= uI.L2Price;
                uI.Level2.SetActive(false);
                break;


            case UpgradeLevels.Level3:
                gm.Coins -= uI.L3Price;
                uI.Level3.SetActive(false);

                break;
            default:
                break;
        }
        uI.Upgrade(level);
    }

    private void CompleteUpgrade(int level, upgradeDelegate UDelegate, UpgradeUI upgradeUI, ref UpgradeLevels levelToUpgrade)
    {
        switch (level)
        {
            case 1:
                if (upgradeUI.currentLevel == UpgradeLevels.Level0)
                {
                    if (gm.Coins >= upgradeUI.L1Price)
                    {
                        UDelegate();
                        UpgradeLevel(UpgradeLevels.Level1, upgradeUI);
                        levelToUpgrade = UpgradeLevels.Level1;
                    }
                    else
                    {
                        CallWarning("You don't have enough money. Earn some more coins first!");
                    }
                }
                else
                {
                    warningPanel.AssignWarningText("You can only upgrade in order!");
                }
                break;

            case 2:
                if (upgradeUI.currentLevel == UpgradeLevels.Level1)
                {
                    if (gm.Coins >= upgradeUI.L2Price)
                    {
                        UDelegate();
                        UpgradeLevel(UpgradeLevels.Level2, upgradeUI);
                        levelToUpgrade = UpgradeLevels.Level2;
                    }
                    else
                    {
                        CallWarning("You don't have enough money. Earn some more coins first!");
                    }
                }
                else
                {
                    CallWarning("Complete the Level 1 upgrade first!");
                }
                break;

            case 3:
                if (upgradeUI.currentLevel == UpgradeLevels.Level2)
                {
                    if (gm.Coins >= upgradeUI.L3Price)
                    {
                        UDelegate();
                        UpgradeLevel(UpgradeLevels.Level3, upgradeUI);
                        levelToUpgrade = UpgradeLevels.Level3;
                    }
                    else
                    {
                        CallWarning("You don't have enough money. Earn some more coins first!");
                    }
                }
                else
                {
                    CallWarning("Complete the Level 2 upgrade first!");
                }
                break;

            default:
                Debug.LogError(level + " --> This is not a valid level!");
                break;
        }
    }

    private void CallWarning(string text)
    {
        warningPanel.gameObject.SetActive(true);
        warningPanel.AssignWarningText(text);
    }
}
