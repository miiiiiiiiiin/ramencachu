using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour

{//게임 도중 뒤로가기 누르면 셋팅화면
    [SerializeField]
    private GameObject Setting;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Setting.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
}
