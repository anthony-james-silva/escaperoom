using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class gameman : MonoBehaviour
{
    public float collectablesneeded;
    public string nextlevelname;
    
    float collectCount;
    
    UIman uiman;
    DoorManager doorMan;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiman = GameObject.FindGameObjectWithTag("UI").GetComponent<UIman>();

        doorMan = GameObject.FindGameObjectWithTag("DoorMan").GetComponent<DoorManager>();
    }

    // Update is called once per frame
    public void addPoints(float amount){
        collectCount += amount;
        uiman.UpdateCollectText(collectCount);
        doorMan.CheckDoor();
        checkend();
    }

    public float getPoints(){
        return collectCount;
    }

    private void checkend(){
        if(collectCount >= collectablesneeded){
            
            SceneManager.LoadScene(nextlevelname);
        }
    }
}
