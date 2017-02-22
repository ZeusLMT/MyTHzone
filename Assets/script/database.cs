using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class database : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/test.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT ID,blah from test order by blah";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		while (reader.Read())
		{
			int value = reader.GetInt32(0);
			string name = reader.GetString(1);

			Debug.Log( "value= "+value+"  name ="+name);
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
