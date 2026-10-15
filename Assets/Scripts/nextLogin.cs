using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Auth;

public class nextLogin : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Number;
    // [SerializeField]
    // private TextMeshProUGUI userNicknameText;
    // [SerializeField]
    // private TextMeshProUGUI highScoreText;
    private Vector3 onepositon = new Vector3(93f,-42f,0f);
    [SerializeField]
    private GameObject Ranking; 
    public RectTransform contents;
    //private GameObject newUIObject;
    private int i =1;
    private DatabaseReference databaseRef;// 파베 리얼타임베이스 레퍼런스
    public string DBURL = "https://noodles-e2bc1-default-rtdb.firebaseio.com/";
     FirebaseAuth auth;
    FirebaseUser user;
    public GameObject Login;
    public GameObject MyInfo;

    public class UserDetails
    {
        public string name;
        public int highScore;
        public UserDetails(string name, int highScore)
        {
            this.name = name;
            this.highScore = highScore;
        }
    }

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        // 현재 로그인된 사용자 가져오기
        user = auth.CurrentUser;
        if(user == null){
            Login.SetActive(true);
        }else{
            MyInfo.SetActive(true);
        }
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new System.Uri(DBURL);
        // Firebase Realtime Database 레퍼런스 초기화
        databaseRef = FirebaseDatabase.DefaultInstance.GetReference("순위");
        LoadLeaderboard();
    }
    
    void LoadLeaderboard()
    {
        List<KeyValuePair<object, object>> leaderboardList = new List<KeyValuePair<object, object>>();
        databaseRef.OrderByChild("highScore").LimitToFirst(10).GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted){ // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
 
                foreach(DataSnapshot data in snapshot.Children){
                    IDictionary rank = (IDictionary)data.Value;
                  //  Debug.Log("이름: " + rank["name"] + ", 점수: " + rank["highScore"]);
                    leaderboardList.Add(new KeyValuePair<object, object>(rank["name"], rank["highScore"]));
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
                leaderboardList.Reverse();
                foreach (var entry in leaderboardList)
                {
                    Number.text = i+"위";
                    GameObject newEntry = Instantiate(Ranking, contents);//콘텐츠를 부모로 만듦
                    Transform nicknameTransform = newEntry.transform.Find("nickname"); // 자식 중 닉네임 텍스트 프리팹
                    Transform scoreTransform = newEntry.transform.Find("Highscore");
                    // TextMeshProUGUI 컴포넌트를 가져와 텍스트를 설정
                    TextMeshProUGUI userNicknameText = nicknameTransform.GetComponentInChildren<TextMeshProUGUI>();
                    if (userNicknameText != null)
                    {                        
                        // entry.Key를 문자열로 변환 후 할당
                        userNicknameText.text = "닉네임: " +  entry.Key;
                    }
                    // highScore 텍스트도 동일하게 설정
                    TextMeshProUGUI highScoreText = scoreTransform.GetComponentInChildren<TextMeshProUGUI>();
                    if (highScoreText != null)
                    {
                        highScoreText.text = "최고기록: "+  entry.Value;
                    }
                    i+=1;
                    
                }
            }
        });
    }
}
