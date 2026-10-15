using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBalloon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject Ballon;
    [SerializeField]
    private GameObject Hello;
    void Start()
    {
        Invoke("Hi", 0.5f);
        Invoke("Balloown", 1.5f);
    }

    private void Balloown(){
        Ballon.SetActive(true);
    }
    private void Hi(){
        Hello.SetActive(false);
    }
}
