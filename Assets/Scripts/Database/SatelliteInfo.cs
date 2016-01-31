using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Satellite class fo encapsulating planet's satellite information.
/// </summary>
public class SatelliteInfo
{
	public string name;
	public string type;
	public List<Facility> facilities = new List<Facility>();

	/// <summary>
	/// Facility class is inner class for Satellite. It encapsulates
	/// facility information parsed from JToken object.
	/// It is meaningless without satellite.
	/// </summary>
	public class Facility 
	{
		public string name;
		public string type;

		/// <summary>
		/// Initializes a new instance of the <see cref="SatelliteInfo+Facility"/> class.
		/// </summary>
		/// <param name="f_info">JToken object which holds facility information.</param>
		public Facility(JToken f_info){
			if (f_info["facility_name"] != null){
				name = f_info["facility_name"].Value<string>();
			}
			if (f_info["facility_type"] != null){
				type = f_info["facility_type"].Value<string>();
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SatelliteInfo"/> class.
	/// </summary>
	/// <param name="s_info">Satellite information as JToken object.</param>
	public SatelliteInfo(JToken s_info){
		if (s_info ["satellite_name"] != null) {
			name = s_info ["satellite_name"].Value<string> ();
		}
		if (s_info ["satellite_type"] != null) {
			type = s_info ["satellite_type"].Value<string> ();
		}
			
		//Facilities
		if (s_info["satellite_facilities"] != null){
			var facility_list = s_info["satellite_facilities"].Value<JArray>();
			foreach (var facility in facility_list) {
				facilities.Add (new Facility (facility));
			}
		}
	}
}
