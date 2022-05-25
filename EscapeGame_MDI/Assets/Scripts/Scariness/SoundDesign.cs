using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDesign : MonoBehaviour
{

    public AudioSource bruit_horreur;
    public AudioSource insecte_bruit;
    public AudioSource placard1;
    public AudioSource placard2;
    public AudioSource porte;
    public AudioSource rire_horreur;
    public AudioSource cadenas_son;


    private bool cabinet_event = false;
    private bool bathtub_event = false;

    //private bool save_s_cabinet_door = false;
    private bool save_s_cabinet_door1 = false;
    private bool save_s_cabinet_door2 = false;

    private bool save_s_porte1 = false;
    private bool save_s_porte2 = false;

    private bool save_Lavabo_Door_coulissante = false;
    private bool save_Lavabo_Door = false;

    private bool save_sdb_Door1 = false;
    private bool save_sdb_Door2 = false;

    private Script_porte s_cabinet_door;
    private Script_porte s_cabinet_door1;
    private Script_porte s_cabinet_door2;
    private Script_porte s_Lavabo_Door_coulissante;
    private Script_porte s_Lavabo_Door;
    private Script_porte s_porte1;
    private Script_porte s_porte2;
    private Script_porte s_sdb_Door1;
    private Script_porte s_sdb_Door2;

    private Detection_collison s_final;
    private Woodlouse_code s_woodlouse;

    private GameObject cadenas;
    private bool event_cadenas = true;



    // Start is called before the first frame update
    void Start()
    {
        //s_cabinet_door = (Script_porte)GameObject.Find("Cabinet1_Door").GetComponent("Script_porte");
        s_cabinet_door1 = (Script_porte)GameObject.Find("Gond_1").GetComponent("Script_porte");
        s_cabinet_door2 = (Script_porte)GameObject.Find("Gond_2").GetComponent("Script_porte");
        s_Lavabo_Door_coulissante = (Script_porte)GameObject.Find("Lavabo_Door_coulissante").GetComponent("Script_porte");
        s_Lavabo_Door = (Script_porte)GameObject.Find("Lavabo_Door").GetComponent("Script_porte");

        s_sdb_Door1 = (Script_porte)GameObject.Find("sdb_Door1").GetComponent("Script_porte");
        s_sdb_Door2 = (Script_porte)GameObject.Find("sdb_Door2").GetComponent("Script_porte");

        s_porte1 = (Script_porte)GameObject.Find("gond porte salle de bain").GetComponent("Script_porte");
        s_porte2 = (Script_porte)GameObject.Find("gond porte d'entrée").GetComponent("Script_porte");

        s_final = (Detection_collison)GameObject.Find("Baignoire").GetComponent("Detection_collison");
        s_woodlouse = (Woodlouse_code)GameObject.Find("Woodlouse0").GetComponent("Woodlouse_code");

        cadenas = GameObject.FindWithTag("Cadenas");

        //Cabinet1_Door.001
        //Cabinet1_Door
        //Cabinet1_Door.002
        //gond porte salle de bain
        //gond porte d'entrée

        //Baignoire.Detection_collision.Enigme_resolu = true/false
        //Woodlouse0.Woodlouse_code.request_song = true/false

    }

    // Update is called once per frame
    void Update()
    {
        if (s_cabinet_door1.open != save_s_cabinet_door1)
        {
            save_s_cabinet_door1 = !save_s_cabinet_door1;
            placard1.Play();
        }


        if (s_cabinet_door2.open != save_s_cabinet_door2)
        {
            save_s_cabinet_door2 = !save_s_cabinet_door2;
            placard2.Play();
        }

        if (s_porte1.open != save_s_porte1)
        {
            save_s_porte1 = !save_s_porte1;
            porte.Play();
        }

        if (s_porte2.open != save_s_porte2)
        {
            save_s_porte2 = !save_s_porte2;
            porte.Play();
        }

        if (s_sdb_Door1.open != save_sdb_Door1)
        {
            save_sdb_Door1 = !save_sdb_Door1;
            placard1.Play();
        }

        if (s_sdb_Door2.open != save_sdb_Door2)
        {
            save_sdb_Door2 = !save_sdb_Door2;
            placard2.Play();
        }

        if (s_Lavabo_Door_coulissante.open != save_Lavabo_Door_coulissante)
        {
            save_Lavabo_Door_coulissante = !save_Lavabo_Door_coulissante;
            placard2.Play();

            if (!cabinet_event)
            {
                cabinet_event = true;
                bruit_horreur.Play();
            }
        }

        if (s_Lavabo_Door.open != save_Lavabo_Door)
        {
            save_Lavabo_Door = !save_Lavabo_Door;
            placard1.Play();
        }

        if (s_woodlouse.request_song)
        {
            insecte_bruit.Play();
        }

        if(s_final.enigme_resolu && !bathtub_event)
        {
            bathtub_event = true;
            bruit_horreur.Play();
            rire_horreur.Play();
        }

        if(cadenas.GetComponent<Code_cadenas>().isUnlocked() && event_cadenas)
        {
            cadenas_son.Play();
            event_cadenas = false;

        }
    }
}
