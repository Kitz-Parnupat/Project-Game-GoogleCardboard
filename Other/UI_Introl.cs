using UnityEngine;
using System.Collections;

public class UI_Introl : MonoBehaviour {
    public GameObject UI_Tutorial,SpaceCraft;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InputBT(string GetInput)
    {
        if (GetInput == "Yes") Application.LoadLevel("Scene Tutorial");
        else if (GetInput == "No") Application.LoadLevel("Scene SpaceCraft");
    }

    public void RunUI()
    {
        //SpaceCraft.gameObject.SetActive(false);
        UI_Tutorial.gameObject.SetActive(true);
    }
    
}
