using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	[SerializeField]
	private GameObject			cardMaster;

	[SerializeField]
	private GameObject			showSetListMaster;

	[SerializeField]
	private GameObject			canvas;

	private CardRollManager		cardRollManager;
	private CardSeleter			cardSeleter;
	private SetChecker			setChecker;
	private ShowSetListManager	showSetListManager;
	private TimeManager			timeManager;

	private PrintStageManager	printStageManager;

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
		printStageManager = canvas.GetComponent<PrintStageManager>();
		timeManager = transform.GetComponent<TimeManager>();
		stage = 0;
		NextStage();
		return ;
	}

	public void	NextStage()
	{
		ResetStage();
		printStageManager.updateText(++stage);
		Debug.Log("Now Stage : " + stage);
		return ;
	}

	private void	ResetStage()
	{
		timeManager.ResetTime();
		cardRollManager.drawCards();
		cardSeleter.ResetSelete();
		setChecker.ResetSetList();
		showSetListManager.ResetShowSetList();
		setChecker.FindAllSet(cardRollManager.nineCards);
		return ;
	}

	public void	TimeOverEvent()
	{
		if (stage < lastStage)
			NextStage();
		return ;
	}
}
