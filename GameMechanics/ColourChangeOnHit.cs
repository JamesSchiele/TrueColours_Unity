using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeOnHit : MonoBehaviour
{

    public string colour = "Blank";

    private void OnTriggerEnter(Collider other)
    {
        {
            Debug.Log("Hit detected");
            //Debug.Log(other);

            if (other.gameObject.tag == "Red Laser")
            {
                Debug.Log("Paint me red");
                GetComponent<MeshRenderer>().material.color = Color.red;
                colour = "Red";
            } 
            if (other.gameObject.tag == "Yellow Laser")
            {
                Debug.Log("Paint me yellow");
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                colour = "Yellow";
            } 
            if (other.gameObject.tag == "Blue Laser")
            {
                Debug.Log("Paint me blue");
                GetComponent<MeshRenderer>().material.color = Color.blue;
                colour = "Blue";
            }       
        }
    }
}
