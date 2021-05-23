using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PictureImage : MonoBehaviour, IDragHandler
{

    public GameObject unFullScreenBtn;
    public GameObject fullScreenBtn;
    public GameObject zoomInBtn;
    public GameObject zoomOutBtn;
    public GameObject exitBtn;

    bool zoomedIn = false;

    Vector2 maxOffsetUnFull = new Vector2(1000f, 0);
    Vector2 minOffsetUnFull = new Vector2(0, -450f);
    Vector2 halfVec = new Vector2(0.5f, 0.5f);

    RectTransform rect;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
        rect = GetComponent<Image>().rectTransform;
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
        

        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.pivot = halfVec;
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;

        
        unFullScreenBtn.SetActive(true);
        fullScreenBtn.SetActive(false);
        zoomInBtn.SetActive(true);

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
        zoomInBtn.SetActive(false);

        exitBtn.transform.localPosition = new Vector3(415, 205);
    }

    public void ZoomIn()
    {
        transform.localScale = new Vector3(2, 2);

        zoomOutBtn.SetActive(true);
        unFullScreenBtn.SetActive(false);
        zoomInBtn.SetActive(false);
        exitBtn.SetActive(false);

        zoomedIn = !zoomedIn;
    }
     public void ZoomOut()
    {
        transform.localScale = new Vector3(1, 1);
        transform.localPosition = Vector3.zero;


        zoomOutBtn.SetActive(false);
        unFullScreenBtn.SetActive(true);
        zoomInBtn.SetActive(true);
        exitBtn.SetActive(true);

        zoomedIn = !zoomedIn;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (zoomedIn)
        {
            transform.position += (Vector3)eventData.delta;
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -959, 959), Mathf.Clamp(transform.localPosition.y, -417, 417));
        }
        
    }
}
