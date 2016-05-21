using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cooldown : MonoBehaviour {
    public Image filled;
    public Text text;

    public float maxValue = 100;
    public float value = 0;
  
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        value = Mathf.Clamp(value, 0, maxValue);
        float amount = value / maxValue;

        filled.fillAmount = amount;
        text.text = Mathf.RoundToInt(value).ToString()+ "%";
	}
}
