using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject texte_porte_ferm�;
    

    public Detection_collison detection_Collison;

    private void Start()
    {
        texte.SetActive(false);
        Debug.Log("Start");
    }

    void FixedUpdate()
    {
       temps += Time.deltaTime;



        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 40, mask) && hit.collider != null)
        {
            if (hit.collider.tag == "porte"
                || hit.collider.tag == "porte_entre" && detection_Collison.enigme_resolu)
            {
                texte.SetActive(true);
                texte_porte_ferm�.SetActive(false);
                //Debug.Log("Object touch� : " + hit.collider.name);
                if (Input.GetMouseButton(0) && temps > 0.1)
                {
                    //Debug.Log("rayon de porte intercept�");
                    open2 = !open2;
                    if (hit.collider.GetComponent<Script_porte>() != null) hit.collider.GetComponent<Script_porte>().open = open2;
                    temps = 0.0f;

                }
            }
            else if (hit.collider.tag == "porte_entre")
            {
                texte.SetActive(false);
                if (Input.GetMouseButton(0))
                {
                    texte_porte_ferm�.SetActive(true);
                    Debug.Log("L'�nigle est non r�solu donc la porte reste ferm� !");
                }
            }
            else
            {
                texte_porte_ferm�.SetActive(false);
                texte.SetActive(false);

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

