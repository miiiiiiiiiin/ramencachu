using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool allbtn = false;
    public bool allbtnAnd = false;
    public bool btn1 = false;
    public bool btn2 = false;
    public bool btn3 = false;
    public bool btn4 = false;
    public bool rightbtn1 = false;
    public bool rightbtn2 = false;
    public bool rightbtn3 = false;
    public bool rightbtn4 = false;
    public bool isEating = false;
    public bool isTouched = false;
    public bool isUpdateScore = false;
    public bool isGameOver = false;
    public bool isReduction = false;
    public int HighScoreSave = 0;
    public int count;
    public string loginID;
    public string nickname;
    public static GameManager instance = null;

    
    public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                    if (instance == null)
                    {
                        Debug.LogError("게임 매니저가 없습니다.");
                    }
                }
                return instance;
            }
        }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  
        }
        HighScoreSave = PlayerPrefs.GetInt("score", 0);
    }
    
    public void Count(){
        count += 1;
        CountUpdate();
    }
    public void CountUpdate(){
        HelpCount hpcount = FindObjectOfType<HelpCount>();
        hpcount.HelpCounting.text = "도움 횟수 : " + count;
        
    }
    public void GameOver(){
        if(HighScoreSave < count){
            PlayerPrefs.SetInt("score", count);
        } 
    }
    public void ResetButtons()
    {
        btn1 = false;
        btn2 = false;
        btn3 = false;
        btn4 = false;
    }

    



}
