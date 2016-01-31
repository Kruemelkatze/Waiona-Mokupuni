using UnityEngine;
using System.Collections;

public class FightControl : MonoBehaviour
{

    public AudioClip Chord1;
    public AudioClip Chord2;
    public AudioClip Chord3;
    public AudioClip Chord4;
    public AudioClip ChordFail;

    public FightState currentState;
    private string[] accordKeys = { "Fire1", "Fire2", "Fire3", "Jump" };
    public string nextKey;
    private bool lastKeyCorrect;
    private FightState stateAfterChord;
    public enum FightState
    {
        Idle,
        WaitForPlayerInput,
        WrongButtonPlayed,
        Fight,
        Delay,
        ChordPlayingInIdle,
        ChordPlayingInFight,
    }

    // Use this for initialization
    void Start()
    {
        currentState = FightState.Idle;
    }

    // Update is called once per frame 	
    void Update()
    {
        switch (currentState)
        {
            case FightState.Delay:
                break;
            case FightState.WrongButtonPlayed:
                currentState = FightState.Delay;
                Invoke("resetToFight", 3f);
                break;
            case FightState.ChordPlayingInIdle:
                currentState = FightState.Delay;
                Invoke("resetToIdle", 1f);
                break;
            case FightState.ChordPlayingInFight:
                currentState = FightState.Delay;
                if (lastKeyCorrect)
                {
                    Grid.EventHub.TriggerEnemyHit(this.gameObject, 1);
                    Invoke("resetToFight", 1f);
                }
                else
                {
                    Invoke("resetToWrongButtonPlayed", 1f);
                }
                break;
            case FightState.Idle:
                DoWhileIdle();
                break;

            case FightState.Fight:
                nextKey = GenerateNextAccord();
                currentState = FightState.WaitForPlayerInput;
                break;
            case FightState.WaitForPlayerInput:
                checkPlayerInput();
                break;


        }

    }

    private void DoWhileIdle()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            PlayChord1();
            currentState = FightState.ChordPlayingInIdle;

        }
        if (Input.GetButtonDown("Fire2"))
        {
            PlayChord2();
            currentState = FightState.ChordPlayingInIdle;

        }
        if (Input.GetButtonDown("Fire3"))
        {
            PlayChord3();
            currentState = FightState.ChordPlayingInIdle;

        }
        if (Input.GetButtonDown("Jump"))
        {
            PlayChord4();
            currentState = FightState.ChordPlayingInIdle;

        }
    }

    private void checkPlayerInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           checkButton1();
           if (lastKeyCorrect)
           {
               PlayChord1();
           }
           else
           {
               PlayChordFail();
           }
            currentState = FightState.ChordPlayingInFight;
        }

            if (Input.GetButtonDown("Fire2"))
            {
                checkButton2();
                 if (lastKeyCorrect)
           {
               PlayChord2();
           }
                 else
                
           {
               PlayChordFail();
           }
                currentState = FightState.ChordPlayingInFight;

            }

                if (Input.GetButtonDown("Fire3"))
                {
                   
                    checkButton3();
                    if (lastKeyCorrect)
                    {
                        PlayChord3();
                    }
                    else
                    {
                        PlayChordFail();
                    }
                    currentState = FightState.ChordPlayingInFight;

                }

                    if (Input.GetButtonDown("Jump"))
                    {
                        checkButton4();
                        if (lastKeyCorrect)
                        {
                            PlayChord4();
                        }
                        else
                        {
                            PlayChordFail();
                        }
                        currentState = FightState.ChordPlayingInFight;

                    }

    }
    private void resetToFight()
    {
        currentState = FightState.Fight;
    }
    private void resetToWrongButtonPlayed()
    {
        currentState = FightState.WrongButtonPlayed;
    }
    private void resetToIdle()
    {
        currentState = FightState.Idle;
    }
    private void checkButton1()
    {
        if (lastKeyCorrect = nextKey.Equals(accordKeys[0]))
        {
            nextKey = GenerateNextAccord();
        }
        else
        {
            currentState = FightState.WrongButtonPlayed;
            nextKey = "";
        }

    }
    private void checkButton2()
    {
        if (lastKeyCorrect = nextKey.Equals(accordKeys[1]))
        {
            nextKey = GenerateNextAccord();
        }
        else
        {
            currentState = FightState.WrongButtonPlayed;
            nextKey = "";
        }

    }
    private void checkButton3()
    {
        if (lastKeyCorrect = nextKey.Equals(accordKeys[2]))
        {
            nextKey = GenerateNextAccord();
        }
        else
        {
            currentState = FightState.WrongButtonPlayed;
            nextKey = "";
        }

    }
    private void checkButton4()
    {
        if (lastKeyCorrect = nextKey.Equals(accordKeys[3]))
        {
            nextKey = GenerateNextAccord();
        }
        else
        {
            currentState = FightState.WrongButtonPlayed;
            nextKey = "";
        }

    }

    private void PlayChord1()
    {
        Grid.SoundManager.PlaySingle(Chord1);
    }
    private void PlayChord2()
    {
        Grid.SoundManager.PlaySingle(Chord2);
    }
    private void PlayChord3()
    {
        Grid.SoundManager.PlaySingle(Chord3);
    }
    private void PlayChord4()
    {
        Grid.SoundManager.PlaySingle(Chord4);
    }

    private void PlayChordFail()
    {
        Grid.SoundManager.PlaySingle(ChordFail);
    }
    private string GenerateNextAccord()
    {
        return accordKeys[Random.Range(0, 3)];
    }

}
