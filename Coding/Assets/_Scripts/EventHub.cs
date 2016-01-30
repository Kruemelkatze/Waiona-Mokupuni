using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour {

	#region Event delegates
	public delegate void VoidEvent();
	public delegate void IntegerParamEvent (int value);
    public delegate void GameObjectParamEvent(GameObject obj);
    public delegate void GameObjectIntegerParamEvent(GameObject enemy, int value);
	#endregion


	#region
	public event VoidEvent LevelStart;
	public event VoidEvent GameEnd;

	// Parameter is the new life points
	public event IntegerParamEvent LifeChanged;
    public event IntegerParamEvent LifeChangedUpdater;

    //Parameter is the Hit Strength (0) is Miss
    public event IntegerParamEvent PlayerHit;

    //Parameters are the Hit Enemy and the Lost Hit points (0) is miss
    public event GameObjectIntegerParamEvent EnemyHit;

    //Parameter is the Alerted Enemy 
    public event GameObjectParamEvent EnemyAlerted;

    //Parameter is the enemy that starts the fight
    public event GameObjectParamEvent EnemyStartFight;

    //Player looses Fight
        public event VoidEvent FightLoose;
    //player wins Fight, parameter is the enemy to win against
        public event GameObjectParamEvent FightWin;

    //parameter is the gameobject element to run over
    public event GameObjectParamEvent RunOverElement;

    //parameter is the altar gameobject to get near
    public event GameObjectParamEvent SaveInAltar;

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

	public void TriggerLifePowerBarUpdater(int newLifePower){
        if (LifeChangedUpdater != null)
        {
            LifeChangedUpdater(newLifePower);
		}
	}

    public void TriggerLifePowerChanged(int newLifePower)
    {
        if (LifeChanged != null)
        {
            LifeChanged(newLifePower);
        }
    }

    public void TriggerPlayerHit(int HitStrength)
    {
        if (PlayerHit != null)
        {
            PlayerHit(HitStrength);
        }
    }

    public void TriggerEnemyHit(GameObject enemy, int HitStrength)
    {
        if (EnemyHit != null)
        {
            EnemyHit(enemy, HitStrength);
        }
    }

    public void TriggerRunOverElement(GameObject element)
    {
        if (RunOverElement != null)
        {
            RunOverElement(element);
        }
    }

    public void TriggerSaveInAltar(GameObject altar)
    {
        {
            if (SaveInAltar != null)
            {
                SaveInAltar(altar);
            }
        }
    }

    public void TriggerFightLoose()
    {
		if (FightLoose != null)
        {
			FightLoose();
        }
    }

    public void TriggerFightWin(GameObject enemy)
    {
        if (FightWin != null)
        {
            FightWin(enemy);
        }
    }

	public void TriggerEnemyStartFight(GameObject enemy) {
		if (EnemyStartFight != null) {
			EnemyStartFight (enemy);
		}
	}
	#endregion
#endregion

}
