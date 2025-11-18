using NUnit.Framework.Constraints;
using UnityEngine;

public class InventorySystem : InventoryItem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("press hold G to pickup drop guns press M to pickup drop medipacks press hold K to pickup drop keycards");
        
        if  (Input.GetKeyDown(KeyCode.G)) 

        {
            Debug.Log("U pressed G u picked gun");
        }
        if  (Input.GetKeyDown(KeyCode.M)) 

        {
            Debug.Log("U pressed M u picked medkit");
        }        
        if  (Input.GetKeyDown(KeyCode.K)) 

        {
            Debug.Log("U pressed K u picked keycard");
        }
       


    }
}
