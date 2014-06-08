using UnityEngine;
using System.Collections;

public class DeckSceneController : UIController
{
	private DataManager _dataManager;

	
	void Awake()
	{
		DoAwake ();
	}

	void Start()
	{
		DoStart();
		_dataManager = DataManager.Instance;
		Debug.LogWarning("DataManager loaded");
	}

	void OnBackButton (GameObject sender)
	{
		Debug.LogWarning("On Back Button");


	}

	void OnSignInOrSynchronize(GameObject sender)
	{
		Debug.LogWarning("OnSignInOrSynchronize");
	}
}
