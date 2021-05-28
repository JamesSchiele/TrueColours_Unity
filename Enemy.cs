using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float redHealth = 100f;

    public string colourWeakness;
  

    List<string> listOfTypes = new List<string>()
    {
        "Red",
        "Blue",
        "Yellow"
    };

    void Start() 
    {
        int randInt = Random.Range(1,listOfTypes.Count);

        colourWeakness = listOfTypes[randInt];
    }

    // Update is called once per frame
    void Update()
    {
        colourHitCheck();
    }

    void colourHitCheck()
    {
        string colourTest = GetComponent<ColourChangeOnHit>().colour;

        if(colourTest == colourWeakness)
        {
            GameObject.Destroy(gameObject, 1f);
        }
    }
}
