using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Satellite
{
	public string name;
	public string type;
	public List<Facility> facilities = new List<Facility>();

	public class Facility 
	{
		public string name;
		public string type;

		public Facility(JToken f_info){
			name = f_info["facility_name"].Value<string>();
			type = f_info["facility_type"].Value<string>();
		}
	}

	public Satellite(JToken s_info){
		name = s_info ["satellite_name"].Value<string> ();
		type = s_info ["satellite_type"].Value<string> ();

		//Facilities
		//Debug.Log(s_info["satellite_facilities"].Value<string>());
		if (s_info["satellite_facilities"] != null){
			var facility_list = s_info["satellite_facilities"].Value<JArray>();
			foreach (var facility in facility_list) {
				facilities.Add (new Facility (facility));
			}
		}
	}
}
