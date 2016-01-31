using UnityEngine;
using System.Collections;

/// <summary>
/// Generates Unity3D compatible versions of
/// database objects.
/// </summary>
public class Star : MonoBehaviour {

	public StarInfo spawnedObj;

	/// <summary>
	/// Initializes a new instance of the <see cref="Star"/> class.
	/// </summary>
	/// <param name="obj">Original Star object.</param>
	public Star(StarInfo obj){
		spawnedObj = obj;
	}
}
