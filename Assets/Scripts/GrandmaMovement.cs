using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmaMovement : MonoBehaviour
{
    // Debug display.
    public Text displayText;
    public Text turnText;

    // Field for passing the turn system.
    public TurnSystem turnSystem;

    // Field for passing the timeline manager
    public TimelineManager timelineManager;

    //Used to control animation
    public Animator animator;

    // Fields that vary movement.
    public Transform movePoint;
    public float moveSpeed;

    // Counter for controlling the pause after each unique movement.
    private int _pauseCounter = 0;
    private int _pauseDuration = 12;

    // String property that holds the commands that need to be executed.
    private string _commandString = "";

    // Boolean flag that indicates if there are commands that need to be executed.
    private bool _hasMoves = false;

    // Editable private fields for the distance that the player moves per movement.
    [SerializeField] private float horiDist;
    [SerializeField] private float vertDist;

    //remove movepoint from being a child
    private void Start()
    {
        movePoint.parent = null;
    }

    // Runs every frame.
    private void Update()
    {
        InputHandler();
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
        if (_hasMoves == true)
            return;

        // If the timeline is running, then input should not be accepted.
        if (timelineManager.isActive == true)
            return;

        // Checks if there was input.
        string input = Input.inputString;
        if (input == "")
            return;

        // Checks if the "run command" key was inputted.
        char charInput = input[0];
        if (charInput == '\n' || charInput == '\r')
        {
            _hasMoves = true;
            return;
        }

        // Check if user wants to delete action.
        if (charInput == '\b' && _commandString != "")
        {
            _commandString = _commandString.Remove(_commandString.Length - 1, 1);
            displayText.text = "Input: " + _commandString;
            return;
        }

        // Checks if a directional key was inputted.
        if (!(charInput == 'q' || charInput == 'w' || charInput == 'e' || charInput == 'a' || charInput == 'd'))
            return;

        // Ensures no more than 5 commands are inputted.
        if (_commandString.Length < 5)
            _commandString += charInput;
        displayText.text = "Input: " + _commandString;
    }

    // Detects when movement should occur and executes the movements.
    private void MoveHandler()
    {
        // If no moves need to be executed, then end the call.
        if (_hasMoves == false)
            return;

        // If the timeline is running, then no moves should be ran.
        if (timelineManager.isActive == true)
            return;

        // If there are no moves to be made and the movement is complete, then end the movement and allow inputs.
        if (_commandString.Length == 0 && Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            _hasMoves = false;
            animator.SetFloat("Speed", 0);
            return;
        }

        MovePauseLogic();
    }

    // Processes the commands into the movement and pause logic.
    private void MovePauseLogic()
    {
        // If the pause is over, then execute the current command.
        if (_pauseCounter == _pauseDuration)
        {
            _pauseCounter = 0;

            // Update command display.
            _commandString = _commandString.Substring(1);
            displayText.text = "Input: " + _commandString;

            // Update the turn counter.
            int currentTurn = ++turnSystem.turnCount;
            turnText.text = "Turn: " + currentTurn.ToString();

            return;
        }

        // If the pause is occuring, do not make any movements.
        if (_pauseCounter > 0)
        {
            _pauseCounter++;
            return;
        }

        // If the previous command has completed, then it queues the next movement and begins pausing.
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            // Begins the pause.
            _pauseCounter = 1;

            // Updates the move point location.
            MovePointLogic();

            return;
        }

        // Move towards the move point by an amount given by moveSpeed.
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed);
    }

    // Updates the move point location depending on the current movement command.
    private void MovePointLogic()
    {
        FindObjectOfType<AudioManager>().Play("Movement");
        // Update the position of the move point.
        char c = _commandString[0];

        // Change the move point location depending on the next input.
        if (c == 'q')
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            AdvanceMovePoint(-horiDist, vertDist);
        }

        else if (c == 'w')
        {
            AdvanceMovePoint(0, vertDist);
        }

        else if (c == 'e')
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            AdvanceMovePoint(horiDist, vertDist);
        }

        else if (c == 'a')
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            AdvanceMovePoint(-horiDist, 0);
        }

        else if (c == 'd')
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            AdvanceMovePoint(horiDist, 0);
        }
    }

    // Changes the move point's position based on horizontalDist and verticalDist.
    private void AdvanceMovePoint(float horizontalDist, float verticalDist)
    {
        movePoint.position += new Vector3(horizontalDist, verticalDist, 0);
        animator.SetFloat("Speed", 1);
    }
}


