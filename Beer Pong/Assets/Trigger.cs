using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public int ballsMissed;
    public Material blurMaterial;
    public float blurScale;

    // Start is called before the first frame update
    void Start()
    {
        blurScale = 0;
        blurMaterial.SetFloat("_Size", blurScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            ballsMissed += 1;
            blurScale += .25f;
            blurMaterial.SetFloat("_Size", blurScale);
            Debug.Log("balls missed: " + ballsMissed);
            Destroy(other.gameObject);
        }
    }
}
