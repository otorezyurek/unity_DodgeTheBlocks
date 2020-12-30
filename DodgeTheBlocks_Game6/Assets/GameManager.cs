using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float slowdown;
	public Text timeText;
	int timeInt;

	private void Update()
	{
		timeInt = (int)Time.timeSinceLevelLoad;
		timeText.text = timeInt.ToString();
	}

	public void GameOver()
	{
		StartCoroutine(Restart());
	}

	IEnumerator Restart()
	{
		Time.timeScale = 1f / slowdown;
		Time.fixedDeltaTime /= slowdown;

		yield return new WaitForSeconds(1f / slowdown);

		Time.timeScale = 1f;
		Time.fixedDeltaTime *= slowdown;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
