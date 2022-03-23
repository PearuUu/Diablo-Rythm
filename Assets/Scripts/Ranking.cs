using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{

	#region Variables

	private Transform entryContainer;
	private Transform entryTemplate;
	private List<Transform> rankingEntryTransformList;
	
		
	#endregion

	#region Unity Methods

	private void Awake()
	{
		entryContainer = transform.Find("RankingEntryContainer");
		entryTemplate = entryContainer.Find("RankingEntryTemplate");

		entryTemplate.gameObject.SetActive(false);


		

		//AddRankingEntry(10000, "CMK");

		string jsonString = PlayerPrefs.GetString("rankingTable");
		Hightscores hightscores = JsonUtility.FromJson<Hightscores>(jsonString);

		/*if (hightscores == null)
		{
			// There's no stored table, initialize
			Debug.Log("Initializing table with default values...");
			AddRankingEntry(1000000, "TST");
			
			// Reload
			jsonString = PlayerPrefs.GetString("highscoreTable");
			hightscores = JsonUtility.FromJson<Hightscores>(jsonString);
		}*/

		//sorting
		for (int i = 0; i<hightscores.rankingEntryList.Count; i++)
		{
			for(int j = i+1; j< hightscores.rankingEntryList.Count; j++)
			{
				if(hightscores.rankingEntryList[j].score > hightscores.rankingEntryList[i].score)
				{
					RankingEntry tmp = hightscores.rankingEntryList[i];
					hightscores.rankingEntryList[i] = hightscores.rankingEntryList[j];
					hightscores.rankingEntryList[j] = tmp;
				}
			}
		}
		rankingEntryTransformList = new List<Transform>();
		foreach (RankingEntry rankingEntry in hightscores.rankingEntryList)
		{
			CreateRankingEntryTransform(rankingEntry, entryContainer, rankingEntryTransformList);
		}

		
		
	}

	#endregion

	#region User Methods

	public void Back()
	{
		SceneManager.LoadScene("Main Menu");
	}

	private void CreateRankingEntryTransform(RankingEntry rankingEntry, Transform container, List<Transform> transformList)
	{
		float templateHeight = Screen.currentResolution.height / 15f;
		Transform entryTransform = Instantiate(entryTemplate, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
		entryTransform.gameObject.SetActive(true);

		int rank = transformList.Count + 1;
		string rankString;

		switch (rank)
		{
			default: rankString = rank + "TH"; break;

			case 1: rankString = "1ST"; break;
			case 2: rankString = "2ND"; break;
			case 3: rankString = "3RD"; break;
		}

		entryTransform.Find("placeText").GetComponent<Text>().text = rankString;

		int score = rankingEntry.score;

		entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

		string name = rankingEntry.name;
		entryTransform.Find("nameText").GetComponent<Text>().text = name;

		
		transformList.Add(entryTransform);
	}

	public void AddRankingEntry(int score, string name)
	{	
		//Create rankingEntry
		RankingEntry rankingEntry = new RankingEntry { score = score, name = name };

		//Load saved Hightscores
		string jsonString = PlayerPrefs.GetString("rankingTable");
		Hightscores hightscores = JsonUtility.FromJson<Hightscores>(jsonString);

		if (hightscores == null)
		{
			// There's no stored table, initialize
			hightscores = new Hightscores()
			{
				rankingEntryList = new List<RankingEntry>()
			};
		}

		// Add new entry to Hightscores
		hightscores.rankingEntryList.Add(rankingEntry);

		// Save updated Hightcores
		string json = JsonUtility.ToJson(hightscores);
		PlayerPrefs.SetString("rankingTable", json);
		PlayerPrefs.Save();
	}

	private class Hightscores
	{
		public List<RankingEntry> rankingEntryList;
	}

	/* single ranking entry */

	[System.Serializable]
	private class RankingEntry
	{
		public int score;
		public string name;
	}

	#endregion

}
