using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Ramen : MonoBehaviour
{
    private RamenSpawner ramen;
    private CameraShake cameraShake;
    //라면 이미지를 띄우는 스크립트.
    //싱글톤으로 만들어 버튼에 연결해서 쓴다. 싱글톤은 라면스포너에...;;;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();// 카메라에 붙어있는 카메라쉐이크 스크립트를 가져옴!
        ramen = FindObjectOfType<RamenSpawner>();
    }
    void Update()
    {
        
        //일치할 때
        if(GameManager.instance.btn1 && gameObject.tag=="btn1"){
            correct();
            GameManager.instance.btn1 = false;
        }else if(GameManager.instance.btn2 && gameObject.tag=="btn2"){
            //ramen.StopRamen();
            correct();
            GameManager.instance.btn2 = false;
        }else if(GameManager.instance.btn3 && gameObject.tag=="btn3"){
            correct();
            GameManager.instance.btn3 = false;
        }else if(GameManager.instance.btn4 && gameObject.tag=="btn4"){
            //ramen.StopRamen();
            correct();
            GameManager.instance.btn4 = false;
        }
        //일치하지 않을 때
        else if(GameManager.instance.btn1 && gameObject.tag!="btn1"){
            Not();          
            GameManager.instance.btn1 = false;
        }else if(GameManager.instance.btn2 && gameObject.tag!="btn2"){
            Not();                  
            GameManager.instance.btn2 = false;
        }else if(GameManager.instance.btn3 && gameObject.tag!="btn3"){
            Not();                    
            GameManager.instance.btn3 = false;
        }else if(GameManager.instance.btn4 && gameObject.tag!="btn4"){
            Not();                   
            GameManager.instance.btn4 = false;
        }
        Destroy(gameObject, 1f);
        
        if(GameManager.instance.allbtn == true){
            //GameManager.instance.isEating = false;            
            ramen.StopRamen();
            GameManager.instance.ResetButtons();
            Destroy(gameObject);
            GameManager.instance.allbtn = false;
            GameManager.instance.allbtnAnd = true;//트루가 되면 라면스포너로 넘어감.
            
            Debug.Log("사라집니다.");
        }
        
        GameManager.instance.ResetButtons();

    }

    public void DestroySystem(GameObject Ramen){
        Destroy(Ramen);
    }
    private void correct(){
        ramen.Audio();
        GameManager.instance.Count();
    }
    private void Not(){
        GameManager.instance.isReduction = true;
        cameraShake.Play();
    }
   
}
