using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CarryItemsManager : MonoBehaviour {

	public Image Erde;
	public Image Wasser;
	public Image Feuer;
	public Image Luft;
	public Image Energie;

	public Color DisabledColor;

	// Use this for initialization
	void Start () {
		Grid.EventHub.RunOverElement += ElementPickedUpHandler;
		Grid.EventHub.SaveInAltar += AltarReachHandler;
		Erde.color = DisabledColor;
		Wasser.color = DisabledColor;
		Feuer.color = DisabledColor;
		Luft.color = DisabledColor;
		Energie.color = DisabledColor;

	}

	private void ElementPickedUpHandler(GameObject element) {
		if (element.name == "Erde") {
			Erde.color = Color.white;
		}
		if (element.name == "Wasser") {
			Wasser.color = Color.white;
		}
		if (element.name == "Feuer") {
			Feuer.color = Color.white;
		}
		if (element.name == "Luft") {
			Luft.color = Color.white;
		}
		if (element.name == "Energie") {
			Energie.color = Color.white;
		}
	}

	private void AltarReachHandler(GameObject altar) {

	}

	void OnDestroy() {
		Grid.EventHub.RunOverElement -= ElementPickedUpHandler;
	}



}
