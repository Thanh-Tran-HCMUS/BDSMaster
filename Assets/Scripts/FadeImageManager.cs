using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImageManager : MonoBehaviour
{
    public float seconds = 2f;
    //public bool autoFade = false;
    public Image image1;
    public Image image2;
    
    IEnumerator FadeOut(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / seconds);
            image.color = c;
            yield return new WaitForEndOfFrame();
        }
        image.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / seconds);
            image.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOutText(Text text)
    {
        float elapsedTime = 0.0f;
        Color c = text.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / seconds);
            text.color = c;
            yield return new WaitForEndOfFrame();
        }
        text.gameObject.SetActive(false);
    }

    IEnumerator FadeInText(Text text)
    {
        float elapsedTime = 0.0f;
        Color c = text.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / seconds);
            text.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartFadeOut(Image image)
    {
        StartCoroutine(FadeOut(image));
    }

    public void StartFadeIn(Image image)
    {
        StartCoroutine(FadeIn(image));
    }

    public void StartFadeOutText(Text text)
    {
        StartCoroutine(FadeOutText(text));
    }

    public void StartFadeInText(Text text)
    {
        StartCoroutine(FadeInText(text));
    }

    IEnumerator FadeOutImage(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / seconds);
            image.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeInImage(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / seconds);
            image.color = c;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(FadeOut(image));
        StartCoroutine(FadeIn(image2));
    }

}
