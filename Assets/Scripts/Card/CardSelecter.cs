using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSeleter : MonoBehaviour
{
	private List<Card>	seletedCards = new List<Card>();

	private SetChecker	setChecker;

	private void Start()
	{
		setChecker = transform.GetComponent<SetChecker>();
		return ;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
			if (hit.collider != null && hit.transform.gameObject.CompareTag("Card"))
			{
				Debug.Log("Hit card : " + hit.transform.gameObject.name);
				ClickCard(hit.transform.gameObject.GetComponent<Card>());
			}
		}
		return ;
	}

	void	ClickCard(Card card)
	{
		if (card == null)
			return ;
		card.OnClick();
		int idx = seletedCards.FindIndex(x => x.index == card.index);
		if (idx == -1)
			seletedCards.Add(card);
		else
			seletedCards.RemoveAt(idx);
		seletedCards.Sort(new Comparison<Card>((x1, x2) => x1.index - x2.index));
		Debug.Log("Now seleted : " + string.Join(", ", seletedCards));
		if (seletedCards.Count == 3)
		{
			setChecker.SetCheck(seletedCards);
			for (int i = 0; i < seletedCards.Count; i++)
				seletedCards[i].OnClick(false);
			ResetSelete();
		}
		return ;
	}

	public void	ResetSelete()
	{
		seletedCards.Clear();
		Debug.Log("Clear \"seletedCards\" in CardSelecter.cs");
		return ;
	}
}
