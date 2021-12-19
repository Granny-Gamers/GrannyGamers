using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmaMovement : MonoBehaviour
{
    public Text displayText;
    public Text velocityText;

    public float moveSpeed = 5f;
    public Transform movePoint;

    private Rigidbody2D rb;

    // String property that holds the commands that need to be executed.
    private string _commandString = "";

    // Boolean flag that indicates if movement is occuring.
    private bool _move = false;

    // Editable private fields for the speed in the Unity editor.
    [SerializeField] private float horiSpeed;
    [SerializeField] private float vertSpeed;

    // Initializes variables before application starts.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensures that the sprite movement does not move the move point
        movePoint.parent = null;
    }

    // Runs every frame.
    private void Update()
    {
        InputHandler();
        velocityText.text = "Velocity:" + rb.velocity.ToString();
    }

    // Runs in time with the physics system.
    private void FixedUpdate()
    {
        MoveHandler();
    }

    // Receives the input and adds it to the _commandString.
    private void InputHandler()
    {
        // If a move is being executed, then input should not be accepted.
        if (_move == true)
            return;

        // Checks if there was input.
        string input = Input.inputString;
        if (input == "")
            return;

        // Checks if the "run command" key was inputted.
        char charInput = input[0];
        if (charInput == '\n' || charInput == '\r')
        {
            _move = true;
            return;
        }

        // Check if user wants to delete action
        if (charInput == '\b' && _commandString != "")
        {
            _commandString = _commandString.Remove(_commandString.Length - 1, 1);
            displayText.text = _commandString;
            return;
        }

        // Checks if a directional key was inputted.
        if (!(charInput == 'q' || charInput == 'w' || charInput == 'e' || charInput == 'a' || charInput == 'd'))
            return;

        // Ensures no more than 5 commands are inputted.
        if (_commandString.Length < 5)
            _commandString += charInput;
        displayText.text = _commandString;
    }

    // Detects when movement should occur and executes the movements.
    private void MoveHandler()
    {
        // If no moves need to be executed, then end the call.
        if (_move == false)
            return;

        // If there are no moves to be made, then end the movement and allow inputs.
        if (_commandString.Length == 0)
        {
            _move = false;
            return;
        }

        // Moves should be executed once the character comes to a complete stop.
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            MoveLogic();
        }
    }

    // Processes the command to movement logic.
    private void MoveLogic()
    {
        char c = _commandString[0];
        if (c == 'q')
            Move(-horiSpeed, vertSpeed);

        else if (c == 'w')
            Move(rb.velocity.x, vertSpeed);

        else if (c == 'e')
            Move(horiSpeed, vertSpeed);

        else if (c == 'a')
            Move(-horiSpeed, rb.velocity.y);

        else if (c == 'd')
            Move(horiSpeed, rb.velocity.y);

        // Moves to the next command.
        _commandString = _commandString.Substring(1);
        displayText.text = _commandString;
    }

    // Moves the character depending on horizontal and vertical speed.
    private void Move(float horizontalSpeed, float verticalSpeed)
    {
        movePoint.position += new Vector3(horizontalSpeed, verticalSpeed, 0);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed);
    }
}


