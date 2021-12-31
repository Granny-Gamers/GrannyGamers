using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilTree : MonoBehaviour
{
    public TurnSystem turnSystem;
    
    public AnvilMovement anvil;
    public Transform tree;

    private int _turn = 0;

    private int patternCounter = 0;

    // Update is called once per frame
    private void FixedUpdate()
    {
        TurnHandler();
    }

    // Detects when a new turn is occuring and spawns a new anvil
    private void TurnHandler()
    {
        if (_turn < turnSystem.turnCount)
        {
            _turn++;
            SpawnAnvil();
        }
    }

    // Spawns an anvil in a random location under the tree
    private void SpawnAnvil()
    {
        int xPos = PatternHandler();
        Vector3 randVector = new Vector3(xPos, 0, 0);
        AnvilMovement copy = Instantiate(anvil, tree.position + randVector, tree.rotation);
        copy.isCopy = true;
        copy.SetActive(true);
    }

    private int PatternHandler()
    {
        int x_loc = 0;

        if (patternCounter == 0)
        {
            x_loc = -2;
            patternCounter++;
        }
            

        else if (patternCounter == 1)
        {
            x_loc = -1;
            patternCounter++;
        }

        else if (patternCounter == 2)
        {
            x_loc = 0;
            patternCounter++;
        }

        else if (patternCounter == 3)
        {
            x_loc = 1;
            patternCounter++;
        }

        else if (patternCounter == 4)
        {
            x_loc = 2;
            patternCounter = 0;
        }

        return x_loc;
    }
}
