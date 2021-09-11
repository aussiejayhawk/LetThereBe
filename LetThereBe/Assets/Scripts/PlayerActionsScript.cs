using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsScript : MonoBehaviour
{
    public Interactable activeInteractable;
    public float interactDistance = 3f;
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") || Input.GetButton("Fire2"))
        {
            CheckInteractable();
        }
    }

    private GameObject CheckInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance, layerMask))
                
        {
            Debug.Log(hit.collider);
            activeInteractable = hit.collider.transform.GetComponent<Interactable>();
            Debug.Log(activeInteractable);
        }

        if (activeInteractable != null)
        {
            activeInteractable.Interact(this);
            activeInteractable = null;
        }
        
        return null;
    }
}
