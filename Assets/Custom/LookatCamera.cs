using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;

    private Coroutine LookCoroutine;

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(Lookat());
    }

    private IEnumerator Lookat()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * Speed;

            yield return null;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 30), "Look At"))
        {
            StartRotating();
        }    
    }
}
