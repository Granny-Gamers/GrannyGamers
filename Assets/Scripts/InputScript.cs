using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputScript : MonoBehaviour
{
    private string fullInput = "";
    public Text displayText;

    void Update()
    {
        string input = Input.inputString;
        if (input.Equals(""))
            return;

        char c = input[0];
        fullInput += c;
        displayText.text = fullInput;
    }
}
