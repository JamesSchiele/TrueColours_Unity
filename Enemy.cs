using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 100;

    public string colourWeakness;

    public GameObject colourTrail;

    public GameObject hitEffect;

    public Transform LockOnTransform;

    bool shieldUp = true;
    [SerializeField] float downedShieldsTime = 5f;

    [SerializeField] TextMeshProUGUI weakToColour;

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

        weakToColour.text = colourWeakness.ToString();

        Color colourTrailInstance = colourTrail.GetComponent<MeshRenderer>().material.color;

        if (colourWeakness == "Red")
        {
            colourTrailInstance = Color.red;
        }
        else if (colourWeakness == "Blue")
        {
            colourTrailInstance = Color.blue;
        }
        else
        {
            colourTrailInstance = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        colourHitCheck();

        // canvasTest();
    }

    void colourHitCheck()
    {
        string colourTest = GetComponent<ColourChangeOnHit>().colour;

        if(colourTest == colourWeakness)
        {
            Debug.Log("Hit");

            StartCoroutine("disableShieldsForTime");
        }
    }

    IEnumerator disableShieldsForTime()
    {
        shieldUp = false;
        yield return new WaitForSeconds(downedShieldsTime);
        shieldUp = true;
    }

    void OnCollisionExit(Collision other)
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void TakeDamage()
    {
        health =- 25;

        if(health <= 0)
        {
            GameObject.Destroy(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FiringPoint")
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * 1f, Color.red);

            Debug.Log("Melee landed");
            TakeDamage();
        }
    }

}
