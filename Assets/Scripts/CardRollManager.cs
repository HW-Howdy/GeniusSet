using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRollManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] cardObjects;

	[SerializeField]
	private List<Card> cards = new List<Card>();
	private List<int[]> cardDeck = new List<int[]>();

	public List<Card> nineCards { get => cards; }

	// Start is called before the first frame update
	void Awake()
	{
		for (int i = 0; i < cardObjects.Length; i++)
			cards.Add(cardObjects[i].GetComponent<Card>());
		return ;
	}

	public void drawCards()
	{
		int idx;

		resetList();
		for (int i = 0; i < cards.Count; i++)
		{
			idx = Random.Range(0, cardDeck.Count);
			cards[i].HeadType = cardDeck[idx][0];
			cards[i].HeadColor = cardDeck[idx][1];
			cards[i].BodyColor = cardDeck[idx][2];
			cards[i].cardSetting();
			cardDeck.RemoveAt(idx);
		}
		Debug.Log("draw new cards");
		return ;
	}

	private void resetList()
	{
		cardDeck.Clear();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					cardDeck.Add(new int[] { i, j, k });
				}
			}
		}
		cardDeck.OrderBy(_ => Random.Range(-1.0f, 1.0f)).ToList();
		return ;
	}
}
