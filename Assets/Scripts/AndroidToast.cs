using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AndroidToast : MonoBehaviour
{
    public TMP_Text txt;
    private float fadeInOutTime = 0.3f;
    private static AndroidToast instance = null;

    [SerializeField]
    private GameObject createtab;
    [SerializeField]
    private GameObject loginTab;
    [SerializeField]
    private GameObject NicknameTab;

    public static AndroidToast Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<AndroidToast>();
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance) instance = this;
    }

    void Start()
    {
        txt = this.gameObject.GetComponent<TMP_Text>();
        txt.enabled = false;
        
    }

    void Update(){
        if(login.Instance.isCreated == true){

            showMessage("회원가입 완료", 1.5f);
            createtab.SetActive(false);
            //FindObjectOfType<SceneFader>().Start2Fade();
            FindObjectOfType<SceneFader>().LetStartFade();
            loginTab.SetActive(true);

            login.Instance.isCreated = false;
        }else if(login.Instance.isnotCreated){
            showMessage("비밀번호는 6자리 이상 입력해주십시오.", 1.5f);
            login.Instance.isnotCreated = false;
        }else if(login.Instance.isSent){
            showMessage("정상적으로 메일을 전송했습니다.", 1.5f);
            login.Instance.isSent = false;
        }else if(login.Instance.isnotLoggedIn){
            showMessage("아이디와 비밀번호를 다시 한번 확인해 주십시오.", 1.5f);
            login.Instance.isnotLoggedIn = false;
        }else if(login.Instance.isLogined){
            showMessage("로그인 성공", 1.5f);
            loginTab.SetActive(false);
            //FindObjectOfType<SceneFader>().Start2Fade();
            FindObjectOfType<SceneFader>().LetStartFade();
            NicknameTab.SetActive(true);
            login.Instance.isLogined = false;
        }
    }

    public void showMessage(string msg, float durationTime)
    {
        StartCoroutine(showMessageCoroutine(msg, durationTime));
        Debug.Log("됨");
    }

    private IEnumerator showMessageCoroutine(string msg, float durationTime)
    {
        Color originalColor = txt.color;
        txt.text = msg;
        txt.enabled = true;

        yield return fadeInOut(txt, fadeInOutTime, true);

        float elapsedTime = 0.0f;
        while(elapsedTime < durationTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return fadeInOut(txt, fadeInOutTime, false);

        txt.enabled = false;
        txt.color = originalColor;
    }

    private IEnumerator fadeInOut(TMP_Text target, float durationTime, bool inOut)
    {
        float start, end;
        if (inOut)
        {
            start = 0.0f;
            end = 1.0f;
        }
        else
        {
            start = 1.0f;
            end = 0f;
        }

        Color current = Color.white; 
        float elapsedTime = 0.0f;

        while (elapsedTime < durationTime)
        {
            float alpha = Mathf.Lerp(start, end, elapsedTime / durationTime);

            target.color = new Color(current.r, current.g, current.b, alpha);

            //Debug.Log(target.color);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
