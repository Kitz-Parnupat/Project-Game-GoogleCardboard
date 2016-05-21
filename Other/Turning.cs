using UnityEngine;
using System.Collections;

public class Turning : MonoBehaviour {
    CardboardHead head = null;
   // public Transform GameCamera;
    // Use this for initialization
    void Start () {
        head = Camera.main.GetComponent<StereoController>().Head;
    }
	
	// Update is called once per frame
	void Update () {
        var CharacterRotation = head.transform.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.z = 0;
        transform.rotation = CharacterRotation;
        
    }
    public void Roll()
    {
       
    }
}
