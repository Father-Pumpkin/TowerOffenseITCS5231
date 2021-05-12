using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileTexture : MonoBehaviour
{
    Renderer rend;
    public float x_scale = -1f;
    public float y_scale = -1f;
    public float z_scale = -1f;


    void Start()
    {
        if(x_scale == -1)
        {
            x_scale = this.transform.localScale.x / 10;
        }
        if (y_scale == -1)
        {
            y_scale = this.transform.localScale.y / 10;
        }
        if (z_scale == -1)
        {
            z_scale = this.transform.localScale.y / 10;
        }
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.mainTextureScale = new Vector3(x_scale, y_scale, z_scale);
    }
}
