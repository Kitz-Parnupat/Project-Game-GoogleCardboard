using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]
public class Radial_Slider : MonoBehaviour
{
    public Image filled;
    public Text text;
    public float maxValue = 100;
    public float value = 0;
    public bool textReversed = false;
    // Use this for initialization
       // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp(value, 0, maxValue);
        float amount = value / maxValue;
        filled.fillAmount = amount;
        float time = (textReversed) ? (maxValue - value) : value;
        text.text = Mathf.RoundToInt(value).ToString();
    }
}
