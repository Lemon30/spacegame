using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Star : CouchDocument {
	public string name;

	public List<string> stars;
	public List<string> planet_names;
	public List<Planet> planets;
	public List<int> coordinates;

	public bool is_pinfo_needed;

	public Star(){
		is_pinfo_needed = true;

		stars = new List<string> ();
		planets = new List<Planet> ();
		planet_names = new List<string> ();
		coordinates = new List<int> ();
	}

	public override void ReadJson(JObject obj){
		base.ReadJson (obj);
		name = obj ["star_name"].Value<string> ();
		var coor = obj ["star_coordinates"].Value<JObject> ();

		coordinates.Add (coor["star_x"].Value<int> ());
		coordinates.Add (coor["star_y"].Value<int> ());
		coordinates.Add (coor["star_z"].Value<int> ());

		var planet_list = obj ["planets"].Value<JArray> ();
		foreach (var planet in planet_list) {
			if (!is_pinfo_needed) {
				planet_names.Add (planet ["planet_name"].Value<string> ());
			} else {
				
				planets.Add (new Planet (planet));
			}
		}
	}
}
