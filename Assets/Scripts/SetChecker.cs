using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SetChecker : MonoBehaviour
{
	[SerializeField]
	private List<int[]>	setList =  new List<int[]>();
	private List<int[]> foundSetList = new List<int[]>();

	public List<int[]> SetList { get => setList; }

	private CardSeleter cardSeleter;

	private void Start()
	{
		cardSeleter = transform.GetComponent<CardSeleter>();
		if (cardSeleter == null)
			Debug.Log("Can't found cardSeleter in SetCheck.cs!");
		return ;
	}

	public void	SetCheck(List<Card> cards)
	{
		if (IsSet(cards))
		{
			int[] found = new int[] { cards[0].index, cards[1].index, cards[2].index };
			if (setList.FindIndex(x => x.SequenceEqual(found)) == -1)
			{
				setList.Add(found);
				Debug.Log("new set found! : " + string.Join(", ", setList[setList.Count - 1]));
				Debug.Log("now setList Count : " + setList.Count);
			}
		}
		return ;
	}

	public bool	ShortageCheck(List<Card> cards)
	{
		return (false);
	}

	public void	FindAllSet(List<Card> cards)
	{
		foundSetList.Clear();
		for (int i = 0; i < cards.Count - 2; i++)
		{
			for (int j = i + 1;  j < cards.Count - 1; j++)
			{
				for (int k = j + 1; k < cards.Count; k++)
				{
					if (IsSet(new List<Card>() { cards[i], cards[j], cards[k] } ) )
						foundSetList.Add(new int[] { cards[i].index, cards[j].index, cards[k].index });
				}
			}
		}
		Debug.Log("Found Set is " + foundSetList.Count);
		return ;
	}

	private bool	IsSet(List<Card> cards)
	{
		bool	result = true;
		int		idx = -1;

		if (cards == null || cards.Count != 3)
			return (false);
		while (result && ++idx < cards.Count)
		{
			if (!CheckThreeEqualOrDifferent(	cards[0].getCardType()[idx],
												cards[1].getCardType()[idx],
												cards[2].getCardType()[idx]))
			{
				result = false;
			}
		}
		return (result);
	}

	//check 3 parameter, if there all are Equal or Diffenrent, return true. else, return false
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
