using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public float redHealth = 100f;

    public string colourWeakness;

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
            GameObject.Destroy(gameObject, 1f);
        }
    }

    // void canvasTest()
    // {
    //         // Offset position above object bbox (in world space)
    //     float offsetPosY = transform.position.y + 1.5f;
        
    //     // Final position of marker above GO in world space
    //     Vector3 offsetPos = new Vector3(transform.position.x, offsetPosY, transform.position.z);
        
    //     // Calculate *screen* position (note, not a canvas/recttransform position)
    //     Vector2 canvasPos;
    //     Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
        
    //     // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);
        
    //     // Set
    //     redHealth.localPosition = canvasPos;
    // }
 
}
