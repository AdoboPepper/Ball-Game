using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    private Rigidbody myBody;
    private bool rollLeft;
    public float speed = 4f;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        rollLeft = true;

    }

    void Update()
    {
        CheckInput();
    }
    void FixedUpdate()
    {
      if (GamePlayController.instance.gamePlaying)
        {
            if (rollLeft)
            {
                myBody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(0f, Physics.gravity.y, speed);
            }
        }

        if (myBody.position.y < -5f)
        {
            Destroy(gameObject);
            
        }
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GamePlayController.instance.gamePlaying)
            {
                GamePlayController.instance.gamePlaying = true;
                GamePlayController.instance.ActiveTileSpawner();
            }            
                
            
        }
        
        if (GamePlayController.instance.gamePlaying)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                rollLeft = !rollLeft;
            }
        }
    }
}