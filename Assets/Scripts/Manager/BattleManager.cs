using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase
{
    Draw, Roll, Action, End
}
public class BattleManager : Singleton<MonoBehaviour>
{
    public Hand player1Hands;
    public Hand player2Hands;
    public Block[] player1Blocks;
    public Block[] player2Blocks;
    public Block[] neutralBlocks;
    public Deck player1DeckList;
    public Deck player2DeckList;

    public GamePhase currentPhase = GamePhase.Draw;


    public void NextTurn()
    {
        switch (currentPhase)
        {
            case (GamePhase.Draw):
                currentPhase = GamePhase.Roll;
                break;
            case (GamePhase.Roll):
                currentPhase = GamePhase.Action;
                break;
            case (GamePhase.Action):
                currentPhase = GamePhase.End;
                break;
            case (GamePhase.End):
                currentPhase = GamePhase.Draw;
                break;
        }
    }
}
