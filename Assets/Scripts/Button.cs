using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public bool buttonPressed;
    public void Btn1(){
        
        GameManager.instance.allbtn = true;//라면스포너로 이동(스폰 중지->재개)
        GameManager.instance.btn1 = true;// 버튼불변수를 여기서 켜버리기 
        Debug.Log("버튼1번");
        StartCoroutine(ResetButton());
    }
    public void Btn2(){
        GameManager.instance.allbtn = true;//라면스포너로 이동(스폰 중지->재개)
        GameManager.instance.btn2 = true;// 버튼불변수를 여기서 켜버리기 
        Debug.Log("버튼2번");
        StartCoroutine(ResetButton());
    }
    public void Btn3(){
        GameManager.instance.allbtn = true;//라면스포너로 이동(스폰 중지->재개)
        GameManager.instance.btn3 = true;// 버튼불변수를 여기서 켜버리기 
        Debug.Log("버튼3번");
        StartCoroutine(ResetButton());
    }
    
    public void Btn4(){
        GameManager.instance.allbtn = true;//라면스포너로 이동(스폰 중지->재개)
        GameManager.instance.btn4 = true;// 버튼불변수를 여기서 켜버리기 
        Debug.Log("버튼4번");
        StartCoroutine(ResetButton());
    }

    public void FadeBtn(){
        string nextSceneName = "GameScene";
        FindObjectOfType<SceneFader>().StartFade(nextSceneName);
    }

    public void HomeBtn(){
        if(login.Instance.isEnd){
            string nextSceneName = "SampleScene";
            FindObjectOfType<SceneFader>().StartFade(nextSceneName);
            login.Instance.isEnd = false;
        }else{
            return;
        }
            
    }
    public void NicknameEnd(){
        if(login.Instance.isEnd){
             
        }
    }

    public void RetryNowBTN(){
        SceneManager.LoadScene("GameScene"); 
    }
    public void NotLoginButHomeBtn(){       
        string nextSceneName = "SampleScene";
        FindObjectOfType<SceneFader>().StartFade(nextSceneName);
    }
    public void Ranking(){
        string nextSceneName = "Ranking";
        FindObjectOfType<SceneFader>().StartFade(nextSceneName);
    }


    public void RetryBtn(){
        SceneManager.LoadScene("SampleScene"); 
    }
        private IEnumerator ResetButton()
        {
        // 1초 동안 대기
        yield return new WaitForSeconds(1f);
        Debug.Log("쉬는게가능 저땜에멈추는거아녜요;;");
        
        // 버튼 상태 초기화
        buttonPressed = false;
        }

    public void Restart(){
        string nextSceneName = "GameScene";
            FindObjectOfType<SceneFader>().StartFade(nextSceneName);
    }

    public void Rules(){
        string nextSceneName = "GameRules";
            FindObjectOfType<SceneFader>().StartFade(nextSceneName);
    }

    public void StopTime(){// 게임 일시중지하려면 time.timeScale을 1에서 0으로 변경하면 됨.
        Time.timeScale = 0.0f;
    }
    public void StartTime(){// 게임 중지 풀려면 time.timeScale을 0에서 1으로 변경하면 됨.
        Time.timeScale = 1.0f;
    }

}
