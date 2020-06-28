using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
	[SerializeField]
	private Object targetScene;

	void OnTriggerEnter()
	{
		SceneManager.LoadScene(targetScene.name);
	}
}
