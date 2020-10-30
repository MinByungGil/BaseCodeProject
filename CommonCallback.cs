using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * 예
 StartCoroutine(CommonCallback.SetTimeout(() => {
            Debug.Log("A");
        }, 0.25f));

StartCoroutine(CommonCallback.SetEndOfFrame(() => {
            Debug.Log("B");
        }));
 */


public class CommonCallback : MonoBehaviour
{
    public static readonly WaitForSeconds WaitOneSeconds = new WaitForSeconds(1f);
    public static readonly WaitForSeconds WaitHalfSeconds = new WaitForSeconds(0.5f);
    public static readonly WaitForSeconds WaitQuarterSeconds = new WaitForSeconds(0.25f);
    public static readonly WaitForSeconds WaitPointOneSeconds = new WaitForSeconds(0.1f);
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
    static public IEnumerator SetTimeout(Action callback, float time)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
    static public IEnumerator SetEndOfFrame(Action callback)
    {
        yield return WaitForEndOfFrame;
        callback();
    }    
}
