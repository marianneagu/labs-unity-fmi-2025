using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    InputAction moveAction;
    Vector2 moveRead;
    [SerializeField]
    private float speedMultiplier;
    private Rigidbody rb;
    [SerializeField]
    private GameObject playerCamera;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        MovePlayer();
        //CameraFollowPlayer();
    }

    private void ReadInput()
    {
        // Read the full 2D input vector (e.g., [x: 1, y: 0.5])
        moveRead = moveAction.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {


        //float moveY = moveRead.y;
        //float moveX = moveRead.x;

        float moveY = Mathf.Lerp(animator.GetFloat("inputY"), moveRead.y, Time.deltaTime * speedMultiplier);
        float moveX = Mathf.Lerp(animator.GetFloat("inputX"), moveRead.x, Time.deltaTime * speedMultiplier);

        if (animator != null)
        {

            animator.SetFloat("inputY", moveY);
            animator.SetFloat("inputX", moveX);

        }
    }

    private void CameraFollowPlayer()
    {
        playerCamera.transform.position = new Vector3(transform.position.x, playerCamera.transform.position.y, transform.position.z);
    }

}
