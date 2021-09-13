using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ApplyColors : MonoBehaviour
{
    [SerializeField] private Material playerRedClothes;
    [SerializeField] private Material playerBlueClothes;
    [SerializeField] private Material playerGreenClothes;
    [SerializeField] private Material playerPinkClothes;
    [SerializeField] private Material playerOrangeClothes;
    [SerializeField] private Material playerYellowClothes;
    [SerializeField] private Material playerBlackClothes;
    [SerializeField] private Material playerWhiteClothes;
    [SerializeField] private Material playerMagentaClothes;
    [SerializeField] private Material playerBrownClothes;
    [SerializeField] private Material playerCyanClothes;
    [SerializeField] private Material playerLimeClothes;
    public void ApplyPlayerColor(GameObject hat1, int color1, GameObject hat2, int color2)
    {
        Material player1Clothes = color1 switch
        {
            1 => playerRedClothes,
            2 => playerBlueClothes,
            3 => playerGreenClothes,
            4 => playerPinkClothes,
            5 => playerOrangeClothes,
            6 => playerYellowClothes,
            7 => playerBlackClothes,
            8 => playerWhiteClothes,
            9 => playerMagentaClothes,
            10 => playerBrownClothes,
            11 => playerCyanClothes,
            12 => playerLimeClothes,
            _ => playerRedClothes
        };
        hat1.GetComponent<Renderer>().material = player1Clothes;
        Material player2Clothes = color2 switch
        {
            1 => playerRedClothes,
            2 => playerBlueClothes,
            3 => playerGreenClothes,
            4 => playerPinkClothes,
            5 => playerOrangeClothes,
            6 => playerYellowClothes,
            7 => playerBlackClothes,
            8 => playerWhiteClothes,
            9 => playerMagentaClothes,
            10 => playerBrownClothes,
            11 => playerCyanClothes,
            12 => playerLimeClothes,
            _ => playerRedClothes
        };
        hat2.GetComponent<Renderer>().material = player2Clothes;
    }
}