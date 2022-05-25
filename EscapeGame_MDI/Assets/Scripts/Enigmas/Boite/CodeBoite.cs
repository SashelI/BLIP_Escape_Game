using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBoite : MonoBehaviour
{
    private bool open;
    private bool haie;
    private bool terre;
    private bool nid;
    private bool the;

    private int order;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject buttonQuit;
    [SerializeField] private GameObject buttonOpen;

    private GameObject cam;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        order = 0;

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(haie && terre && nid && the && order == 4)
        {
            open = true;
            buttonOpen.SetActive(true);
            gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
            buttonQuit.SetActive(false);
            order = 0;
        }
    }

    public bool isOpen()
    {
        return open;
    }

    public void setOpen(bool p)
    {
        open = p;
    }

    public void hasBeenPressed(string buttonName)
    {
        if (buttonName.Equals("Haie"))
        {
            order = 1;
            haie = true;
            terre = false;
            nid = false;
            the = false;
        }
        if (buttonName.Equals("Terre"))
        {
            if (order == 1)
            {
                order = 2;
                terre = true;
            }
            else
            {
                order = 0;
                haie = false;
                terre = false;
                nid = false;
                the = false;
            }
        }
        if (buttonName.Equals("Nid"))
        {
            if (order == 2)
            {
                order = 3;
                nid = true;
            }
            else
            {
                order = 0;
                haie = false;
                terre = false;
                nid = false;
                the = false;
            }
        }
        if (buttonName.Equals("The"))
        {
            if (order == 3)
            {
                order = 4;
                the = true;
            }
            else
            {
                order = 0;
                haie = false;
                terre = false;
                nid = false;
                the = false;
            }
        }
    }

    private void OnMouseOver()
    {
        print(open);
        if (Input.GetMouseButtonDown(0) && !open)
        {
            ui.SetActive(true);
            cam.GetComponent<CameraMouseControl>().enabled = false;
            player.GetComponent<PlayerMovemement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}


