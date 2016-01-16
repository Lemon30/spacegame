using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Star : MonoBehaviour {
	private Vector2 origPos;
	public string starName;

	// Use this for initialization
	void Start () {
		origPos = transform.position;
	}

}
