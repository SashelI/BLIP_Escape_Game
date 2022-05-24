using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template_interaction_inventaire : MonoBehaviour
{
    private GameObject player;
    public string neededObject;

    private bool unlocked_tiroire = false;
    private bool unlocked_SDB = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.GetComponent<Inventory>().isPossesed(neededObject))
            {
                if (neededObject == "keyTiroir"){
                    unlocked_tiroire = true;
                }
                else if (neededObject == "keySDB")
                {
                    unlocked_SDB = true;
                }

                print("Porte ouverte");
                player.GetComponent<Inventory>().removeFromInventory(neededObject);
                
            }
        }
    }

    public bool isUnlocked_tiroire()
    {
        return unlocked_tiroire;
    }

    public bool isUnlocked_SDB()
    {
        return unlocked_SDB;
    }
}
