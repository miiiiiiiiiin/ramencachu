using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LoginBtn : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField nickname;
    public TMP_Text outputText;    

    void Start()
    {
        login.Instance.LoginState += OnChangedState;
        login.Instance.Init();
    }

    private void OnChangedState(bool sign)
    {
        outputText.text = sign ? "로그인: " : "로그아웃 : ";
        outputText.text += login.Instance.UserId;
    }

   public void Create()
   {
        string e = email.text;
        string p= password.text;
        login.Instance.Create(e, p);
        //AndroidToast.Instance.showMessage("회원가입 완료", 2.5f);

        
   }
   public void Login(){    
     string e = email.text;
     string p= password.text;        
     login.Instance.Login(e, p);
     string[] parts = e.Split('@');
     PlayerPrefs.SetString("ID", parts[0]);
     //GameManager.instance.loginID = parts[0];
     Debug.Log(e);
   }
   public void FindPassword(){
        string e = email.text;
        login.Instance.FindPassword(e);
   }


   public void Nickname(){
     string n = nickname.text;     
     PlayerPrefs.SetString("name", n);
     //Debug.Log(email);
     MyScript myScript = FindObjectOfType<MyScript>();
     myScript.InClickSave();//정보 파이어베이스에 보내기
   }

}
