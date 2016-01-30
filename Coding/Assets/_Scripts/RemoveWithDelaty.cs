using UnityEngine;
using System.Collections;

public class RemoveWithDelaty : MonoBehaviour {

	public float Delaytime;

	private float timePassed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if (timePassed <= Delaytime) {
			return;
		}
		Destroy (gameObject);
	}
}
