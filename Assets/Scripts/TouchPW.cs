using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TouchPW : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
   public TMP_InputField inputField;
    private bool isButtonHeld = false;

    void Update()
    {
        // 버튼을 누르고 있을 때만 Password로 변경
        if (isButtonHeld)
        {
            SetPasswordContentType();
        }
        else
        {
            ResetContentType();
        }
    }

    // IPointerDownHandler를 구현하여 버튼을 누를 때 호출
    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    // IPointerUpHandler를 구현하여 버튼을 뗄 때 호출
    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonHeld = false;
    }

    void SetPasswordContentType()
    {
        inputField.contentType = TMP_InputField.ContentType.Standard;
        inputField.ForceLabelUpdate();
    }

    void ResetContentType()
    {
        inputField.contentType = TMP_InputField.ContentType.Password;
        inputField.ForceLabelUpdate();
    }
}
