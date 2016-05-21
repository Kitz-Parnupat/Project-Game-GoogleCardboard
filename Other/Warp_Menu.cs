using UnityEngine;
using System.Collections;

public class Warp_Menu : MonoBehaviour {
    public float speed;
    public string GoToScene;
    UI_PlanetMenu setWarp;
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 180, 0) * speed * Time.deltaTime);  
    }

    void OnTriggerEnter(Collider player)
    {
       
        if (player.gameObject.CompareTag("Player"))
        {
            //player.gameObject.transform.position = target.transform.position;
            Application.LoadLevel(""+GoToScene);
            //print(GoToScene);
        }
            
    }
}
