using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    List<string> listOfTypes = new List<string>()
    {
        "Red",
        "Blue",
        "Yellow"
    };

    // List<enemyColour> listOfEnemyTypes = new List<enemyColour>()
    // {
    //     new enemyColour() { Type = "Red"},
    //     new enemyColour() { Type = "Blue"},
    //     new enemyColour() { Type = "Yellow"}
    // };

    // Update is called once per frame

    void Start()
    {
        enemy = GameObject.Instantiate(enemy) as GameObject;

        int randInt = Random.Range(1,listOfTypes.Count);

        Debug.Log(listOfTypes[randInt]);
    }
}
