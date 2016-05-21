using UnityEngine;
using System.Collections;

public class Warp_Roll : MonoBehaviour {
    public float speed;
    public GameObject target;
    //public string GoToScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 90, 0)* speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            player.gameObject.transform.position = target.transform.position;
           // player.gameObject.transform.rotation = target.transform.rotation;
            //Application.LoadLevel("Scene " + GoToScene);
        }
            
    }
}
