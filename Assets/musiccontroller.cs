using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musiccontroller : MonoBehaviour
{

    public Toggle mytoggle;
    [SerializeField]
    private AudioSource audioBGM;
    // Start is called before the first frame update
    void Start()
    {
        audioBGM = GetComponent<AudioSource>();
        bool isOn = PlayerPrefs.GetInt("ToggleState", 1) == 1;
        mytoggle.isOn = isOn;
        if(isOn){
            AudioListener.volume = 1;
        }else if(isOn == false){
            AudioListener.volume = 0;
        }

        mytoggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn){
        PlayerPrefs.SetInt("ToggleState", isOn ? 1 : 0);
        PlayerPrefs.Save();
        

    }

    // Update is called once per frame
    public void StopMusic(){
        AudioListener.volume = AudioListener.volume == 0?1:0;
        //삼항 연산자. 값이 0이면 1을 반환, 아니면 0을 반환한다.
    }
}
