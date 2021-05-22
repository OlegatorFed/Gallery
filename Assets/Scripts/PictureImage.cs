using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureImage : MonoBehaviour
{

    public GameObject unFullScreenBtn;
    public GameObject fullScreenBtn;
    public GameObject exitBtn;

    Vector2 maxOffsetUnFull = new Vector2(1000f, 0);
    Vector2 minOffsetUnFull = new Vector2(0, -450f);
    Vector2 halfVec = new Vector2(0.5f, 0.5f);

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPictureClick(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        GetComponent<Image>().sprite = sprite;

        gameObject.SetActive(true);
    }

    public void GoFullScreen()
    {
        RectTransform rect = GetComponent<Image>().rectTransform;

        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.pivot = halfVec;
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;

        
        unFullScreenBtn.SetActive(true);
        fullScreenBtn.SetActive(false);

        exitBtn.transform.localPosition = new Vector3(900, 405);
    }

    public void UnFullScreen()
    {

        RectTransform rect = GetComponent<Image>().rectTransform;

        rect.anchorMin = halfVec;
        rect.anchorMax = halfVec;
        rect.pivot = halfVec;
        rect.offsetMax = maxOffsetUnFull;
        rect.offsetMin = minOffsetUnFull;
        rect.localPosition = Vector3.zero;

        unFullScreenBtn.SetActive(false);
        fullScreenBtn.SetActive(true);

        exitBtn.transform.localPosition = new Vector3(415, 205);
    }
}
