using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ImageTransparencyController : MonoBehaviour
{
    public Image img;
    public float waitDuration = 8.0f;
    //public float duration = 0.5f;
    private float targetAlpha = 1.0f;

    void Start()
    {
        if (img == null)
        {
            img = GetComponent<Image>();
        }
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);
        
        float elapsedTime = 0.0f;
        Color color = img.color;

        while (elapsedTime < waitDuration)
        {
            elapsedTime += Time.deltaTime/18;
            color.a = Mathf.Lerp(color.a, targetAlpha, elapsedTime / waitDuration);
            img.color = color;
            yield return null; 
        }

        
        color.a = targetAlpha;
        img.color = color;
    }

    public void ChangeTransparency(float alpha)
    {
        targetAlpha = Mathf.Clamp01(alpha);
        StartCoroutine(DelayedStart());
    }
}