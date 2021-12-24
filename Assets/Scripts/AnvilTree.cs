using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilTree : MonoBehaviour
{
    public TurnSystem turnSystem;
    
    public GameObject anvil;
    public Transform tree;

    private int _turn = 0;

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
        int xPos = Random.Range(-3, 3);
        Vector3 randVector = new Vector3(xPos, 0, 0);
        Instantiate(anvil, tree.position + randVector, tree.rotation);
    }
}
