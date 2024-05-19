using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	[SerializeField]
	private GameObject	cardMaster;

	[SerializeField]
	private GameObject	showSetListMaster;

	private CardRollManager		cardRollManager;
	private CardSeleter			cardSeleter;
	private SetChecker			setChecker;
	private ShowSetListManager	showSetListManager;

	private int					stage;
	[SerializeField]
	private int					lastStage = 10;

	public int					Stage { get => stage; }


	// Start is called before the first frame update
	void Start()
	{
		cardRollManager = cardMaster.GetComponent<CardRollManager>();
		setChecker = cardMaster.GetComponent<SetChecker>();
		cardSeleter = cardMaster.GetComponent<CardSeleter>();
		showSetListManager = showSetListMaster.GetComponent<ShowSetListManager>();
		stage = 0;
		rerollStage();
		return ;
	}

	public void rerollStage()
	{
		stage++;
		cardRollManager.drawCards();
		cardSeleter.ResetSelete();
		setChecker.ResetSetList();
		showSetListManager.ResetShowSetList();
		setChecker.FindAllSet(cardRollManager.nineCards);
		return;
	}
}
