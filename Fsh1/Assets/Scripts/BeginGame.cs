using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    public LoadManager manager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.LoadGame();
    }
}
