using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Planet {

	public string name;
	public List<int> coordinates = new List<int>();
	public List<Satellite> satellites = new List<Satellite> ();
	public string owner;
	public List<Tile> tiles = new List<Tile>();

	public Planet (JToken planet_info) { 
		name = planet_info ["planet_name"].Value<string>();

		//Coordinates of a planet
		coordinates.Add(planet_info["planet_coordinates"]["planet_x"].Value<int>());
		coordinates.Add(planet_info["planet_coordinates"]["planet_y"].Value<int>());
		coordinates.Add(planet_info["planet_coordinates"]["planet_z"].Value<int>());

		//Satellites
		var sat_list = planet_info["planet_satellites"].Value<JArray>();
		foreach (var satellite in sat_list) {
			satellites.Add (new Satellite (satellite));
		}

		//Planet owner
		if (planet_info ["planet_owner"] != null) {
			owner = planet_info ["planet_owner"].Value<string> ();
		} else {
			owner = "NOT CLAIMED";
		}

		//Planet tiles
		var tile_list = planet_info["planet_tiles"].Value<JArray>();
		foreach (var tile in tile_list) {
			tiles.Add(new Tile(tile));
		}
	}
}
