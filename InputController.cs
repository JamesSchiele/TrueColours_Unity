using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // target lock
    public PlayerRadius playerRadius;

    // Update is called once per frame
    void Update()
    {
        LockOnEnemy();
    }

    void LockOnEnemy()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            // turn on target look bool from targetLock script
            playerRadius.CycleThroughEnemiesInRadius();
        }
    }
}
