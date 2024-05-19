using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
