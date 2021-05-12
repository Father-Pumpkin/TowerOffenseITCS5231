using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class triggerTutorial : MonoBehaviour
{
    public LayerMask m_LayerMask;
    public Image popup;
    public TMP_Text textToShow;
    bool m_Started;
    bool hasTriggered;


    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
        hasTriggered = false;
        popup.enabled = false;
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
       MyCollisions();
    }
    private void Update()
    {
        if (hasTriggered)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ClosePopup();
            }
        }
    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        if (!hasTriggered && hitColliders.Length > 0)
        {
            Debug.Log("Showing Popup Now");
            hasTriggered = true;
            ShowPopup();
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    void ShowPopup()
    {
        Time.timeScale = 0;
        popup.enabled = true;
        textToShow.GetComponent<ScrollingText>().Display();
    }

    void ClosePopup()
    {
        Time.timeScale = 1;
        popup.enabled = false;
        textToShow.enabled = false;
    }

}

