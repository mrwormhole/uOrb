using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {

    public  GameObject MainScreen;
    public GameObject InfoScreen;
    public GameObject LevelScreen;

    //public bool[] tempAccessListForLevels;

    public void ShowLevelsToPlayer()
    {
        MainScreen.SetActive(false);
        LevelScreen.SetActive(true);
    }

    public void LoadScene(int sceneIndexNumber)
    {
        SceneManager.LoadScene(sceneIndexNumber); 
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSettingsScreen()
    {
        //pause
    }

    public void LoadInfoScreen()
    {
        MainScreen.SetActive(false);
        InfoScreen.SetActive(true);
    }

}
