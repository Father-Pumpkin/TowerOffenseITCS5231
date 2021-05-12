using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Handles object interactions and looking
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Interactable focus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 10))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                SetFocus(interactable);
            }
        }
        else
        {
            RemoveFocus();
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        
    }
}
