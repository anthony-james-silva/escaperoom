
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
public class UIman : MonoBehaviour
{
    public TextMeshProUGUI CollectibleText;


    public void UpdateCollectText(float amount){
        CollectibleText.text = "Collectables:" + amount.ToString();

    }
    
}

