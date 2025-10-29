using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction moveAction;
    Vector2 moveRead;
    public float speed;
    private Rigidbody rigidbody;
    public GameObject playerCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        //Movement();

        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z - 5f);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(moveRead.x * speed, 0, moveRead.y * speed), ForceMode.Force);
    }

    private void ReadInput()
    {
        moveRead = new Vector2(moveAction.ReadValue<Vector2>().x, moveAction.ReadValue<Vector2>().y);
        //Debug.Log(moveRead);
    }

    private void Movement()
    {
        transform.position += new Vector3(moveRead.x * Time.deltaTime * speed, 0, moveRead.y * Time.deltaTime * speed);
    }
}
