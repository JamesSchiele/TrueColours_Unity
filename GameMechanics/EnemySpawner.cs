using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;

    // List<enemyColour> listOfEnemyTypes = new List<enemyColour>()
    // {
    //     new enemyColour() { Type = "Red"},
    //     new enemyColour() { Type = "Blue"},
    //     new enemyColour() { Type = "Yellow"}
    // };

    // Update is called once per frame

    void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            int randX = Random.Range(-25,25);
            int randZ = Random.Range(-25,25);

            Instantiate(Enemy, new Vector3(randX, 0f, randZ), Quaternion.identity);
        }

        // Enemy = GameObject.Instantiate(Enemy, new Vector3()) as GameObject;

        // int randInt = Random.Range(1,listOfTypes.Count);

        // Debug.Log(listOfTypes[randInt]);

        int objects = GameObject.FindObjectsOfType(typeof(Enemy)).Length;

        Debug.Log(objects);
    }
}
