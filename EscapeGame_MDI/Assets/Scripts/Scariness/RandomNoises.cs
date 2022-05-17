using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoises : MonoBehaviour
{

    public AudioSource bruitage_pas;
    public AudioSource objet_casse;
    public AudioSource cri;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand_num = Random.Range(0, 50000);

        if (rand_num == 101 && !bruitage_pas.isPlaying)
        {
            bruitage_pas.Play();
        }
        if (rand_num == 102 && !objet_casse.isPlaying)
        {
            objet_casse.Play();
        }
        if (rand_num == 103 && !cri.isPlaying)
        {
            cri.Play();
        }
    }
}
