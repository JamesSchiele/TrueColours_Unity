using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1000f;

    public GameObject firePoint;

    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject redLaser;
    public GameObject yellowLaser;
    public GameObject blueLaser;

    GameObject equippedLaser;

    int i = 0;

    public List <GameObject> laserColours = new List<GameObject>();

    void Start()
    {
        equippedLaser = laserColours[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Firing ma laser
        {
            Shoot();
           // Debug.DrawRay(firePoint.transform.position, firePoint.transform.rotation.eulerAngles * 10, Color.green);
        }    

        ChangeLaserColour();
       // Debug.DrawRay(firePoint.transform.position, this.transform.forward * 10, Color.red);
    }

    void ChangeLaserColour() 
    {

        if(Input.GetMouseButtonDown(1)) // If player pressed right mouse button
        {
            // Debug.Log("Mouse button 2 pressed");
            // Debug.Log(laserColours[i]);   

            equippedLaser = laserColours[i]; // Assign current equipped laser to laserColour list selected index

            Debug.Log(equippedLaser);

            i ++; // Increment on mouse(1) press        

            if(i > 2) // Return count to 0 when you have cycled through list
            {
                i = 0;
            }
        }
    }
    
    void Shoot()
    {
        RaycastHit hit; // Declare hit for info

        Physics.Raycast(firePoint.transform.position, this.transform.forward * range, out hit, range);

        //Debug.Log(hit.transform.name);
        GameObject laser = GameObject.Instantiate(equippedLaser, transform.position, transform.rotation) as GameObject;
        //laser.GetComponent<ShotBehavior>().setTarget(hit.point);
       // GameObject.Destroy(laser, 2f);

        if(hit.collider.gameObject.tag == "Enemy")
        {
            //Destroy(hit.collider.gameObject);
            GameObject.Destroy(laser, 1f); // Destroy laser on hit
        }
        else
        {
            GameObject.Destroy(laser, 1f);
        }
    }

}
