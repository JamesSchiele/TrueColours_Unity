using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeOnHit : MonoBehaviour
{

    public string colour = "Blank";

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.tag == "Red Laser")
            {
                GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
                colour = "Red";
            } 
            if (other.gameObject.tag == "Yellow Laser")
            {
                GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
                colour = "Yellow";
            } 
            if (other.gameObject.tag == "Blue Laser")
            {
                GetComponent<SkinnedMeshRenderer>().material.color = Color.cyan;
                colour = "Blue";
            }       
        }
    }
}
