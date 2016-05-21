using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {
    public GameObject Asteroid;
    public Vector3 SpawnValues;
    public int objCount;
    public int startwait;
    public float xMin, xMax, zMin, zMax;
    public bool spawX, SpawZ;
    void Start () {
        StartCoroutine(SpawnWave()); 
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            for (int i = 0; i < objCount; i++)
            {
                Vector3 spawnPostionx = new Vector3(Random.Range(xMin,xMax), SpawnValues.y, SpawnValues.z);
                //Vector3 spawnPostiony = new Vector3(Random.Range(100,50),SpawnValues.x, SpawnValues.z);
                Vector3 spawnPostionz = new Vector3(Random.Range(zMin, zMax), SpawnValues.x, SpawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                if(spawX == true) Instantiate(Asteroid, spawnPostionx, spawnRotation);
                //Instantiate(Asteroid, spawnPostiony, spawnRotation);
                if(SpawZ == true) Instantiate(Asteroid, spawnPostionz, spawnRotation);

                // yield return new WaitForSeconds(startwait);
            }
            yield return new WaitForSeconds(startwait);
        }
    }
}
