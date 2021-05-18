using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;

    public GameObject firePoint;

    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           // Debug.DrawRay(firePoint.transform.position, firePoint.transform.rotation.eulerAngles * 10, Color.green);
        }    

        Debug.DrawRay(firePoint.transform.position, this.transform.forward * 10, Color.red);

    }

    void Shoot()
    {
        RaycastHit hit;

        Physics.Raycast(firePoint.transform.position, this.transform.forward * 10, out hit, range);

        //Debug.Log(hit.transform.name);
        GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        laser.GetComponent<ShotBehavior>().setTarget(hit.point);
        GameObject.Destroy(laser, 2f);
    }
}
