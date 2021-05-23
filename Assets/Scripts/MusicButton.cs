using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Text text;
    public void MusicSwitch(AudioSource audioSource)
    {
        audioSource.mute = !audioSource.mute;


        text.text = audioSource.mute ? "X" : "♫";
    }
}
