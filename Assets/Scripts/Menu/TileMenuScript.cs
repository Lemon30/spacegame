using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileMenuScript : MonoBehaviour {

	/// <summary>
	/// Bring the menu into the game view.
	/// </summary>
	/// <param name="menuTag">Tag of the panel(menu).</param>
	public void openMenu( string menuTag ){
		int amountOfChildren = this.transform.childCount;
		for (int i = 0; i < amountOfChildren; i++) {
			Transform panel = this.transform.GetChild (i);
			if (panel.gameObject.tag == menuTag) {
				panel.position = new Vector3 (0, 0, 0);
			}
		}
	}
}
