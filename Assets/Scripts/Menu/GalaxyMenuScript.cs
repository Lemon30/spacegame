using UnityEngine;
using System.Collections;

public class GalaxyMenuScript : MonoBehaviour {

	/// <summary>
	/// Change to another scene.
	/// </summary>
	/// <param name="sceneName">Name of the scene.</param>
	public void changeScene( string sceneName ){
		Application.LoadLevel ( sceneName ); // Says that LoadLevel is obsolete, change later
	}

	public void backToGalaxy(){
		Camera.main.transform.position = new Vector3 (0, 0, -10);
		GameObject backButton = GameObject.FindGameObjectWithTag ("BackButton");
		backButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -30);
		Collider[] hitColliders = Physics.OverlapSphere (new Vector3 (-500, 0, 0), 100.0f);
		int i = 0;
		while (i < hitColliders.Length) {
			Destroy (hitColliders [i].transform.gameObject);
			i++;
		}
	}

}
