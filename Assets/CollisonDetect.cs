using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetect : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    // 1 = right side; 2 = left side
    [SerializeField] private int direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.BlockPath(direction);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.UnBlockPath(direction);
    }
}
