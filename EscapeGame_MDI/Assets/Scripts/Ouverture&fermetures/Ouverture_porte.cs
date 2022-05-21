using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouverture_porte : MonoBehaviour
{

    public GameObject mainCamera;
    RaycastHit hit;
    public LayerMask mask;
    
    
    int x = Screen.width / 2;
    int y = Screen.height / 2;
   public float temps;
    bool open2;


    void FixedUpdate()
    {
       temps += Time.deltaTime;



        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 40, mask) && hit.collider != null && hit.collider.tag == "porte")
        {
            Debug.Log("Object touché : " + hit.collider.name);
            if (Input.GetMouseButton(0)&& temps > 0.5)
            {
                Debug.Log("rayon de porte intercepté");
                open2 = !open2;
                if(hit.collider.GetComponent<Script_porte>() != null) hit.collider.GetComponent<Script_porte>().open = open2;
                temps = 0.0f;

            }
            

        }
        else
        {
            Debug.Log("porte non à porté");
        }

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

