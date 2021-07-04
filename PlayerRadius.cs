using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadius : MonoBehaviour
{

    // Combat
    SphereCollider playerRadius;

    Transform pos;

    public Vector3 targetDirection;

    public List <GameObject> enemiesCloseBy = new List<GameObject>();
    public Transform targetedEnemypos;
    int i = 0;


    float speed = 1.0f;

    // Player
    public GameObject player;

    void Start()
    {
        playerRadius = GetComponent<SphereCollider>();
    }

    void Update()
    {
        //Debug.Log(enemiesCloseBy.Count);
    }

    public void OnTriggerEnter(Collider enemy)
    {   
        if (enemy.gameObject.tag == "Enemy")
        {
            GameObject enemySpotted = enemy.gameObject;

            enemiesCloseBy.Add(enemySpotted);

            for (int i = 0; i < enemiesCloseBy.Count; i++) 
            {
                // Debug.Log("Enter "+ enemiesCloseBy[i]); 
            }
        }
    }

    public void OnTriggerExit(Collider enemy)
    {   
        if (enemy.gameObject.tag == "Enemy")
        {
            GameObject enemySpotted = enemy.gameObject;

            enemiesCloseBy.Remove(enemySpotted);

            for (int i = 0; i < enemiesCloseBy.Count; i++) {Debug.Log("Exit " + enemiesCloseBy[i]); }
        }
    }

    public void CycleThroughEnemiesInRadius()
    {
        Debug.Log(enemiesCloseBy[i].transform);

        targetedEnemypos = enemiesCloseBy[i].transform; // Assign current equipped laser to laserColour list selected index

        i ++; // Increment on mouse(1) press        

        if(i > enemiesCloseBy.Count - 1) // Return count to 0 when you have cycled through list
        {
            i = 0;
        }
    }
}
