using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Woodlouse_code : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private int code_pos = 1;
    private int cpt = 0;

    // 0 = asleep, 1 = va au deuxieme tiroir, 2 = réalise le code, 3 = retourne se coucher 
    public int comportement = 0;

    private GameObject door_cabinet;
    private Script_porte script_cabinet_door;

    private GameObject door_tiroir;
    private Script_porte script_tiroir;

    public bool request_song = false;

    // Changer en sous fonction triggerable
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        door_cabinet = GameObject.Find("Cabinet1_Door.001");
        script_cabinet_door = (Script_porte) door_cabinet.GetComponent("Script_porte");

        door_tiroir = GameObject.Find("Tiroire 3");
        script_tiroir = (Script_porte) door_tiroir.GetComponent("Script_porte");
    }

    private void stopRendering()
    {
        GetComponentInChildren<Renderer>().enabled = false;
    }

    private void FixedUpdate()
    {
        if(comportement == 0)
        {
            GetComponentInChildren<Renderer>().enabled = false;          
            if (script_cabinet_door.open)
            {
                GetComponentInChildren<Renderer>().enabled = true;
                comportement = 1;
                request_song = true;
            }
        }

        if(comportement == 1)
        {
            navMeshAgent.destination = GameObject.Find("Tiroir pour nav").transform.position;
            request_song = false;
            //Invoke("stopRendering", 10.0f);

            // s'il est arrivé
            if (Vector3.Distance(transform.position, GameObject.Find("Tiroir pour nav").transform.position) <= navMeshAgent.stoppingDistance + 1)
            {
                // Target reached
                GetComponentInChildren<Renderer>().enabled = false;

            }

            if (script_tiroir.open)
            {
                GetComponentInChildren<Renderer>().enabled = true;
                comportement = 2;
                request_song = true;
            }
        }

        if(comportement == 2)
        {
            request_song = false;

            string sept = "7_";
            string quat = "4_";
            string un = "1_";
            string sept_2 = "7sec_";

            string curr = gameObject.name;

            sept += curr[9];
            quat += curr[9];
            un += curr[9];
            sept_2 += curr[9];

            if (code_pos == 1)
            {
                navMeshAgent.destination = GameObject.Find(sept).transform.position;
            }
            if (code_pos == 2)
            {
                navMeshAgent.destination = GameObject.Find(quat).transform.position;
            }
            if (code_pos == 3)
            {
                navMeshAgent.destination = GameObject.Find(un).transform.position;
            }
            if (code_pos == 4)
            {
                navMeshAgent.destination = GameObject.Find(sept_2).transform.position;
            }


            cpt++;

            {
                if (cpt > 300)
                {
                    if (code_pos < 4)
                    {
                        code_pos++;
                    }
                    else
                    {
                        code_pos = 1;
                    }

                    cpt = 0;
                }
            }
        }
        
    }
}
