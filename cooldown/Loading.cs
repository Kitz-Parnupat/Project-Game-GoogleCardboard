﻿using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
    public string nextScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Application.LoadLevel("" + nextScene);
	}
}
