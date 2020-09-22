using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public static int s_BallsMissed = 0;
    public static float s_BlurScale = 0.0f;

    [SerializeField] 
    private Material blurMaterial;
    
    void Start()
    {
        s_BlurScale = 0;
        blurMaterial.SetFloat("_Size", s_BlurScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            s_BallsMissed += 1;
            s_BlurScale += .25f;
            blurMaterial.SetFloat("_Size", s_BlurScale);
            Debug.Log("balls missed: " + s_BallsMissed);
            Destroy(other.gameObject);
        }
    }
}
