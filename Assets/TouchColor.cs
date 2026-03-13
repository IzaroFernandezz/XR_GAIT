using UnityEngine;
using System.Collections;

public class WallFlashOnTouch : MonoBehaviour
{
	public Color flashColor = Color.red;
	public float flashDuration = 0.1f;

	private Color originalColor;
	private Renderer rend;
	private bool isFlashing = false;

	void Start()
	{
		rend = GetComponent<Renderer>();
		originalColor = rend.material.color;
	}

	private void OnTriggerEnter(Collider other)
	{
		/*
		if (other.CompareTag("Hand"))
		{
			if (!isFlashing)
				StartCoroutine(Flash());
		}
		*/
		rend.material.color = flashColor;
	}

	private void OnTriggerExit(Collider other)
	{
		/*
		if (other.CompareTag("Hand"))
		{
			if (!isFlashing)
				StartCoroutine(Flash());
		}
		*/
		rend.material.color = originalColor;
	}

}
