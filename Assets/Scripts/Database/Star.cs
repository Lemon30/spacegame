using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Base star object for parsing data from database. For all information parsing
/// from database, this class should be instanciated. Every other database attribute is 
/// called from inside of this class.
/// </summary>
public class Star : CouchDocument {
	public string name;

	public List<string> stars;
	public List<string> planet_names;
	public List<Planet> planets;
	public List<int> coordinates;

	public bool is_pinfo_needed;

	/// <summary>
	/// Initializes a new instance of the <see cref="Star"/> class.
	/// There should be at least one default constructor in order to
	/// Divan Framework works.
	/// </summary>
	public Star(){
		is_pinfo_needed = true;

		stars = new List<string> ();
		planets = new List<Planet> ();
		planet_names = new List<string> ();
		coordinates = new List<int> ();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Star"/> class.
	/// This time it enables developer to hide inner planet information 
	/// or not. It prevents unnecessary parsing for super-level drawing.
	/// </summary>
	/// <param name="pinfo">If set to <c>true</c>, it parses into sublevels, otherwise not.</param>
	public Star(bool pinfo){
		is_pinfo_needed = pinfo;

		stars = new List<string> ();
		planets = new List<Planet> ();
		planet_names = new List<string> ();
		coordinates = new List<int> ();
	}

	/// <summary>
	/// Reads the json data and parses it into sublevels. All data that has been parsed,
	/// can be called easily inside from derived object.
	/// </summary>
	/// <param name="obj">Object.</param>
	public override void ReadJson(JObject obj){
		// Base JSon object.
		base.ReadJson (obj);

		// Basic information.
		name = obj ["star_name"].Value<string> ();
		var coor = obj ["star_coordinates"].Value<JObject> ();

		coordinates.Add (coor["star_x"].Value<int> ());
		coordinates.Add (coor["star_y"].Value<int> ());
		coordinates.Add (coor["star_z"].Value<int> ());

		// Planet information parsing.
		var planet_list = obj ["planets"].Value<JArray> ();
		foreach (var planet in planet_list) {
			// If do not need any sublevel information, only names will be parsed.
			if (!is_pinfo_needed) {
				planet_names.Add (planet ["planet_name"].Value<string> ());
			} else {
				// Otherwise new planet classes will be derived.
				planets.Add (new Planet (planet));
			}
		}
	}
}
