using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmaMovement : MonoBehaviour
{
    public Text displayText;

    private Rigidbody2D body;
    private string _stringInput = "";

    [SerializeField] private float speed;

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
        if (_stringInput.Length < 5)
            _stringInput += charInput;
        displayText.text = _stringInput;
    }

    // Runs the commands that have been inputted
    private void Execute()
    {
        Debug.Log(_stringInput);

        // Resets the text
        _stringInput = "";
        displayText.text = _stringInput;
    }



    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void UpdateDemo() 
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
