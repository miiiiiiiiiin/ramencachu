using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamenSpawner : MonoBehaviour
{
    
    public GameObject[] ramen;

    [SerializeField]
    private Transform spawnerPos;
    
    [SerializeField]
    private float Spawninterval;
    [SerializeField]
    private GameObject waterpanel;
    private Image panelImage;

    void Start()
    {
        StartRamen();
        panelImage = waterpanel.GetComponent<Image>();
    }
    void Update()
    {       
        if(GameManager.instance.allbtnAnd == true){
            
            StartRamen();            
            Debug.Log("라면스포너다시시작 ");
            GameManager.instance.allbtnAnd = false;
        }
    }
    public void StartRamen(){
        StartCoroutine("RamenSpawn");        
    }
    public void StopRamen(){
        if(GameManager.instance.isTouched == false){
            panelImage.raycastTarget = true;
        }
        
        StopCoroutine("RamenSpawn");

    }
    IEnumerator RamenSpawn(){
        yield return new WaitForSeconds(0.3f);
        panelImage.raycastTarget = false;
        while(true){            
            GameManager.instance.isEating = true;
            Spawnerclass();
            Debug.Log("왜실행되지why");
            yield return new WaitForSeconds(Spawninterval);
        }        
    }
    private void Spawnerclass(){
        int index = Random.Range(0, ramen.Length);
        Instantiate(ramen[index], spawnerPos.position, Quaternion.identity);
    }
    public void Audio(){
        GetComponent<AudioSource>().Play();
    }
}
