using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeOnHit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        {
            Debug.Log("Hit detected");
            //Debug.Log(other);

            if (other.gameObject.tag == "Red Laser")
            {
                Debug.Log("Paint me red");
                GetComponent<MeshRenderer>().material.color = Color.red;
            } 
            if (other.gameObject.tag == "Yellow Laser")
            {
                Debug.Log("Paint me yellow");
                GetComponent<MeshRenderer>().material.color = Color.yellow;
            } 
            if (other.gameObject.tag == "Blue Laser")
            {
                Debug.Log("Paint me blue");
                GetComponent<MeshRenderer>().material.color = Color.blue;
            }       
        }
    }
}
