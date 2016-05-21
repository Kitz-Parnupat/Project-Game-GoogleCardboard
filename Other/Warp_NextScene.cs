using UnityEngine;
using System.Collections;

public class Warp_NextScene : MonoBehaviour {
    public float speed, rotation;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotation, 0) * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.CompareTag("Player"))
        {
            //player.gameObject.transform.position = target.transform.position;
            Application.LoadLevel("Scene Question");
            //print(GoToScene);
        }

    }
}
