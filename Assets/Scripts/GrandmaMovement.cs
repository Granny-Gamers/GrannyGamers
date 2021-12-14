using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmaMovement : MonoBehaviour
{
    public Text displayText;

    private Rigidbody2D body;
    private string _commandString = "";

    [SerializeField] private float horiSpeed;
    [SerializeField] private float vertSpeed;

    // Initializes variables before application starts
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Checks if there was input
        string input = Input.inputString;
        if (input == "")
            return;

        // Checks if the "run command" key was inputted
        char charInput = input[0];
        if (charInput == '\n' || charInput == '\r')
        {
            Execute();
            return;
        }

        // Checks if a directional key was inputted
        if (!(charInput == 'q' || charInput == 'w' || charInput == 'e' || charInput == 'a' || charInput == 'd'))
            return;

        // Ensures no more than 5 commands are inputted
        if (_commandString.Length < 5)
            _commandString += charInput;
        displayText.text = _commandString;
    }

    // Runs the commands that have been inputted
    private void Execute()
    {
        // Iterates through each character in the command string to run each command
        foreach (char c in _commandString)
        {
            if (c == 'q')
                body.velocity = new Vector2(-horiSpeed, vertSpeed);

            else if (c == 'w')
                body.velocity = new Vector2(body.velocity.x, vertSpeed);

            else if (c == 'e')
                body.velocity = new Vector2(horiSpeed, vertSpeed);

            else if (c == 'a')
                body.velocity = new Vector2(-horiSpeed, body.velocity.y);

            else if (c == 'd')
                body.velocity = new Vector2(horiSpeed, body.velocity.y);
        }

        // Resets the command string
        _commandString = "";
        displayText.text = _commandString;
    }
}
