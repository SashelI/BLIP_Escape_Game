using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenCadenasOpened : MonoBehaviour
{
    private GameObject cadenas;
    [SerializeField] private GameObject posTombe;
    // Start is called before the first frame update
    void Start()
    {
        cadenas = GameObject.FindGameObjectWithTag("Cadenas");
    }

    // Update is called once per frame
    void Update()
    {
        if (cadenas.GetComponent<Code_cadenas>().isUnlocked())
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            transform.position = Vector3.Slerp(pos, posTombe.transform.position, Time.deltaTime * 7.0f);
            transform.rotation = Quaternion.Slerp(rot, posTombe.transform.rotation, Time.deltaTime * 7.0f);
        }
    }
}
