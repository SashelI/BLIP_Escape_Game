using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonBoite : MonoBehaviour
{
    private GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.FindGameObjectWithTag("Boite");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendPressed()
    {
        box.GetComponent<CodeBoite>().hasBeenPressed(gameObject.name);
    }
}
