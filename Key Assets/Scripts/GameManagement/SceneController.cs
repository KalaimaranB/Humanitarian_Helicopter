using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameObject[] StartHouseCount;
    private GameObject[] StartDragonCount;
    private GameObject[] LiveDragonCount;
    private GameObject[] FinishedHouseCount;

    public int NumOfHouses;
    public int NumOfFinishedHouse;
    public int NumOfDragons;
    public int LiveNumOfDragons;
    public GameObject[] Players;
    public GameObject CurrentPlayer;

    [Header("Player")]
    public float RefuelRate;
    public float RepairRate;

    public GameObject canvas;
    public GameObject SettingsMenu;
    public bool GameIsPaused = false;

    private GameObject MainPlayer;

    [Header("Management")]
    public bool Win = false;
    public int Level;
    private GameObject GameManagement;

    [Header("Objectives")]
    public bool FinishAllHouses = true;
    public bool KillAllDragons = false;
    public bool RescueAllPeople = false;
    private bool FAHDone = false;
    private bool KALDone = false;
    private bool RAPDone = false;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentPlayer = Players[0];
        StartHouseCount = GameObject.FindGameObjectsWithTag("House");
        StartDragonCount = GameObject.FindGameObjectsWithTag("Dragon");
        NumOfHouses = StartHouseCount.Length;
        NumOfDragons = StartDragonCount.Length;
        MainPlayer = Players[0];
        GameManagement = GameObject.FindGameObjectWithTag("GameManagement");
        GameManagement gm = GameManagement.GetComponent<GameManagement>();
        gm.TransportHelicopter = Players[0];
        if (Players.Length > 1)
        {
            gm.Gunship = Players[1];
        }

        BasicHelicopterController TC = Players[0].GetComponent<BasicHelicopterController>(); ;

        TC.FuelConsumptionRate = gm.THFuelEfficiency;
        TC.MaxFuel = gm.THMaxFuel;
        Players[0].GetComponent<TransportCopter>().MaxPeople = gm.THMaxPeople;
        Players[0].GetComponent<TransportCopter>().CrateContent = gm.THCrateContent;
    }

    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        GameIsPaused = canvas.GetComponent<Settings>().IsOpen;

        LiveDragonCount = GameObject.FindGameObjectsWithTag("Dragon");
        LiveNumOfDragons = LiveDragonCount.Length;

        FinishedHouseCount = GameObject.FindGameObjectsWithTag("ThankYou");
        NumOfFinishedHouse = FinishedHouseCount.Length;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentPlayer = Players[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentPlayer = Players[1];
        }
        if (NumOfFinishedHouse == NumOfHouses || FinishAllHouses == false)
        {
            FAHDone = true;
        }
        if (LiveNumOfDragons == 0 || KillAllDragons == false)
        {
            KALDone = true;
        }
        if ((GameObject.FindGameObjectsWithTag("People").Length == 0 && MainPlayer.GetComponent<TransportCopter>().CurrentPeople<=0)|| RescueAllPeople == false)
        {
            RAPDone = true;
        }



        if (FAHDone == true && KALDone == true && RAPDone == true)
        {
            Win = true;
        }

        if (MainPlayer == null)
        {
            Win = false;
            SceneManager.LoadScene("LoseScene");
        }
        if (MainPlayer.GetComponent<BasicHelicopterController>().CurrentFuel <= 0 || MainPlayer.GetComponent<BasicHelicopterController>().CurrentHealth <= 0)
        {
            Win = false;
            SceneManager.LoadScene("LoseScene");
        }
        if (Win == true)
        {
            //If not tutorial
            if (Level != 0)
            {
                GameManagement.GetComponent<GameManagement>().gameLevels[Level - 1].status = global::GameManagement.GameLevel.levelStatus.Complete;
                List<global::GameManagement.GameLevel> gameLevels = GameManagement.GetComponent<GameManagement>().gameLevels;
                if (gameLevels.Count<=Level)
                {
                    GameManagement.GetComponent<GameManagement>().gameLevels[Level].status = global::GameManagement.GameLevel.levelStatus.Unlocked;
                }
                SceneManager.LoadSceneAsync("WinScene");
            }
            //If tutorial
            if (Level == 0)
            {
                GameManagement.GetComponent<GameManagement>().tutorialStatus = global::GameManagement.GameLevel.levelStatus.Complete;
                GameManagement.GetComponent<GameManagement>().gameLevels[0].status = global::GameManagement.GameLevel.levelStatus.Unlocked;
                SceneManager.LoadSceneAsync("WinScene");
            }
        }

    }
}
