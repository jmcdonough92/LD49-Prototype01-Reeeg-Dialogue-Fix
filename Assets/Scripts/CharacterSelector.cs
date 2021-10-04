using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] GameObject image;

    [YarnCommand("show")]
    public void Show()
    {
        image.SetActive(true);
    }

    [YarnCommand("hide")]
    public void Hide()
    {
        image.SetActive(false);
    }

    //[YarnCommand("cauli")]
    //public void Cauli(string expression)
    //{
    //    switch (expression)
    //    {
    //        case "neutral":

    //            break;
    //        case "happy":

    //            break;
    //        case "sad":

    //            break;
    //        case "angry":

    //            break;
    //        case "surprised":

    //            break;
    //    }
    //}
}
