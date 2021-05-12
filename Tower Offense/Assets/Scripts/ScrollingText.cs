using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	public TMP_Text tutorialText;

	// Use this for initialization
	public void Display()
	{
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i <= fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			tutorialText.text = currentText;
			yield return new WaitForSecondsRealtime(delay);
		}
	}
}
