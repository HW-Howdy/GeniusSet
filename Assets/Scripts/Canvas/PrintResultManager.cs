using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//게임의 결과를 출력해주는 클래스
public class PrintResultManager : MonoBehaviour
{
	//각종 데이터를 표시할 게임오브젝트
	[SerializeField]
	private GameObject	nowScoreText;
	[SerializeField]
	private GameObject	highScoreText;
	[SerializeField]
	private GameObject	newText;

	//출력할 점수 데이터
	private int			nowScore;
	private int			highScore;

	// Start is called before the first frame update
	void Start()
	{
		ShowScore();
		return ;
	}

	void ShowScore()
	{
		nowScore = PlayerPrefs.GetInt("score");
		highScore = PlayerPrefs.GetInt("highScore");
		if (nowScore > highScore)
		{
			highScore = nowScore;
			PlayerPrefs.SetInt("highScore", highScore);
			newText.SetActive(true);
		}
		nowScoreText.GetComponent<Text>().text = nowScore.ToString();
		highScoreText.GetComponent<Text>().text = highScore.ToString();
	}

	public void ResetScoreButton()
	{
		PlayerPrefs.SetInt("score", 0);
		PlayerPrefs.SetInt("highScore", 0);
		ShowScore();
		return ;
	}
}
