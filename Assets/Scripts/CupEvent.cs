using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupEvent : MonoBehaviour, IPointerClickHandler
{
    public bool istouched = false; 
    public void OnPointerClick(PointerEventData eventData) {{
        GetComponent<AudioSource>().Play();                
        GameManager.instance.isTouched = true;
        Debug.Log("됨?");

        }
    }
}
