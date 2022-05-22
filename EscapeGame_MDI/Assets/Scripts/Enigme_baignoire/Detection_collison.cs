using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_collison : MonoBehaviour
{
    // Bollean de detection
    public bool isBloodHere = false;
    public bool isSkullHere = false;
    public bool isBonesHere = false;
    public bool isEyeHere = false;

    public bool enigme_resolu;
    public ParticleSystem sang;

    // Start is called before the first frame update
    void Start()
    {
        sang.Pause();
        ParticleSystem.EmissionModule em = sang.emission;
        em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Cheat code
        /*if (Input.GetKeyDown("space"))
        {
            enigme_resolu = true;
        }*/
        if (isBloodHere && isSkullHere && isBonesHere && isEyeHere || Input.GetKeyDown("space"))
        {
            //Debug.Log("Gagné");
            enigme_resolu = true;

            sang.Play();
            ParticleSystem.EmissionModule em = sang.emission;
            em.enabled = true;
        }
       else
        {
            enigme_resolu = false;

            sang.Pause();
            ParticleSystem.EmissionModule em = sang.emission;
            em.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision obj)
    {

            if (obj.gameObject.name == "Sang")
            {
                Debug.Log("la bouteille de sang est dans la baignoire");
                isBloodHere = true;
            }


            if (obj.gameObject.name == "Crane")
            {
                Debug.Log("le crane est dans la baignoire");
                isSkullHere = true;
            }



            if (obj.gameObject.name == "Os")
            {
                Debug.Log("les os sont dans la baignoire");
                isBonesHere = true;
            }


            if (obj.gameObject.name == "Yeux")
            {
                Debug.Log("les yeux sont dans la baignoire");
                isEyeHere = true;
            }
    }

    private void OnCollisionExit(Collision obj)
    {

        if (obj.gameObject.name == "Sang")
        {
            Debug.Log("a plus sang");
            isBloodHere = false;
        }


        if (obj.gameObject.name == "Crane")
        {
            Debug.Log("a plus crane");
            isSkullHere = false;
        }



        if (obj.gameObject.name == "Os")
        {
            Debug.Log("a plus os");
            isBonesHere = false;
        }


        if (obj.gameObject.name == "Yeux")
        {
            Debug.Log("a plus yeux");
            isEyeHere = false;
        }
    }
    }
