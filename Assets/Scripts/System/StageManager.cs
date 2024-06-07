using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//게임의 스테이지 진행을 관리하는 클래스
public class StageManager : MonoBehaviour
{
	//카드를 관리하는 클래스가 모여있는 게임오브젝트
	[SerializeField]
	private GameObject				cardMaster;

	//합을 유저에게 보여주는 클래스가 모여있는 게임 오브젝트
	[SerializeField]
	private GameObject				showSetListMaster;

	//화면에 정보를 출력하는 클래스가 모여있는 게임 오브젝트
	[SerializeField]
	private GameObject				canvasUI;

	//배경화면을 관리하는 canvas
	[SerializeField]
	private GameObject				canvasBackground;

	//각종 게임을 관리하는 클래스들
	private CardRollManager			cardRollManager;
	private CardSeleter				cardSeleter;
	private SetChecker				setChecker;
	private ShowSetListManager		showSetListManager;
	private TimeManager				timeManager;
	private ScoreManager			scoreManager;
	private PrintStageManager		printStageManager;
	private PrintEventPanelManager	printEventPanelManager;
	private PrintBackgroundManager	printBackgroundManager;

	//결을 선언하는 버튼
	[SerializeField]
	private Button					shortageButton;

	//현재 스테이지
	private int						stage;
	//마지막 스테이지
	[SerializeField]
	private int						lastStage = 10;

	//스테이지 정보를 외부에서 얻을 수 있도록 열어둠
	public int						Stage { get => stage; }


	// Start is called before the first frame update
	void Start()
	{
		cardRollManager = cardMaster.GetComponent<CardRollManager>();
		setChecker = cardMaster.GetComponent<SetChecker>();
		cardSeleter = cardMaster.GetComponent<CardSeleter>();
		showSetListManager = showSetListMaster.GetComponent<ShowSetListManager>();
		printStageManager = canvasUI.GetComponent<PrintStageManager>();
		printEventPanelManager = canvasUI.GetComponent<PrintEventPanelManager>();
		printBackgroundManager = canvasBackground.GetComponent<PrintBackgroundManager>();
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
		printEventPanelManager.showStartPanel();
		printBackgroundManager.Rollbackground();
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
		printEventPanelManager.showTimeoverPanel();
		StartCoroutine(StageTimeOverEvent());
		return ;
	}

	//필드가 결을 선언할 수 있는지 없는지 확인하고, 알맞은 행동을 취함
	public void IsShortage()
	{
		if (printEventPanelManager.showShortagePanel(setChecker.ShortageCheck() ) )
			StartCoroutine(ShortageSuccessEvent());
		else
			StartCoroutine(ShortageFailEvent());
		return;
	}

	//시간 초과 이벤트
	IEnumerator	StageTimeOverEvent()
	{
		Debug.Log("TIMEOVER!");
		scoreManager.addScore(scoreManager.TIMEOVER_PENALTY);
		cardSeleter.enabled = false;
		shortageButton.interactable = false;
		yield return (new WaitForSeconds(3.0f));
		cardSeleter.enabled = true;
		shortageButton.interactable = true;
		NextStage();
		yield break ;
	}

	//결을 성공했을 떄의 이벤트
	IEnumerator	ShortageSuccessEvent()
	{
		Debug.Log("SHORTAGE S");
		scoreManager.addScore(scoreManager.SHORTAGE_SUCCESS);
		cardSeleter.enabled = false;
		shortageButton.interactable = false;
		yield return (new WaitForSeconds(2.5f));
		cardSeleter.enabled = true;
		shortageButton.interactable = true;
		NextStage();
		yield break ;
	}

	//결을 잘못 선언했을 때의 이벤트
	IEnumerator	ShortageFailEvent()
	{
		Debug.Log("SHORTAGE F");
		scoreManager.addScore(scoreManager.SHORTAGE_FAIL);
		cardSeleter.enabled = false;
		shortageButton.interactable = false;
		yield return (new WaitForSeconds(2.1f));
		cardSeleter.enabled = true;
		shortageButton.interactable = true;
		yield break ;
	}
}
