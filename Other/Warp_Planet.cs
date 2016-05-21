using UnityEngine;
using System.Collections;

public class Warp_Planet : MonoBehaviour {
    public float speed;
    public string GoToScene;
    UI_PlanetMenu setWarp;
	void Start () {
        GameObject UI_PM = GameObject.FindGameObjectWithTag("UI_Menu");
        if (UI_PM != null)
        {
            print("Connect UI_Menu Complete");
            setWarp = UI_PM.GetComponent<UI_PlanetMenu>();
        }
        else if (UI_PM == null) print("Connect UI_Menu Failed");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 90, 0)* speed * Time.deltaTime);
        GoToScene = setWarp.PlanetName;
    }

    void OnTriggerEnter(Collider player)
    {
       
        if (player.gameObject.CompareTag("Player"))
        {
            //player.gameObject.transform.position = target.transform.position;
            Application.LoadLevel("Scene Anim"+GoToScene);
            //print(GoToScene);
        }
            
    }
}
