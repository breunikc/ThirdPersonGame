using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 25;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= .5f && playerInRange)
        {
            print(" EA attack");
            Attack();
        }
        if (playerHealth.currentHealth <= 0)
        {
            // kill the player
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            print("attack!");
            playerHealth.TakeDamge(attackDamage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("here");
        if (other.gameObject == player)
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = false;
    }


}
