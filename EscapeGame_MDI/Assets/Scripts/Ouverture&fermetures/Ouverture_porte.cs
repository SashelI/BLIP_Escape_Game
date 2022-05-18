using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouverture_porte : MonoBehaviour
{
    // Smothly open a door
    float smooth = 1.0f;
    float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
    bool open;
    bool enter;
    float temps;

    void FixedUpdate()
    {
        temps += Time.deltaTime;

        if (open == true)
        {
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }

        if (open == false)
        {
            var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * smooth);
        }

        if (enter == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (temps > 0.5)
                {
                    open = !open;
                }
                temps = 0.0f;
                Debug.Log("interaction avec la porte");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
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
    }

}

