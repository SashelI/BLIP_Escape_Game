using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventairable : MonoBehaviour
{
    public enum ObjectType {cube, key}
    public ObjectType Objtype { get { return type; } set { type = value; } }
    [SerializeField] private ObjectType type;
    private Inventory inv;
    public string objName;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
