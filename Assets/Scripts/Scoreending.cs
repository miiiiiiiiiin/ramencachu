using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreending : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    void Start()
    {
        text.text = "도움 횟수: " +GameManager.instance.count;
        if(GameManager.instance.HighScoreSave < GameManager.instance.count){
            GameManager.instance.HighScoreSave = GameManager.instance.count;
            PlayerPrefs.SetInt("score", GameManager.instance.count);
            Debug.Log("됏냐고");
            GameManager.instance.isUpdateScore = true;
        }   
    
    }
}
