using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PowerCubeScript : Interactable
{
    
    public Vector3 orderPos;
    
    public override int DecideOutcome()
    {
        int outcome = Random.Range(1, 6);


        return outcome;
    }
}
