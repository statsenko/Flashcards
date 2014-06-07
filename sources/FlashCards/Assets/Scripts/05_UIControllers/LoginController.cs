using UnityEngine;
using System.Collections;

public class LoginController : UIController
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




}
