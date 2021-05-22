using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Picture : MonoBehaviour
{

    public Texture2D image;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
