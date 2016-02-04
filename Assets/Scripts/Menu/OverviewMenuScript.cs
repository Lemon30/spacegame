using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverviewMenuScript : MonoBehaviour {

	public Text resourcesText;
	public Text planetTitleText;


	/// <summary>
	/// Change to another scene.
	/// </summary>
	/// <param name="sceneName">Name of the scene.</param>
	public void changeScene( string sceneName ){
		Application.LoadLevel ( sceneName ); // Says that LoadLevel is obsolete, change later
	}

	/// <summary>
	/// Bring the menu into the game view.
	/// </summary>
	/// <param name="menuTag">Tag of the panel(menu).</param>
	public void openMenu( string menuTag ){
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag)
				Debug.Log ("TitaOpenMenu" + menuTag);
				panel.position = new Vector3 (0, 0, 0);
		}
	}

	// Use this for initialization
	void Awake () {
		Transform trans = this.GetComponentInParent<Canvas> ().transform;
		Debug.Log (trans.name);
		int amountOfChildren = trans.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform childTrans = trans.GetChild (i);
			if (childTrans.gameObject.tag == "ResourcesText")
				resourcesText = childTrans.gameObject.GetComponent<Text> ();
			else if (childTrans.gameObject.tag == "PlanetTitleText")
				planetTitleText = childTrans.gameObject.GetComponent<Text> ();
		}
		planetTitleText.text = GameMaster.gameMaster.myPlanet.planetInfo.name;
	}

	// Update is called once per frame
	void Update () {
		resourcesText.text = GameMaster.gameMaster.titaniumVal + " :T" + "\n" +
			GameMaster.gameMaster.mineralVal + ":M" + "\n" +
			GameMaster.gameMaster.luminiteVal + " :L";
	}
}
