using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishStuckPlayers : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private P1_MovePlayer P1MovePlayer;
    [SerializeField] private P2_MovePlayer P2MovePlayer;


    /// <summary>
    /// Appelle les méthodes dans les classes MovePlayer pour bloquer les joueurs
    /// </summary>
    public void gameIsFinish()
    {
        P1MovePlayer.isGameIsFinishAndStuckPlayer(true);
        P2MovePlayer.isGameIsFinishAndStuckPlayer(true);
    }
    
}
