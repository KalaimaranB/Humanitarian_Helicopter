using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    public float SoundEffectsVolume=0.7f;
    public float BackgroundMusicVolume=1f;
    public Slider soundEffectSlider;
    public Slider backgroundMusicSlider;
    public bool IsOpen = false;
    public GameObject SettingsMenu;
    public GameObject HelpIcon;

    private GameObject GameManagement;
    private GameManagement gameManagement;
    // Start is called before the first frame update
    void Start()
    {
        GameManagement = GameObject.FindGameObjectWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();
        SoundEffectsVolume = gameManagement.SoundEffectVolume;
        BackgroundMusicVolume = gameManagement.BackgroundMusicVolume;
        soundEffectSlider.value = gameManagement.SoundEffectVolume;
        backgroundMusicSlider.value = gameManagement.BackgroundMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        gameManagement.SoundEffectVolume = soundEffectSlider.value;
        gameManagement.BackgroundMusicVolume = backgroundMusicSlider.value;
    }

    public void GameSettings() {
        IsOpen = true;
        SettingsMenu.SetActive(true);
    }

    public void Exit()
    {
        IsOpen = false;
        SettingsMenu.SetActive(false);
        HelpIcon.SetActive(false);
    }

    public void HelpMenu()
    {
        HelpIcon.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    public void ExitGame()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }
    public void OpenShop(string UpgradeSceneName)
    {
        SceneManager.LoadSceneAsync(UpgradeSceneName);
    }
}
