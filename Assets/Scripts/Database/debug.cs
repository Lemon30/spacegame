using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class debug : MonoBehaviour {
	// server and database information
	const string db_host = "localhost";
	const int db_port = 5984;
	const string db = "universe";

	// Use this for initialization
	void Start () {
		// create a new server before connecting database
		var server = new CouchServer (db_host, db_port);
		var database = server.GetDatabase (db);

		// Gets entire database. Use GetDocuments("id"); for getting specific document.
		IEnumerable<Star> stars = database.GetAllDocuments<Star>();
		IEnumerator<Star> stars_iter = stars.GetEnumerator ();

		//iterates thourgh documents
		while (stars_iter.MoveNext()) {
			var star = stars_iter.Current;
			// Examples to reach spesific object starting from star. It is recommended that using a null check when necessary.
			Debug.Log ("Name: " + star.name + 
				"\nCoordinates: " + star.coordinates[0] + "," + star.coordinates[1] + "," + star.coordinates[2] +
				"\nPlanets: \n");
			foreach(var planet in star.planets){
				Debug.Log ("\nPNAME:" + planet.name);
				Debug.Log ("\nPCOR:" + planet.coordinates[0] + "," + planet.coordinates[1] + "," + planet.coordinates[2]);
				Debug.Log ("\nPSAT:" + planet.satellites[0].name + ", "+ planet.satellites[0].type);

				//Such as here we need null check otherwise an exception ill be thrown because first planet does not have any facilities.
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
