using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSceneDataManager : MonoBehaviour
{
    public UpgradeUI UpgradeMaxPeople;
    public UpgradeUI UpgradeFuelEfficiency;
    public UpgradeUI UpgradeMaxFuel;
    public UpgradeUI UpgradeCrateContent;

    public Text coinsText;
    public WarningPanel wp;

    private UpgradesManager um;
    public void Start()
    {
        um = GameObject.FindObjectOfType<UpgradesManager>();
        if (um!=null)
        {
            UpdateUIS(um);
            um.UpgradeMaxPeopleUI = UpgradeMaxPeople;
            UpgradeMaxPeople.currentLevel = um.UTHMPCurrentLevel;

            um.UpgradeTHFuelEfficiencyUI = UpgradeFuelEfficiency;
            UpgradeFuelEfficiency.currentLevel = um.UTHFECurrentLevel;

            um.UpgradeTHMaxFuelUI = UpgradeMaxFuel;
            UpgradeMaxFuel.currentLevel = um.UTHMFCurrentLevel;

            um.UpgradeTHCrateContentUI = UpgradeCrateContent;
            UpgradeCrateContent.currentLevel = um.UTCCCurrentLevel;

            um.warningPanel = wp;
            um.UpdateUpgradeButtonUIs();
        }
        else
        {
            Debug.LogWarning("There is no Upgrades Manager in the scene! This scene won't function without it!");
        }
    }

    public void Update()
    {
        if (um!=null)
        {
            coinsText.text = "You have : " + um.gm.Coins + " coins";
        }
    }

    public void UpdateUIS(UpgradesManager UM)
    {
        UpgradeMaxPeople.UpdateUI(UM.UTHMPCurrentLevel);
        UpgradeFuelEfficiency.UpdateUI(UM.UTHFECurrentLevel);
        UpgradeMaxFuel.UpdateUI(UM.UTHMFCurrentLevel);
        UpgradeCrateContent.UpdateUI(UM.UTCCCurrentLevel);
    }
}
