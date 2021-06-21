using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    //// Parameters
    public float damage = 20f;

    //// Laser Parameters
    public float health;
    // Range
    public float laserRange = 1000f;
    public float meleeRange = 10f;
    public float shootRate;
    // Shoot Rate
    private float m_shootRateTimeStamp;

    // Game Objects
    public GameObject firePoint;

    // Laser Types
    public GameObject redLaser;
    public GameObject yellowLaser;
    public GameObject blueLaser;

    // Laser equipment
    public List <GameObject> laserColours = new List<GameObject>();
    GameObject equippedLaser;
    int i = 0;

    // Melee Parameters
    public BoxCollider Collider;  

    // UI Display
    [SerializeField] TextMeshProUGUI displayLaserColour;
    [SerializeField] TextMeshProUGUI displayHealth;

    // SFX
    public GameObject hitSpark;

    void Awake()
    {
        equippedLaser = laserColours[i];
        Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Firing ma laser
        {
            Shoot();
           // Debug.DrawRay(firePoint.transform.position, firePoint.transform.rotation.eulerAngles * 10, Color.green);
        }    

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("QuickAttack");
        }

        MeleeAttack();

        ChangeLaserColour();

        Health();

    }

    void ChangeLaserColour() 
    {

        if(Input.GetKeyDown(KeyCode.C)) // If player pressed right mouse button
        {
            // Debug.Log("Mouse button 2 pressed");
            // Debug.Log(laserColours[i]);   

            equippedLaser = laserColours[i]; // Assign current equipped laser to laserColour list selected index

            displayLaserColour.text = "Laser: " + equippedLaser.ToString();

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

        Physics.Raycast(firePoint.transform.position, this.transform.forward * laserRange, out hit, laserRange);

        //Debug.Log(hit.transform.name);
        GameObject laser = GameObject.Instantiate(equippedLaser, transform.position, transform.rotation) as GameObject;

        if(hit.collider.gameObject.tag == "Enemy")
        {
            //Destroy(hit.collider.gameObject);
            GameObject hitSparkInstantiated = Instantiate(hitSpark, transform.position, transform.rotation);
            GameObject.Destroy(hitSparkInstantiated, 1f);
            GameObject.Destroy(laser, 1f); // Destroy laser on hit
        }
        else
        {
            GameObject.Destroy(laser, 1f);
        }
    }

    void MeleeAttack()
    {
        RaycastHit hit;
        
        Physics.Raycast(firePoint.transform.position, this.transform.forward * meleeRange, out hit, meleeRange);

        if(Input.GetMouseButtonDown(1))
        {
            Debug.DrawRay(firePoint.transform.position, this.transform.forward * 1f, Color.red);
        }
    }

    IEnumerator QuickAttack()
    {
        Collider.enabled = true;
        Debug.Log(Collider.enabled);
        yield return new WaitForSeconds(0.1f);
        Collider.enabled = false;
        Debug.Log(Collider.enabled);
    }

    void Health()
    {
        displayHealth.text = "Health: " + health.ToString();
    }


}
