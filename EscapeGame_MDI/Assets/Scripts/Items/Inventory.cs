using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Inventairable> inventaire = new List<Inventairable>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void addToInventory(Inventairable item)
    {
        inventaire.Add(item);
    }
}
