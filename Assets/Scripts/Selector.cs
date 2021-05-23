using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{

    public Camera instance;
    public PictureImage pictureImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !IsPointerOverUIObject())
        {
            var (hit, succ) = RayCast();

            if (succ)
            {
                //Debug.Log("Noice");
                var picture = hit.transform.GetComponent<Picture>();
                if (picture)
                {
                    //pictureImage.OnPictureClick(picture.GetComponent<Renderer>().material.GetTexture("_MainTex") as Texture2D, picture.description);
                    pictureImage.OnPictureClick(picture);
                }
            }
        }
    }

    private (RaycastHit, bool) RayCast()
    {
        Ray ray = instance.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            //Debug.Log(hit.transform.gameObject.name);
            return (hit, true);
        }

        return (hit, false);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
