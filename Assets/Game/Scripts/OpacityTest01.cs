using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityTest01 : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float targetFade = 0.3f;
    float originalOpacity;

    Material mat;

    bool fade;
    bool isWorking;

    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        originalOpacity = mat.color.a;
    }


    void Update()
    {
        if(isWorking)
        {
            if(fade)
            {
                Fade();
            }
            else
            {
                ResetFade();
            }
        }
    }

    public void StartFade(bool fade)
    {
        isWorking = true;
        this.fade = fade;
    }

    void Fade()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, targetFade, fadeSpeed * Time.deltaTime));

        if (smoothColor.a < (targetFade + 0.01)) smoothColor.a = targetFade; // с методом Mathf.Lerp() оно долго будет не равно на микрочислах. 

        mat.color = smoothColor;
        if (mat.color.a == targetFade) isWorking = false;
    }
    void ResetFade()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        
        if (smoothColor.a > (originalOpacity - 0.01)) smoothColor.a = originalOpacity; // с методом Mathf.Lerp() оно долго будет не равно на микрочислах. 

        mat.color = smoothColor;
        if (mat.color.a == originalOpacity) isWorking = false;
    }
}
