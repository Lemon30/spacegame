using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Planet class for acquiring and writing planet information
/// to the database. It does not work without its parent class
/// </summary>
public class Planet {

	public string name;
	public List<int> coordinates = new List<int>();
	public List<Satellite> satellites = new List<Satellite> ();
	public string owner;
	public List<Tile> tiles = new List<Tile>();

	/// <summary>
	/// Initializes a new instance of the <see cref="Planet"/> class.
	/// It initializes <see cref="Planet"/> class by parsing JTokens
	/// into strings and ints.
	/// </summary>
	/// <param name="planet_info">Gets planet information as JToken object.</param>
	public Planet (JToken planet_info) { 
		if (planet_info ["planet_name"] != null) {
			name = planet_info ["planet_name"].Value<string>();
		}

		//Coordinates of a planet
		if (planet_info ["planet_coordinates"] != null) {
			coordinates.Add(planet_info["planet_coordinates"]["planet_x"].Value<int>());
			coordinates.Add(planet_info["planet_coordinates"]["planet_y"].Value<int>());
			coordinates.Add(planet_info["planet_coordinates"]["planet_z"].Value<int>());
		}
			
		//Satellites
		if (planet_info ["planet_satellites"] != null) {
			var sat_list = planet_info ["planet_satellites"].Value<JArray> ();
			foreach (var satellite in sat_list) {
				satellites.Add (new Satellite (satellite));
			}
		}

		//Planet owner
		if (planet_info ["planet_owner"] != null) {
			owner = planet_info ["planet_owner"].Value<string> ();
		} else {
			owner = "NOT CLAIMED";
		}

		//Planet tiles
		if (planet_info["planet_tiles"] != null){
			var tile_list = planet_info["planet_tiles"].Value<JArray>();
			if (tile_list != null) {
				foreach (var tile in tile_list) {
					tiles.Add(new Tile(tile));
				}
			}
		}
	}
}
