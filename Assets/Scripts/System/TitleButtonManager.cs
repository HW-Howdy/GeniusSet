using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//타이틀 화면과 결과 화면에서 사용되는 버튼들을 관리하는 클래스
public class TitleButtonManager : MonoBehaviour
{
	public void	StartButton()
	{
		SceneManager.LoadScene("MainScene");
		return ;
	}

	public void ExitButton()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;

		#else
		Application.Quit();

		#endif
		return ;
	}
}
