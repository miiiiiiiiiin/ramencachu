using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private int ClickCount = 0;
    public GameObject CloseQ;
      void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseQ.SetActive(true);

        //     ClickCount++;
        //     if (!IsInvoking("DoubleClick"))
        //         Invoke("DoubleClick", 1.0f);
       
        // }
        // else if (ClickCount == 2)
        // {
        //     CancelInvoke("DoubleClick");
        //     Application.Quit();
        }
    }
    public void Yes(){
        Application.Quit();
    }
    public void No(){
        CloseQ.SetActive(false);
    }

    private void DoubleClick(){
        ClickCount = 0;
    }
}
