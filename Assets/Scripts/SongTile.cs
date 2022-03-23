using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongTile : MonoBehaviour
{

	#region Variables

	RectTransform rectTransform;

	Image buttonImage;

	Button button;

	public bool active;

	public Text songBigTitle, songSmallTitle, artist, difficulty;
	public Image rank;

	#endregion

	#region Unity Methods

	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		buttonImage = GetComponent<Image>();
		button = GetComponent<Button>();
		
	}


	void Update()
	{
		SetActive();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Active")
		{
			active = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Active")
		{
			active = false;
		}
	}



	#endregion

	#region User Methods

	void SetActive()
	{
		if (active)
		{
			rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
			rectTransform.anchoredPosition = new Vector2(-105, 0);
			buttonImage.color = Color.black;
			button.enabled = true;
			songBigTitle.text = songSmallTitle.text;
		}
		else
		{
			rectTransform.localScale = new Vector3(1, 1, 1);
			rectTransform.anchoredPosition = new Vector2(0, 0);
			buttonImage.color = Color.black;
			button.enabled = false;
		}
	}

	#endregion
}
