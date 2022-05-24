using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ouverture_porte : MonoBehaviour
{

    public GameObject mainCamera;
    RaycastHit hit;
    public LayerMask mask;
    
    
    int x = Screen.width / 2;
    int y = Screen.height / 2;
    public float temps;
    bool open2;

    public GameObject texte;
    public GameObject texte_porte_fermé;
    public GameObject feuille_overlay;

    Outline current_outline;
    Outline last_outline;
    

    public Detection_collison detection_Collison;
    public Code_cadenas cadenas;

    private void Start()
    {
        texte.SetActive(false);
        texte_porte_fermé.SetActive(false);
        feuille_overlay.SetActive(false);

    }

    void FixedUpdate()
    {
       temps += Time.deltaTime;



        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 40, mask) && hit.collider != null)
        {
            //Si on rencontre une porte non verouillé
            if (hit.collider.tag == "porte"
                || hit.collider.tag == "porte_entre" && detection_Collison.enigme_resolu
                || hit.collider.tag == "placard_cuisine" && cadenas.isUnlocked()
                //|| hit.collider.tag == "tiroire_3"
                )
            {
                texte.SetActive(true);
                texte_porte_fermé.SetActive(false);
                //Debug.Log("Object touché : " + hit.collider.name);
                if (Input.GetMouseButton(0) && temps > 0.1)
                {
                    //if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        //Debug.Log("rayon de porte intercepté");
                        open2 = !open2;
                        if (hit.collider.GetComponent<Script_porte>() != null) hit.collider.GetComponent<Script_porte>().open = open2;
                        temps = 0.0f;
                    }

                }
                // Gestion des outlines rouges
                if (hit.collider.GetComponent<Script_porte>() != null)
                {
                    if (hit.collider.GetComponent<Script_porte>().GetComponent<Outline>() != null)
                    {
                        if (current_outline == null)
                        {
                            current_outline = hit.collider.GetComponent<Script_porte>().GetComponent<Outline>();
                        }
                        if (current_outline != null && current_outline != hit.collider.GetComponent<Script_porte>().GetComponent<Outline>())
                        {
                            last_outline = current_outline;
                            current_outline = hit.collider.GetComponent<Script_porte>().GetComponent<Outline>();
                        }

                        if (last_outline != null && last_outline != current_outline)
                        {
                            last_outline.enabled = false;
                            last_outline = current_outline;
                        }

                        if (current_outline.enabled == false)
                        {
                            current_outline.enabled = true;
                        }
                    }
                }
            }

            // Si la porte est verouillé
            else if (hit.collider.tag == "porte_entre"
                    || hit.collider.tag == "placard_cuisine")
            {
                texte.SetActive(false);
                if (Input.GetMouseButton(0))
                {
                    texte_porte_fermé.SetActive(true);
                    
                }
            }

            // Si le cursseur croise quelque chose qu'il peut lire
            else if (hit.collider.tag == "Feuille")
            {
                if (Input.GetMouseButton(0) && !feuille_overlay.activeInHierarchy && temps > 0.1)
                {
                    feuille_overlay.SetActive(true);
                    temps = 0.0f;
                }
                else if (Input.GetMouseButton(0) && temps > 0.1)
                {
                    feuille_overlay.SetActive(false);
                    temps = 0.0f;
                }
            }

            // Si le curseur quitte un objet
            else
            {
                texte_porte_fermé.SetActive(false);
                texte.SetActive(false);
                feuille_overlay.SetActive(false);
                if (last_outline != null)
                {
                    last_outline.enabled = false;
                }
            }

            

        }
        /*else
        {
            
        }*/

    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entre");
            (enter) = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("sort");
            (enter) = false;
        }
    }*/

}

