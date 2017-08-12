using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour {

    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;
    public AudioSource aou;

    public GameObject enemy;
    BasicEnemy basicEnemy;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        basicEnemy = enemy.GetComponent<BasicEnemy>();
        playerInTerritory = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInTerritory)
        {
            basicEnemy.MoveToPlayer();

        }
        if (!playerInTerritory) basicEnemy.Rest();
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = true;
            aou.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) playerInTerritory = false;
    }
}
