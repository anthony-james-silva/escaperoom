using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator[] doors;
    public float[] Amount;

    gameman gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gameman").GetComponent<gameman>();
    }

    // Update is called once per frame
    public void CheckDoor(){
        float playerPoints = gm.getPoints();
        for(int i = 0; i < Amount.Length; i++){
            if(playerPoints >= Amount[i]){
                doors[i].SetTrigger("DoorOpen");
            }
        }
}
}
