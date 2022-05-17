using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventairable : MonoBehaviour
{
    public enum ObjectType {cube, key}
    public ObjectType Objtype { get { return type; } set { type = value; } }
    [SerializeField] private ObjectType type;
    [SerializeField] private Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inv.addToInventory(this);
            gameObject.SetActive(false);
        }
    }
}
