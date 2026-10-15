using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    Slider slider;
    private float time;
    [SerializeField]
    private GameObject waterpanel;
    private Image panelImage;
    private Ramen ramen;

    void Start()
    {
        slider = GetComponent<Slider>();
        panelImage = waterpanel.GetComponent<Image>();
        ramen = FindObjectOfType<Ramen>();
    }
    void Update()
    {
        if(slider.value > 0.0f){
            slider.value -= Time.deltaTime;
            if(GameManager.instance.isReduction ==true && gameObject.tag == "timer"){
                slider.value -= 10;
                GameManager.instance.isReduction = false;
            }
            //time = slider.value;
            if(GameManager.instance.isTouched == true && gameObject.tag == "Water"){
                panelImage.raycastTarget = true;  
                // if(GameManager.instance.allbtn == false){
                                      
                // }
                Invoke("StopPanel", 0.25f);
                slider.value += 10f;
                //원래 여기서 바로 터치드 닫았는데 피카추 스크립트에서 닫으니까 애니가 실행됨           
            }   
        }else{
            Debug.Log("Time Out");
            GameManager.instance.GameOver();
            if(gameObject.tag == "Water"){// 목말라엔딩
                if(GameManager.instance.count >= 20){
                    SceneManager.LoadScene("GameOver3");//성공
                }else{
                    SceneManager.LoadScene("GameOver2");//실패
                }                
            }else if(GameManager.instance.count >= 20){//시간끝나엔딩
                SceneManager.LoadScene("GameOver3");//겜성공
            }else{
                SceneManager.LoadScene("GameOver1");//겜오버
            }
            
        }
    }

    private void StopPanel(){
        panelImage.raycastTarget = false;
    }
}
