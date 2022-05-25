using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonBoite : MonoBehaviour
{
    private GameObject box;
    [SerializeField] private GameObject ui;
    private GameObject cam;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.FindGameObjectWithTag("Boite");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendPressed()
    {
        box.GetComponent<CodeBoite>().hasBeenPressed(gameObject.name);
    }

    public void quitter()
    {
        box.GetComponent<CodeBoite>().setOpen(false);
        box.GetComponent<Outline>().OutlineColor = Color.white;
        ui.SetActive(false);
        cam.GetComponent<CameraMouseControl>().enabled = true;
        player.GetComponent<PlayerMovemement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
