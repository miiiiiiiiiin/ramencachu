using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class MyScript : MonoBehaviour
{
//로그인 ->닉네임 -> 제이슨 업데이트 
private string loginID;
private string nickname;
private int highScore;

[System.Serializable]
public class User
{
    public string email;
    public UserDetails details;

    public User(string email, string name, int highScore)
    {
        this.email = email;
        this.details = new UserDetails(name, highScore);
    }
}

[System.Serializable]
public class UserDetails
{
    public string name;
    public int highScore;
    public FirebaseAuth auth;

    public UserDetails(string name, int highScore)
    {
        this.name = name;
        this.highScore = highScore;
    }
}
    
    public string DBURL = "https://noodles-e2bc1-default-rtdb.firebaseio.com/";
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new System.Uri(DBURL);
        //데이터를 쓰려면 databaseraference의 인스턴스가 필요
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        nickname = PlayerPrefs.GetString("name", "username");
        //highScore = PlayerPrefs.GetInt("score", 0);
        
    }
    void Update() {
        if(GameManager.instance.isUpdateScore==true){
            nickname = PlayerPrefs.GetString("name");
            highScore = PlayerPrefs.GetInt("score");
            writeNewUser("순위", nickname, highScore);
            GameManager.instance.isUpdateScore = false;
        } else{
            return;
        }
    }
    public void InClickSave(){
        //writeNewUser함수로 userId, name, email 정의
        //loginID = PlayerPrefs.GetString("ID");
        nickname = PlayerPrefs.GetString("name");
        writeNewUser2("순위", nickname, GameManager.instance.HighScoreSave);
    }

    public void writeNewUser(string Ranking, string name, int highScore)
    {
       FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;
        if (user != null) {
            string userId = user.UserId; // 로그인한 유저의 UID
            Debug.Log(userId);

            // 사용자 데이터를 저장
            var userDetailData = new Dictionary<string, object>
            {
                { "name", name },
                { "highScore", highScore }
            };

            // 자신의 UID 아래에 데이터 저장
            reference.Child(Ranking).Child(userId).SetValueAsync(userDetailData);
        }
    }
    public void writeNewUser2(string Ranking, string name, int highScore)
    {
        FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;
        if (user != null) {
            string userId = user.UserId; // 로그인한 유저의 UID
            Debug.Log(userId);

            // 사용자 데이터를 저장
            var userDetailData = new Dictionary<string, object>
            {
                { "name", name },
                { "highScore", highScore }
            };

            // 자신의 UID 아래에 데이터 저장
            reference.Child(Ranking).Child(userId).SetValueAsync(userDetailData);
        }

        // 작업 완료 플래그 설정
        login.Instance.isEnd = true;
        FindObjectOfType<Button>().HomeBtn();
    }

//UpdateChildrenAsync
}
