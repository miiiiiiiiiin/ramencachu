using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
   public void Play(){
    StartCoroutine(Shake());
   }

   IEnumerator Shake(){    
    transform.DOShakePosition(0.3f);
    GetComponent<AudioSource>().Play();
    yield return null;
   }
}
