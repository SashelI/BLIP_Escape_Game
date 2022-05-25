using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BougieDebut : MonoBehaviour
{
    private Transform cam;
    [SerializeField] private float maxDist;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject holded;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if ((Vector3.Distance(transform.position, cam.position) <= maxDist) && GetComponent<Outline>().enabled == false)
        {
            GetComponent<Outline>().enabled = true;
            text.SetActive(true);
        }
        else if (GetComponent<Outline>().enabled == true && (Vector3.Distance(transform.position, cam.position) > maxDist))
        {
            GetComponent<Outline>().enabled = false;
            text.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            holded.SetActive(true);
            text.SetActive(false);
            cam.GetComponent<GuideTextBougie>().go();
            gameObject.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        if (GetComponent<Outline>().enabled == true)
        {
            GetComponent<Outline>().enabled = false;
            text.SetActive(false);
        }
    }
}
