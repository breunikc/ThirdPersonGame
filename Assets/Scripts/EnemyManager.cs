using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    // contains all possible spawn points
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        // call Spawn() every 'spawn time'
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // pick a random spawn point and spawn another enemy
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // what to spawn, where to spawn, rotation when spawned
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

}
