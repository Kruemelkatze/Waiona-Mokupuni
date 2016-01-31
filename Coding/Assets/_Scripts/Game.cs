using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public int MaxLife = 5;
    public int CurrentLife;
	public bool PlayerCarryingEarth = false;
	public bool PlayerCarryingWater = false;
	public bool PlayerCarryingFire = false;
	public bool PlayerCarryingAir = false;
	public bool PlayerCarryingEnergy = false;

	public bool AltarElementPresentEarth = false;
	public bool AltarElementPresentWater = false;
	public bool AltarElementPresentFire= false;
	public bool AltarElementPresentAir = false;
	public bool AltarElementPresentEnergy = false;

	public AudioClip WinClip;
	public AudioClip WinMusic;


	void Start() {
		CurrentLife = MaxLife;
		Grid.EventHub.RunOverElement += HandleElementPickup;
		Grid.EventHub.LifeChanged += ChangeCurrentLife;
		Grid.EventHub.SaveInAltar += HandleSaveInAltar;
		Grid.EventHub.FightLoose += HandleFightLoose;
		Grid.EventHub.GameEnd += HandleGameEnd;
		Grid.EventHub.EnemyAttack += HandleEnemyAttack;
		Grid.WinUI.SetActive (false);
	}

    private void ChangeCurrentLife(int deltaLife)
    {
        CurrentLife += deltaLife;
		Grid.EventHub.TriggerLifePowerBarUpdater(CurrentLife);

		if (CurrentLife <= 0) {
			Grid.EventHub.TriggerFightLoose ();
		}
    }

	private void HandleElementPickup(GameObject element) {
		if (element.name == "Erde") {
			PlayerCarryingEarth = true;
		}
		if (element.name == "Wasser") {
			PlayerCarryingWater = true;
		}
		if (element.name == "Feuer") {
			PlayerCarryingFire = true;
		}
		if (element.name == "Luft") {
			PlayerCarryingAir = true;
		}
		if (element.name == "Energie") {
			PlayerCarryingEnergy = true;
		}
	}

	void OnDestroy() {
		Grid.EventHub.RunOverElement -= HandleElementPickup;
		Grid.EventHub.LifeChanged -= ChangeCurrentLife;
		Grid.EventHub.SaveInAltar -= HandleSaveInAltar;
		Grid.EventHub.FightLoose -= HandleFightLoose;
		Grid.EventHub.GameEnd -= HandleGameEnd;
		Grid.EventHub.EnemyAttack -= HandleEnemyAttack;
	}

	private void HandleEnemyAttack() {
		if (IsInvoking ("ResetFight")) {
			CancelInvoke ("ResetFight");
		}
		Invoke ("ResetFight", 5);

	}

	private void ResetFight() {
		Grid.EventHub.TriggerFightWin(null);
	}

	private void HandleSaveInAltar(GameObject element) {
		if (element.name == "Erde") {
			AltarElementPresentEarth = true;
			PlayerCarryingEarth = false;
		}
		if (element.name == "Wasser") {
			AltarElementPresentWater = true;
			PlayerCarryingWater = false;
		}
		if (element.name == "Feuer") {
			AltarElementPresentFire = true;
			PlayerCarryingFire = false;
		}
		if (element.name == "Luft") {
			AltarElementPresentAir = true;
			PlayerCarryingAir = false;
		}
		if (element.name == "Energie") {
			AltarElementPresentEnergy = true;
			PlayerCarryingEnergy = false;
		}

		if (AltarElementPresentEarth && AltarElementPresentWater && AltarElementPresentFire && AltarElementPresentAir && AltarElementPresentEnergy) {
			Debug.Log ("YAY, YOU WON");
			Grid.EventHub.TriggerLevelEnd ();
		}
	}

	private void HandleGameEnd() {
		Invoke ("ShowWinScreen", 3);
	}

	private void ShowWinScreen() {
		if (Grid.WinUI != null) {
			Grid.WinUI.SetActive (true);
		}
		Grid.SoundManager.SetCurrentTheme(WinMusic, 1f);

		Grid.SoundManager.PlaySingle (WinClip, 1f);
	}


	private void HandleFightLoose() {
		Invoke("Respawn", 1f);
	}

	private void Respawn() {

		Grid.Player.transform.position = Grid.SpawnPoint.transform.position;
		Grid.Player.transform.rotation = Grid.SpawnPoint.transform.rotation;

		Invoke ("AfterRespawn", 1.1f);
	}

	private void AfterRespawn() {
		CurrentLife = MaxLife;
		Grid.EventHub.TriggerLifePowerBarUpdater (CurrentLife);
	}

}
