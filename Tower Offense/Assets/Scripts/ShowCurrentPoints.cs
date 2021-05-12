using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowCurrentPoints : MonoBehaviour
{
    public TMP_Text total_points_text;
    public TMP_Text strength_text;
    public TMP_Text sneak_text;
    public TMP_Text not_enough_points_text;
    public int alpha;

    public GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
        alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.hasNoPoints)
        {
            Debug.Log("Resetting Alpha");
            alpha = 255;
            not_enough_points_text.color  = new Color(255, 0, 0, alpha);
            gm.hasNoPoints = false;
        }
        total_points_text.text = "Current Available Points: " + gm.getPoint();
        strength_text.text = "Current: " + PlayerPrefs.GetInt("Strength");
        sneak_text.text = "Current: " + PlayerPrefs.GetInt("Sneak");
        alpha -= 5; 
        alpha = Mathf.Clamp(alpha, 0, 255);
        not_enough_points_text.color = new Color(255, 0, 0, alpha);
    }
}
