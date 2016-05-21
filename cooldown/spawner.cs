using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//d[ExecuteInEditMode]
public class spawner : MonoBehaviour
{
    public Radial_Slider slider;
    public Button button;
    public Transform prefab;

    public float delay;
    void Start()
    {
        button.onClick.AddListener(OnClick);
        button.interactable = true;

        slider.maxValue = delay;
        slider.value = 0;
    }
    void OnClick()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        print("กด");
        StartCoroutine(OnUpdateRoutine());
    }

    IEnumerator OnUpdateRoutine()
    {
        slider.maxValue = delay;
        slider.value = 0;
        button.interactable = false;
        float deltaTime = Time.deltaTime;
        for(float i =0; i<delay ;i+= deltaTime)
        {
            slider.value = i;
            yield return new WaitForSeconds(deltaTime);
        }
        slider.value = delay;
        button.interactable = true;
    }
}
