using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Woodlouse_code : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private int code_pos = 1;
    private int cpt = 0;

    // Changer en sous fonction triggerable
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        string sept = "7_";
        string quat = "4_";
        string un = "1_";
        string sept_2 = "7sec_";

        string curr = gameObject.name;

        sept += curr[9];
        quat += curr[9];
        un += curr[9];
        sept_2 += curr[9];

        if(code_pos == 1)
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
            if(cpt > 300)
            {
                if(code_pos < 4)
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
