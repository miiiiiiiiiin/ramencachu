using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class IsLogining : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseUser user;
    public GameObject Login;
    public GameObject MyInfo;
    // Start is called before the first frame update
    void Start()
    {
        //auth = FirebaseAuth.DefaultInstance;
        // 현재 로그인된 사용자 가져오기
        //user = auth.CurrentUser;
        if(user == null){
            Login.SetActive(true);
        }else{
            MyInfo.SetActive(true);
        }
    }

}
