using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFXController : MonoBehaviour
{
    [SerializeField] private ParticleSystem tranformFX;

    public void PlayTransformFX(){
        if (tranformFX != null){
            tranformFX.Play();
        }
    }
}
