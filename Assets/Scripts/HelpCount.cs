using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpCount : MonoBehaviour
{
    public TextMeshProUGUI HelpCounting;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.count= 0;
    }

}
