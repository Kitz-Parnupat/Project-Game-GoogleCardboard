using UnityEngine;
using System.Collections;

public class SpacraftRing_Roll : MonoBehaviour {
    public float speed,rotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotation, 0) * speed * Time.deltaTime);
    }
}
