using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour {


    private Button thisButton;
    private ConvertSceneScript convertScene;
    [SerializeField] int level;
	// Use this for initialization
    void Start () {
        convertScene = FindObjectOfType<ConvertSceneScript>();
        thisButton = GetComponent<Button>();
        thisButton.GetComponentInChildren<Text>().text = level.ToString();
        thisButton.onClick.AddListener(delegate {
            PlayerPrefs.SetInt("Level", level);
            SwitchLevel(level);
        });
	}

    void SwitchLevel(int level) {
        Debug.Log(level);
        convertScene.loadLevel(level);
    }
}
