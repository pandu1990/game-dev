using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertSceneScript : MonoBehaviour {

    public void changeToNextLevel(){
        int level = PlayerPrefs.GetInt("Level");
        level += 1;
        PlayerPrefs.SetInt("Level", level);

        Debug.Log("sceneName to load:  Level " + level);
        SceneManager.LoadScene("Level");
    }

    public void changeToCurrentLevel(){
        int level = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", level);

        Debug.Log("sceneName to load:  Level " + level);
        SceneManager.LoadScene("Level");
    }

    public void loadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void loadLevel(int level)
    {
        //SceneManager.LoadScene("Level " + level);
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene("Level");
    }
}
