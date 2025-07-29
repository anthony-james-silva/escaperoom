using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class platerinter : MonoBehaviour
{

    
    public float playerActionDistance;

    public string[] newOptions;
    [SerializeField] private GameObject dropDown;
    [SerializeField] private GameObject EKeyImage;
    [SerializeField] private GameObject readImage;
    [SerializeField] private string key;

    public string interactibleType;

    private KeyCode keyCode;

    bool raycastResult;

    Transform cam;
    private bool reading;

    [SerializeField] private string readtext;

    gameman gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        reading = false;
        gm = GameObject.Find("gameman").GetComponent<gameman>();
        EKeyImage.GetComponent<TextMeshProUGUI>().text = key;
        Debug.Log("Key set to: " + key);       
        EKeyImage.SetActive(false);
        keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key, true);
        
        readImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        raycastResult = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActionDistance);
        Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward * playerActionDistance), Color.green);
        if (raycastResult && hit.transform.CompareTag("interact"))
        {
            if (reading == false)
            {

                EKeyImage.SetActive(true);

                if (Input.GetKeyDown(keyCode))
                {
                    Debug.Log(string.Format("{0},{1},{2}", cam.position.x, cam.position.y, cam.position.z));
                    if (interactibleType == "door")
                    {
                        Destroy(hit.transform.gameObject);
                        gm.addPoints(1);
                        Debug.Log("Interacting with " + hit.transform.name);
                        EKeyImage.SetActive(true);
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                    else if (interactibleType == "read")
                    {
                        Debug.Log("read");
                        reading = true;
                        readImage.SetActive(true);
                        readImage.GetComponent<TextMeshProUGUI>().text = readtext;
                        EKeyImage.SetActive(false);
                        dropDown.SetActive(false);
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                    else if (interactibleType == "dropDown")
                    {
                        Debug.Log("test");
                        reading = true;
                        dropDown.SetActive(true);
                        readImage.SetActive(false);
                        EKeyImage.SetActive(false);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        dropDown.GetComponent<TMP_Dropdown>().ClearOptions();
                        dropDown.GetComponent<TMP_Dropdown>().AddOptions(newOptions.OfType<string>().ToList());

                    }
                }
            }
        }
        else
        {


            reading = false;
            EKeyImage.SetActive(false);
            readImage.SetActive(false);
            dropDown.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        
    }
}
