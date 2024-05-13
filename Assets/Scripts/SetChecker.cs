using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SetChecker : MonoBehaviour
{
	[SerializeField]
	private List<int[]>	setList =  new List<int[]>();

	public List<int[]> SetList { get => setList; }

	private CardSeleter cardSeleter;

	private void Start()
	{
		cardSeleter = transform.GetComponent<CardSeleter>();
		if (cardSeleter == null)
			Debug.Log("Can't found cardSeleter in SetCheck.cs!");
		return ;
	}

	public bool	SetCheck(List<Card> cards)
	{
		bool	result = true;
		int		idx = -1;

		if (cards == null || cards.Count != 3)
			return (false);
		while (result && ++idx < cards.Count)
		{
			if (!CheckThreeEqualOrDifferent(cards[0].getCardType()[idx],
										  cards[1].getCardType()[idx], 
										  cards[2].getCardType()[idx]) )
			{
				result = false;
			}
		}
		if (result)
		{
			int[] found = new int[] { cards[0].index, cards[1].index, cards[2].index };
			if (setList.FindIndex(x => x.SequenceEqual(found)) == -1)
			{
				setList.Add(found);
				Debug.Log("new set found! : " + string.Join(", ", setList[setList.Count - 1]));
				Debug.Log("now setList Count : " + setList.Count);
			}
		}
		return (result);
	}

	bool CheckThreeEqualOrDifferent(int a, int b, int c)
	{
		if ( (a == b && b == c) || (a != b && b != c && a != c) )
			return (true);
		else
			return (false);
	}

	public void ResetSetList()
	{
		Debug.Log("Clear \"setList\" in SetChecker.cs");
		setList.Clear();
		return ;
	}
}
