using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardRollManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] cardObjects;

	private List<Card>	cards = new List<Card>();
	private List<int[]> cardDeck = new List<int[]>();

	private SetChecker setChecker;
	private CardSeleter cardSeleter;

	// Start is called before the first frame update
	void Start()
	{
		setChecker = transform.GetComponent<SetChecker>();
		if (setChecker == null)
			Debug.Log("Can't found setChecker in CardRollManager.cs!");
		cardSeleter = transform.GetComponent<CardSeleter>();
		if (cardSeleter == null)
			Debug.Log("Can't found cardSeleter in CardRollManager.cs!");
		for (int i = 0; i < cardObjects.Length; i++)
			cards.Add(cardObjects[i].GetComponent<Card>());
		rerollStage();
		return ;
	}

	public void	rerollStage()
	{
		drawCards();
		cardSeleter.ResetSelete();
		setChecker.ResetSetList();
		setChecker.FindAllSet(cards);
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
