//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{

    public Texture2D image;
    public string description;

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
