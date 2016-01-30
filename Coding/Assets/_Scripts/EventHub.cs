using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour {

	#region Event delegates
	public delegate void VoidEvent();
	public delegate void IntegerParamEvent (int value);
	#endregion


	#region
	public event VoidEvent LevelStart;
	public event VoidEvent GameEnd;

	#region Triggers
	public void TriggerLevelStart(){
		if (LevelStart != null) {
			LevelStart ();
		}
	}

	public void TriggerLevelEnd(){
		if (GameEnd != null) {
			GameEnd ();
		}
	}


	#endregion
#endregion



}
