using UnityEngine;
using System.Collections;
using System;

public class DataManager : MonoBehaviour
{	
	protected static DataManager mInstance = null;
	public static DataManager Instance 
	{
		get 
		{
			if (mInstance == null)
			{
				GameObject go = new GameObject("_DataManager");
				mInstance = go.AddComponent(typeof(DataManager)) as DataManager;	
				DontDestroyOnLoad(go);
			}
			return mInstance;
		}
	}
	
	void OnDestroy()
	{
		mInstance = null;
	}

	public static DataManager GetInstance()
	{
		return Instance;
	}

	
}
