using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{//이 스크립트를 넣으면 바로 페이더 실행됨.
//버튼스크립트에 스타트페이더 넣으면 꺼지는 거 실행됨.(무조건 씬에 이 스크립트가 있어야됨) 

    [SerializeField]
    private Image Fade;
    [SerializeField]
    private float FadeSpeed = 2.0f;
    private bool isFadingOut = false;
    //알파값, 
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFade(string sceneName){
        StartCoroutine(FadeOut(sceneName));
    }
    public void LetStartFade(){
        StartCoroutine(FadeIn());
    }
    public void Start2Fade(){
        StartCoroutine(loginFadeOut());
    }

    IEnumerator FadeOut(string SceneName){

        if(isFadingOut){
            yield break;
        }

        isFadingOut = true;

        float alpha = 0f;
        while(alpha < 1){
            alpha += FadeSpeed * Time.deltaTime;
            Fade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
        
    }
    IEnumerator loginFadeOut(){

        if(isFadingOut){
            yield break;
        }

        isFadingOut = true;

        float alpha = 0f;
        while(alpha < 1){
            alpha += 2 * Time.deltaTime;
            Fade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        //SceneManager.LoadScene(SceneName);
        
    }

    IEnumerator FadeIn(){
        float alpha = 1.0f;
        while(alpha > 0){
            alpha -= FadeSpeed * Time.deltaTime;
            Fade.color = new Color(0, 0, 0, alpha);
            isFadingOut = false;
            yield return null;
        }
    }
}
