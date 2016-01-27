using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Tile class encapsulates tile information for planets.
/// When planets will be drawn, they use this information to
/// generate tiles.
/// </summary>
public class Tile
{
	// Basic information.
	public string id;
	public int type;
	public Building building;

	/// <summary>
	/// Building inner class which will hold building information
	/// in tile object. Building can only be exists inside of a tile.
	/// </summary>
	public class Building 
	{
		public string id;
		public string name;
		public string type;
		public int level;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tile+Building"/> class.
		/// </summary>
		/// <param name="b_info">Building information in JToken object.</param>
		public Building(JToken b_info){
			if (b_info != null){
				id = b_info["building_id"].Value<string>();
				name = b_info["building_name"].Value<string>();
				type = b_info["building_type"].Value<string>();
				level = b_info["building_level"].Value<int>();
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Tile"/> class.
	/// </summary>
	/// <param name="t_info">Tile information in JToken object.</param>
	public Tile (JToken t_info)
	{
		if (t_info != null) {
			id = t_info ["tile_id"].Value<string> ();
			type = t_info ["tile_type"].Value<int> ();
		}

		//Buildings
		if (t_info["player_building"] != null){
			building = new Building (t_info["player_building"]);
		}
	}
}
