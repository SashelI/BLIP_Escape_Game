using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouttonsUICadenas : MonoBehaviour
{
    private bool action;
    private GameObject cadenas;
    private bool unlocked;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Equals("Deverouiller"))
        {
            action = true;
        }
        else { action = false; }

        cadenas = GameObject.FindGameObjectWithTag("Cadenas");
    }

    // Update is called once per frame
    void Update()
    {
        if (cadenas.GetComponent<Code_cadenas>().isUnlocked())
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
    }

    public void react()
    {
        if (action)
        {
            if (unlocked)
            {
                cadenas.GetComponent<Code_cadenas>().Unlock();
            }
            else
            {
                text.text = "Code erroné";
                Invoke("changeText", 2);
            }
        }
        else{
            cadenas.GetComponent<Code_cadenas>().quitter();
        }
    }

    private void changeText()
    {
       text.text = "Déverouiller";
    }
}
