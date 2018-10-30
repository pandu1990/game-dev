using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour {
    public List<RectTransform> screens;
    public List<RectTransform> buttons;
    private int currentScreen = 0;
    public bool showTutorial = true;
    private void Awake()
    {
        for (int i = 0; i < screens.Count; i++)
            screens[i].gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        if (showTutorial){
            Time.timeScale = 0;
            ActivateScreen(0);
        }
	}

    public void onSkip(){
        screens[currentScreen].gameObject.SetActive(false);
        showTutorial = false;
        Time.timeScale = 1;
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
    }
    public void GoToNext(){
        ActivateScreen(currentScreen + 1);
    }
    void ActivateScreen(int screen){
        if (currentScreen == 1)
        {
            onSkip();
            Debug.Log("going in");
            return;
        }
        screens[screen].gameObject.SetActive(true);
        if (currentScreen != screen)
        {
            screens[currentScreen].gameObject.SetActive(false);
            currentScreen = screen;
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
