using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform cam;

    private void Start()
    {
        GameObject[] cams =GameObject.FindGameObjectsWithTag("MainCamera");
        cam = cams[0].transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
