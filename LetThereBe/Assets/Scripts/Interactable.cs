using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public SpinScript thisSpinScript;

    public bool isSpinnable;

    public void Interact(PlayerActionsScript player)
    {
        if (isSpinnable == true && thisSpinScript.isSpinning == false)
            
        {
            Debug.Log("we get as far as running Interact Function");
            int rollOutcome = DecideOutcome();
            RollDie(rollOutcome, player);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }

    private void RollDie(int rollOutcome, PlayerActionsScript player)
    {
        StartCoroutine(thisSpinScript.Spin(rollOutcome, 5, player.transform));
    }

    public virtual int DecideOutcome()
    {
        return 0;
    }
    
    
    
}
