using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float movespeed = 6f;
    public float jumpforce = 4.0f;
    public float grounddrag = 2.0f;
    public float airdrag = 0.01f;
    public float movemultiplier = 10.0f;
    public float airmultiplier = .5f;
    


    Vector3 movedirection;

    float v;
    float h;
    float playerhight = 2.0f;
    bool isgrounded;
    bool shouldjump = false;

    [SerializeField]  GameObject[] groundSensors;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = CheckGround();
        getInput();
        controllDrag();
        controllspeed();

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded){
            shouldjump = true;
            isgrounded = false;
        }
    }
    private void FixedUpdate()
    {
        moveplayer();

        if(shouldjump){
            shouldjump = false;
            jump();
        }
    }

    void getInput() {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        movedirection = transform.forward * v + transform.right * h;
    }

    void moveplayer(){
        if(isgrounded){
            rb.AddForce(movedirection.normalized * movespeed* movemultiplier, ForceMode.Acceleration);
            
        }
        else
        {
            rb.AddForce(movedirection.normalized * movespeed* airmultiplier, ForceMode.Acceleration);
        }
        
    }

    void jump(){
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }
    void controllDrag(){
        if(isgrounded){
            rb.linearDamping = grounddrag;
        }
        else{
            rb.linearDamping = airdrag;
        }
    }
    void controllspeed(){
        Vector3 flatvel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(flatvel.magnitude > movespeed){
            Vector3 limitedvel = flatvel.normalized * movespeed;
            rb.linearVelocity = new Vector3(limitedvel.x, rb.linearVelocity.y, limitedvel.z);
        }
    }


    bool CheckGround(){
        foreach(GameObject sensor in groundSensors){
            if(Physics.Raycast(sensor.transform.position, Vector3.down, playerhight / 2 + 0.1f)){
                return true;
            }
        }
       
        return false;
    }

}
