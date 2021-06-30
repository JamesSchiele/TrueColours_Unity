using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadius : MonoBehaviour
{

    // Combat
    SphereCollider playerRadius;

    Transform pos;

    public Vector3 targetDirection;

    public List <Enemy> enemiesCloseBy = new List<Enemy>();


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

    public void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemySpotted = other.GetComponent<Enemy>();

            enemiesCloseBy.Add(enemySpotted);
        }

        for (int i = 0; i < enemiesCloseBy.Count; i++) {Debug.Log(enemiesCloseBy[i]); }
    }

    public void OnTriggerExit(Collider other)
    {   
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemySpotted = other.GetComponent<Enemy>();

            enemiesCloseBy.Remove(enemySpotted);

        }

        for (int i = 0; i < enemiesCloseBy.Count; i++) {Debug.Log(enemiesCloseBy[i]); }
    }
}
