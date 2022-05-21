using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template_interaction_inventaire : MonoBehaviour
{
    private GameObject player;
    public string neededObject;
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
                print("Porte ouverte");
                player.GetComponent<Inventory>().removeFromInventory(neededObject);
            }
        }
    }
}
