using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code_cadenas : MonoBehaviour
{
    private bool Chiffre1;
    private bool Chiffre2;
    private bool Chiffre3;
    private bool Chiffre4;

    private bool unlocked;

    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject isOpen;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        Chiffre1 = false;
        Chiffre2 = false;
        Chiffre3 = false;
        Chiffre4 = false;
        unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Chiffre1 && Chiffre2 && Chiffre3 && Chiffre4)
        {
            unlocked = true;
        }
        //cheat code
        /*if (Input.GetKey("a"))
        {
            unlocked = true;
        }*/
    }
public void verifNumber1(string number)
    {
        if (number.Equals(7.ToString()))
        {
            Chiffre1 = true;
        }
        else
        {
            Chiffre1 = false;
        }
    }

    public void verifNumber2(string number)
    {
        if (number.Equals(4.ToString()))
        {
            Chiffre2 = true;
        }
        else
        {
            Chiffre2 = false;
        }
    }

    public void verifNumber3(string number)
    {
        if (number.Equals(1.ToString()))
        {
            Chiffre3 = true;
        }
        else
        {
            Chiffre3 = false;
        }
    }

    public void verifNumber4(string number)
    {
        if (number.Equals(7.ToString()))
        {
            Chiffre4 = true;
        }
        else
        {
            Chiffre4 = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ui.SetActive(true);
            cam.GetComponent<CameraMouseControl>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public bool isUnlocked()
    {
        return unlocked;
    }

    public void Unlock()
    {
        ui.SetActive(false);
        cam.GetComponent<CameraMouseControl>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOpen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void quitter()
    {
        ui.SetActive(false);
        cam.GetComponent<CameraMouseControl>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
