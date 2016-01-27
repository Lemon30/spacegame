using UnityEngine;
using System.Collections;

public class TileMenuScript : MonoBehaviour {

	public void openMenu( string menuTag ){
		Debug.Log ("TitaAnyway" + menuTag);
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag)
				Debug.Log ("TitaOpenMenu" + menuTag);
			//panel.gameObject.SetActive (true);
		}
	}
}
