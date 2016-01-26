using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class debug : MonoBehaviour {
	const string db_host = "localhost";
	const int db_port = 5984;
	const string db = "universe";

	// Use this for initialization
	void Start () {
		var server = new CouchServer (db_host, db_port);
		var database = server.GetDatabase (db);

		IEnumerable<Star> stars = database.GetAllDocuments<Star>();
		IEnumerator<Star> stars_iter = stars.GetEnumerator ();
		while (stars_iter.MoveNext()) {
			var s = stars_iter.Current;
			Debug.Log ("Name: " + s.name + 
				"\nCoordinates: " + s.coordinates[0] + "," + s.coordinates[1] + "," + s.coordinates[2] +
				"\nPlanets: \n");
			foreach(var planet in s.planets){
				Debug.Log ("\nPNAME:" + planet.name);
				Debug.Log ("\nPCOR:" + planet.coordinates[0] + "," + planet.coordinates[1] + "," + planet.coordinates[2]);
				Debug.Log ("\nPSAT:" + planet.satellites[0].name + ", "+ planet.satellites[0].type);
				//Debug.Log ("\nPSATF:" + planet.satellites[0].facilities[0].name + ", "+ planet.satellites[0].facilities[0].type);
				Debug.Log ("\nPSAT:" + planet.satellites[1].name + ", "+ planet.satellites[1].type);
				Debug.Log ("\nPSATF:" + planet.satellites[1].facilities[0].name + ", "+ planet.satellites[1].facilities[0].type);
				Debug.Log ("\nPOWN:" + planet.owner);
				foreach (var tile in planet.tiles) {
					Debug.Log ("\nPTILEID:" + tile.id);
					Debug.Log ("\nPTILET:" + tile.type);
					Debug.Log ("\nPTILEB:" + tile.building.id + " " + tile.building.name + " " + tile.building.level + " " + tile.building.type);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
