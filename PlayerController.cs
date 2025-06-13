using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //rigidbody of player
    
    private float movementX; //movement for x axis
    private float movementY; //movement for y axis
    
    public float speed = 0; //speed that player moves
    public TextMeshProUGUI countText;
    public GameObject winTextObject; //ui object to display win text
    private int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get and store the rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false); //set the text to false so it does not show at start
    }

    //OnMove function is called when a move input is detected
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //convert the input value into a vector2
        
        //store x and y components of the movement
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);

            //destroy enemy
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    // fixedupdate is called once per fixed frame-rate frame
    private void FixedUpdate()
    {
        // creates a 3D movement vector using the X and Y inputs
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // apply force to the rigidbody to move the player
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroy current object
            Destroy(gameObject);
            //update the winText to display "you lose"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose";
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        //other.gameObject.SetActive(false);
    }
}
