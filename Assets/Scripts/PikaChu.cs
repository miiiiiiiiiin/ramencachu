using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaChu : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isEating){
            animator.SetBool("isEating", true);
            /*if(GameManager.instance.allbtn == true){
                animator.SetBool("isEatting",false);
                GameManager.instance.isEatting = false;
            }else{*/
                //StartCoroutine(StopEating());
           // }
           Button button = FindObjectOfType<Button>();
            if(GameManager.instance.allbtn){
                animator.SetBool("isEating", false);
                GameManager.instance.isEating = false;
            }
            
        }else if(GameManager.instance.isEating == false){
            animator.SetBool("isEating",false);
        }
        if(GameManager.instance.isTouched == true){//물먹는애니메이션
            //Debug.Log("물먹기");
            animator.SetBool("isEating", false);
            animator.SetBool("isDrinking", true);
            StartCoroutine(StopDrinking());
            

        }
    }

    IEnumerator StopDrinking(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isDrinking", false);
        animator.SetBool("isEating", true);
        //Debug.Log("test");
        GameManager.instance.isTouched = false;
    }

    IEnumerator StopEating(){
        yield return new WaitForSeconds(3f);
        animator.SetBool("isEating", false);
        GameManager.instance.isEating = false;
    }
    
    public void Eating1(){
        animator.SetTrigger("Btn1");
    }
    public void Eating2(){
        animator.SetTrigger("Btn2");
    }
    public void Eating3(){
        animator.SetTrigger("Btn3");
    }
    public void Eating4(){
        animator.SetTrigger("Btn4");
    }
}
