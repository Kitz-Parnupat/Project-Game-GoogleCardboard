using UnityEngine;
using System.Collections;


public class Underwater : MonoBehaviour {
	public int UnderwaterLevel = 7;

	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDesity;
	private Material defaultSkybox;
	private Material noSkybox;
    PlayerController player;
    AudioSource myAudio;
    public GameObject SoundWindy;
    public bool UnderwaterStatus = false;
    
	// Use this for initialization
	void Start () {
        defaultFog = RenderSettings.fog;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDesity = RenderSettings.fogDensity;
        defaultSkybox = RenderSettings.skybox;
        myAudio = GetComponent<AudioSource>();
        //Material noSkybox;
        Camera.main.backgroundColor = new Color (0, 0.4f, 0.7f, 1);
        GameObject connect = GameObject.FindGameObjectWithTag("Player");
        if (connect != null)
            player = connect.GetComponent<PlayerController>();

        else if (connect == null)
            print("Canot find PlayerController");
    }
	
	// Update is called once per frame
	void Update () {
		if (player.EnterCollider == true) {
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color (0, 0.4f, 0.7f, 0.6f);
			RenderSettings.fogDensity = 0.1f;
            myAudio.enabled = true;
            SoundWindy.gameObject.SetActive(false);
			//RenderSettings.skybox = noSkybox;
		} 
		else {
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDesity;
            myAudio.enabled = false;
            SoundWindy.gameObject.SetActive(true);
            //RenderSettings.skybox = defaultSkybox;
        }
        
	}
}
