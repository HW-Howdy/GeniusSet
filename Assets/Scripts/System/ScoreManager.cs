using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//게임의 점수를 관리하는 클래스
public class ScoreManager : MonoBehaviour
{
	private int	score;

	public int	Score { get => score; set => score = value; }

	private void Awake()
	{
		score = 0;
		return ;
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}


}
