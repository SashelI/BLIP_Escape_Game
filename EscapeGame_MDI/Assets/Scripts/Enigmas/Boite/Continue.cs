using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    private GameObject cam;
    private GameObject player;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuer()
    {
        player.GetComponent<Inventory>().addToInventory(key.GetComponent<Inventairable>());
        ui.SetActive(false);
        cam.GetComponent<CameraMouseControl>().enabled = true;
        player.GetComponent<PlayerMovemement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
