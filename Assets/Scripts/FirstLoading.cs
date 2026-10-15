using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;


public class FirstLoading : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private Image image;
    void Start()
    {
        StartCoroutine(Loading());
        //Image image = GetComponent<Image>();
    }

   IEnumerator Loading(){
        yield return new WaitForSeconds(0.3f);
        if(GameManager.instance.HighScoreSave == 0){
            text.DOCounter(0,100,1f).OnComplete(()=> image.DOFade(1, 0.5f)).OnComplete(()=> SceneManager.LoadScene("Login"));
        }else{
            text.DOCounter(0,100,1f).OnComplete(()=> {
                image.DOFade(1, 0.5f).OnComplete(()=> {
                SceneManager.LoadScene("SampleScene");
                });           
            });      
        }
    }
}
