using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoritesManager : MonoBehaviour
{

    public ArrayList favorites = new ArrayList();

     public ArrayList favoritesPicturesList = new ArrayList();

    public Image image;
    public GameObject content;
    

    public void UpdateList(GameObject picture, bool action)
    {
        if (!action)
        {
            favorites.Add(picture);

            Image newImage = Instantiate(image, content.transform);
            Texture2D texture = picture.GetComponent<Renderer>().material.GetTexture("_MainTex") as Texture2D;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            newImage.sprite = sprite;
            favoritesPicturesList.Add(newImage.gameObject);
        }
        else
        {
            GameObject delImage = (GameObject) favoritesPicturesList[favorites.IndexOf(picture)];
            favoritesPicturesList.Remove(delImage);
            Destroy(delImage);

            favorites.Remove(picture);
        }
    }
}
