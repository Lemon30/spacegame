using System;
using System.Collections;
using System.Collections.Generic;

using Divan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Resource class for encapsulating resource
/// attributes. This class needs star class and it
/// should be called from <see cref="Star"/> class.
/// </summary>
public class Resource {
	public string resourceName;
	public int resourceTotal = 0;

	/// <summary>
	/// Initializes a new instance of the <see cref="Resource"/> class.
	/// </summary>
	/// <param name="res_info">JToken that carries resource info.</param>
	/// <param name="res_name">Name of the resource. It is important to match with db name.</param>
	public Resource(JToken res_info, string res_name){
		if (res_info [res_name] != null) {
			resourceTotal += res_info [res_name].Value<int> ();
			resourceName = res_name;
		}
	}
}
