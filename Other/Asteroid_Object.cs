using UnityEngine;
using System.Collections;

public class Asteroid_Object : MonoBehaviour {
    public GameObject explosion;
    private int speed;
    public float tumble;
    public int SpeedMin, SpeedMax;
    public bool Set_Move = false;
    public bool Set_Rotation = false;

	// Use this for initialization
	void Start () {
            AsteriodMove();
            AsteriodRotation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void AsteriodMove()
    {
        speed = Random.Range(SpeedMin, SpeedMax);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void AsteriodRotation()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Area")
        {
            Destroy(gameObject);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
