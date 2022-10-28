using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeControl : MonoBehaviour
{
   
    [Range(0f, 1f)]
    public float volume =1.0f;


    void Update()
    {
        AudioListener.volume = volume;
    }

}
