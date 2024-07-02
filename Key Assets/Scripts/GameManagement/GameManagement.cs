using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof (AudioSource))]
public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance;
    [Header("Set Size to Number of Levels Plus 1")]
    public GameLevel.levelStatus tutorialStatus = GameLevel.levelStatus.Unlocked;
    public List<GameLevel> gameLevels;

    [Header("Settings")]
    public float SoundEffectVolume = 0.7f;
    public float BackgroundMusicVolume = 1f;

    [Header("Transport Helicopter")]
    public GameObject TransportHelicopter;
    public float THFuelEfficiency;
    public float THMaxFuel;
    public int THMaxPeople;
    public int THCrateContent;

    [Header("Gunship")]
    public GameObject Gunship;
    public float GFuelEfficiency;
    public float GMaxFuel;
    public float GMissileDamage;
    public float GMissileSpeed;

    public int Coins = 0;
    public bool paid = false;
    public GameObject Coin;


    AudioSource AS;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.volume = SoundEffectVolume;
    }

  

    // Update is called once per frame
    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        AS.volume = SoundEffectVolume;

        for (var i=0;i<gameLevels.Count;i++)
        {
            if (gameLevels[i].status == GameLevel.levelStatus.Complete)
            {
                if (i!=gameLevels.Count-1)
                {
                    if (gameLevels[i+1].status!=GameLevel.levelStatus.Complete)
                    {
                        gameLevels[i + 1].status = GameLevel.levelStatus.Unlocked;
                    }
                }
            }
        }

        if (sceneName == "WinScene" && paid == false)
        {
            paid = true;
            GameObject WinCoins = GameObject.FindGameObjectWithTag("WinCoins");
            Coins += WinCoins.GetComponent<WinScene>().Coins;
            WinCoins.SetActive(false);
        }
        if (sceneName == "LevelSelect")
        {
            paid = false;
        }
    }

    [System.Serializable]
    public class GameLevel
    {
        public enum levelStatus {Locked, Unlocked, Complete};
        public int Number;
        public levelStatus status;
        public Level level;
    }

}
