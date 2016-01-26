using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Tile
{
	public string id;
	public int type;
	public Building building;

	public class Building 
	{
		public string id;
		public string name;
		public string type;
		public int level;

		public Building(JToken b_info){
			id = b_info["building_id"].Value<string>();
			name = b_info["building_name"].Value<string>();
			type = b_info["building_type"].Value<string>();
			level = b_info["building_level"].Value<int>();
		}

	}
	public Tile (JToken t_info)
	{
		id = t_info ["tile_id"].Value<string> ();
		type = t_info ["tile_type"].Value<int> ();

		//Buildings
		building = new Building (t_info["player_building"]);

	}
}
