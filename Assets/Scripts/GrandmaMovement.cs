using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmaMovement : MonoBehaviour
{
    // Debug display
    public Text displayText; 
    public Text turnText;

    public TurnSystem turnSystem;

    // String property that holds the commands that need to be executed.
    private string _commandString = "";

    // Boolean flag that indicates if movement is occuring.
    private bool _move = false;

    // Editable private fields for the speed in the Unity editor.
    [SerializeField] private float horiDist;
    [SerializeField] private float vertDist;

    // Initializes variables before application starts.
    private void Start()
    {
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
        displayText.text = "Input: " + _commandString;
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

        MoveLogic();
    }

    // Processes the command to movement logic.
    private void MoveLogic()
    {
        // Update the turn system since it's dependent on player movement
        int currentTurn = ++turnSystem.turnCount;
        turnText.text = "Turn: " + currentTurn.ToString();

        char c = _commandString[0];
        if (c == 'q')
            Move(-horiDist, vertDist);

        else if (c == 'w')
            Move(0, vertDist);

        else if (c == 'e')
            Move(horiDist, vertDist);

        else if (c == 'a')
            Move(-horiDist, 0);

        else if (c == 'd')
            Move(horiDist, 0);

        // Update the display for the commands
        _commandString = _commandString.Substring(1);
        displayText.text = _commandString;
    }

    // Teleports the character depending on horizontal and vertical distance.
    private void Move(float horizontalDist, float verticalDist)
    {     
        transform.position += new Vector3(horizontalDist, verticalDist, 0);
    }
}


