using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;


//게임의 스테이지 진행을 관리하는 클래스
public class StageManager : MonoBehaviour
{
	//카드를 관리하는 클래스가 모여있는 게임오브젝트
	[SerializeField]
	private GameObject			cardMaster;

	//합을 유저에게 보여주는 클래스가 모여있는 게임 오브젝트
	[SerializeField]
	private GameObject			showSetListMaster;

	//화면에 정보를 출력하는 클래스가 모여있는 게임 오브젝트
	[SerializeField]
	private GameObject			canvas;

	//각종 게임을 관리하는 클래스들
	private CardRollManager		cardRollManager;
	private CardSeleter			cardSeleter;
	private SetChecker			setChecker;
	private ShowSetListManager	showSetListManager;
	private TimeManager			timeManager;
	private ScoreManager		scoreManager;

	private PrintStageManager	printStageManager;

	//현재 스테이지
	private int					stage;
	//마지막 스테이지
	[SerializeField]
	private int					lastStage = 10;

	//스테이지 정보를 외부에서 얻을 수 있도록 열어둠
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
		scoreManager = transform.GetComponent<ScoreManager>();
		stage = 0;
		NextStage();
		return ;
	}

	//스테이지를 다음으로 넘김
	public void	NextStage()
	{
		if (++stage <= lastStage)
		{
			ResetStage();
			printStageManager.updateText(stage, stage == lastStage);
			Debug.Log("Now Stage : " + stage);
		}
		else
		{
			//Something gameover event..
		}
		return ;
	}

	//스테이지를 초기화함
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

	//시간 초과시 호출되는 함수
	public void	TimeOverEvent()
	{
		StartCoroutine(StageTimeOverEvent());
		return ;
	}

	//시간 초과 이벤트
	IEnumerator	StageTimeOverEvent()
	{
		Debug.Log("TIMEOVER!");
		scoreManager.addScore(scoreManager.TIMEOVER_PENALTY);
		cardSeleter.enabled = false;
		yield return (new WaitForSeconds(3.0f));
		cardSeleter.enabled = true;
		NextStage();
		yield break ;
	}

	//결을 성공했을 떄의 이벤트
	IEnumerator	ShortageSuccessEvent()
	{
		yield break ;
	}

	//결을 잘못 선언했을 때의 이벤트
	IEnumerator	ShortageFailEvent()
	{
		yield break ;
	}

	//필드가 결을 선언할 수 있는지 없는지 확인하고, 알맞은 행동을 취함
	public void	IsShortage()
	{
		if (setChecker.ShortageCheck())
			StartCoroutine(ShortageSuccessEvent());
		else
			StartCoroutine(ShortageFailEvent());
		return ;
	}
}
