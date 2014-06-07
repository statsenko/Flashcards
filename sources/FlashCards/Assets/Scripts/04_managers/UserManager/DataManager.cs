using UnityEngine;
using System.Collections;
using System;

using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public class DataManager : MonoBehaviour
{	
	protected static DataManager mInstance = null;
	private string _dbPath = null;

	public static DataManager Instance 
	{
		get 
		{
			if (mInstance == null)
			{
				GameObject go = new GameObject("_DataManager");
				mInstance = go.AddComponent(typeof(DataManager)) as DataManager;	
				DontDestroyOnLoad(go);

				#if UNITY_IPHONE 
//					_dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)  + "/leasson.sqlite";
				//#else if UNITY_ANDROID
			//		_dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)  + "/leasson.sqlite";
				#endif
				ReadDB();

			}
			return mInstance;
		}
	}

	static void ReadDB()
	{
		
		Debug.LogWarning("ReadDB");

		// Подключаемся к нашей базе данных
		string connectionString = "URI=file:" + Application.dataPath + "/DB/leasson.sqlite";

		//connectionString = _dbPath;

		using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
		{
			dbcon.Open();
			
			// Выбираем нужные нам данные
			var sql = "SELECT * FROM category";
			using (IDbCommand dbcmd = dbcon.CreateCommand())
			{
				dbcmd.CommandText = sql;
				// Выполняем запрос
				using (IDataReader reader = dbcmd.ExecuteReader())
				{
					// Читаем и выводим результат
					while (reader.Read())
					{
						const string frmt = "ID: {0}; Title: {1}";
						Debug.Log(string.Format(frmt,
						                        reader.GetInt32(0),
						                        reader.GetString(1)
						                        ));
					}
				}
			}
			// Закрываем соединение
			dbcon.Close();
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
