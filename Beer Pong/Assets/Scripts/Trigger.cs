using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public static int s_BallsMissed = 0;
    
    [SerializeField]
    Material blurMaterial;

    public static float s_BlurScale = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
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
