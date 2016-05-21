using UnityEngine;
using System.Collections;

public class MissionRoom : MonoBehaviour {
    public GameObject UI;
    PlayerController player;
    public bool movePlayer;
	// Use this for initialization
	void Start () {
        UI.gameObject.SetActive(false);
        GameObject Connect = GameObject.FindGameObjectWithTag("Player");
        if (Connect != null)
            player = Connect.GetComponent<PlayerController>();
        else if (Connect == null)
            print("Cannot Find PlayerController");
        movePlayer = true;
    }
	
	// Update is called once per frame
	void Update () {
        player.MoveControl = movePlayer;
	}
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            UI.gameObject.SetActive(true);
            movePlayer = false;
        }
    }
    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            UI.gameObject.SetActive(false);
            movePlayer = true;
        }
    }
}
