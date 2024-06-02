using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


//게임의 점수를 관리하는 클래스
public class ScoreManager : MonoBehaviour
{
	//각 상황별로 얻거나 잃는 점수 양
	public readonly int	CHECK_SUCCESS = 1;
	public readonly int	CHECK_FAIL = -1;
	public readonly int	SHORTAGE_SUCCESS = 3;
	public readonly int	SHORTAGE_FAIL = -1;
	public readonly int TIMEOVER_PENALTY = -1;

	[SerializeField]
	private Text		scoreText;

	//현재 점수
	private int			score;

	private void Awake()
	{
		score = 0;
		UpdateText();
		return ;
	}

	//화면에 표시되는 스코어 업데이트
	public void	UpdateText()
	{
		scoreText.text = score.ToString();
		return ;
	}

	//점수 정보를 획득하는 메소드
	public int	getScore()
	{
		return (score);
	}

	//현재 점수를 가감하는 메소드
	public void	addScore(int score = 0)
	{
		this.score += score;
		UpdateText();
		Debug.Log("now score = " + this.score);
		return ;
	}

}
