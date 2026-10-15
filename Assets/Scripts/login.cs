using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using TMPro;
using System;
public class login 
{
    public bool isnotCreated = false;
    public bool isnotLoggedIn = false;
    public bool isCreated = false;
    public bool isLogined = false;
    public bool isSent = false;
    public bool isEnd = false;
    private static login instance = null;
    public string ID = null;
    
    public static login Instance{
        get{
            if(instance == null){
                instance = new login();
            }
            return instance;
        }
    }
    // Start is called before the first frame update

    public FirebaseAuth auth;
    public FirebaseUser user;
    public string UserId => user.UserId;

    public Action<bool> LoginState;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        //StateChanged: 계정 상태가 바뀔때마다 호출됨
        auth.StateChanged += OnChange;
    }

    private void OnChange(object sender, EventArgs e){
        if(auth.CurrentUser != user){// CurrentUser는 현재 사용자를 나타냄. 현재 사용자와 이전에 저장된 사용자가 다르다면.
            bool singed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if(!singed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(singed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);

            }
        }
    }
   public void Create(string email, string password){
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled){
                Debug.LogError("회원가입 취소");
                return;
            }
            if(task.IsFaulted){
                Debug.LogError("회원가입 실패");
                isnotCreated = true;
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser user = authResult.User;
            //Firebase의 CreateUserWithEmailAndPasswordAsync 메서드는 Task<AuthResult>를 반환합니다. 
            //즉, task.Result는 AuthResult 형식의 결과를 반환하므로 AuthResult에서 FirebaseUser 객체를 가져와야 합니다.
            Debug.LogError("회원가입 완료");
            isCreated = true;
            
            //회원가입이 완료되면 셋엑티브 끄고 로그인 화면켜기(bool변수)
        });
   }
   public void Login(string email, string password){
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled){
                Debug.LogError("로그인 취소");
                return;
            }
            if(task.IsFaulted){
                Debug.LogError("로그인 실패");
                isnotLoggedIn = true;
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser user = authResult.User;
            
            Debug.LogError("로그인 완료");
            isLogined = true;
        });
   }

   public void FindPassword(string email){
        if(user == null){
            Debug.Log("개망햇긔");
        }
        if (user != null) {
        auth.SendPasswordResetEmailAsync(email).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SendPasswordResetEmailAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
            return;
        }

            Debug.Log("메일을 성공적으로 보냈ㅆ습니다.");
            isSent = true;  
        });
        }
   }

    public void Logout(){
        auth.SignOut();
        Debug.Log("로그아웃");
        //PlayerPrefs.DeleteAll();
    }
   
   }

