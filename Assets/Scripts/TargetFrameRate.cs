﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
