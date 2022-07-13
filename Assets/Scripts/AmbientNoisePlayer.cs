using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoisePlayer : MonoBehaviour
{

    public AudioSource ambient;

    // Update is called once per frame
    void Update()
    {
        if (!ambient.isPlaying)
        {
            ambient.Play();
        }
    }
    


}
