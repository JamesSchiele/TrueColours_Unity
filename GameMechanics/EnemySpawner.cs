using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    // Update is called once per frame
    void Start()
    {
        enemy = GameObject.Instantiate(enemy) as GameObject;
    }
}
