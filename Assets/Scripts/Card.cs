using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	public int index;

	[SerializeField]
	private GameObject head;
	[SerializeField]
	private GameObject body;

	[SerializeField]
	private Sprite[] headTypes;
	[SerializeField]
	private Color[] headColors;
	[SerializeField]
	private Color[] bodyColors;

    private int headType;
    private int headColor;
	private int bodyColor;

	public int HeadType { get => headType; set => headType = value; }
    public int HeadColor { get => headColor; set => headColor = value; }
    public int BodyColor { get => bodyColor; set => bodyColor = value; }

	// Start is called before the first frame update
	void Start()
	{
		cardSetting();
		return ;
	}

	public void cardSetting()
	{
		head.GetComponent<SpriteRenderer>().sprite = headTypes[headType];
		head.GetComponent<SpriteRenderer>().color = headColors[headColor];
		body.GetComponent<SpriteRenderer>().color = bodyColors[bodyColor];
		if (headType == 1)
		{
			head.transform.localScale = new Vector3(0.8f, 0.8f, 1);
			head.transform.position = body.transform.position;
		}
		else if (headType == 2)
		{
			head.transform.localScale = new Vector3(1, 1, 1);
			head.transform.position = body.transform.position - new Vector3(0, 0.1f, 0);
		}
		else
		{
			head.transform.localScale = new Vector3(1, 1, 1);
			head.transform.position = body.transform.position;
		}
		return ;
	}
	
	public int[] getCardType()
	{
		int[] result = new int[] { headType, headColor, bodyColor };
		return (result);
	}
	
}
