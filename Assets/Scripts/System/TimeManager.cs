using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


//게임 내 시간을 관리하는 클래스
public class TimeManager : MonoBehaviour
{
	//현재 남은 스테이지 시간
	private int							time = 0;
	//스테이지 당 시간
	[SerializeField]
	private int							timePerStage = 60;
	//남은 시간을 표시할 Text
	[SerializeField]
	private Text						timeText;

	//시간 초과 시 호출될 StageManager의 메소드를 저장함
	private delegate void				TimeOverMethod();
	private static event TimeOverMethod	TimeOverEvent;

	//Time 정보를 외부에서 얻을 수 있도록 열어둠
	public int							getTime { get => time; }

	// Start is called before the first frame update
	void Start()
	{
		time = timePerStage;
		StartCoroutine(CountDown());
		TimeOverEvent += GameObject.Find("StageMaster").GetComponent<StageManager>().TimeOverEvent;
		return ;
	}

	//시간을 초기화함
	public void	ResetTime()
	{
		time = timePerStage;
		StopAllCoroutines();
		StartCoroutine(CountDown());
		Debug.Log("Set Time : " + time);
		return ;
	}

	//시간 초과 시 호출되는 함수
	void	TimeOver()
	{
		StopAllCoroutines();
		TimeOverEvent();
		return ;
	}

	//화면에 표시된 시간을 갱신함
	public void updateText()
	{
		timeText.text = "TIME : " + time;
		return ;
	}

	//1초마다 time을 1 감소시킴
	IEnumerator	CountDown()
	{
		bool	flag = true;

		updateText();
		while (flag)
		{
			yield return (new WaitForSeconds(1.0f));
			time--;
			updateText();
			if (time <= 0)
				TimeOver();
		}
		yield break ;
	}
}
