using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyInformation : MonoBehaviour
{
    public TMP_Text nickname;
    public TMP_Text HighScore;
    public TMP_Text Newname;
    // Start is called before the first frame update
    void Start()
    {
        nickname.text = PlayerPrefs.GetString("name") + "님";
        HighScore.text = "최고기록: " + PlayerPrefs.GetInt("score");
    }

    public void LogOut(){
    login.Instance.Logout();
    string nextSceneName = "SampleScene";
    FindObjectOfType<SceneFader>().StartFade(nextSceneName);
   }

   public void ChangeName(){   
     string n = Newname.text;     
     PlayerPrefs.SetString("name", n);
     MyScript myScript = FindObjectOfType<MyScript>();
     myScript.InClickSave();//정보 파이어베이스에 보내기
   }
}
