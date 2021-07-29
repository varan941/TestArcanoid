using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static Action<int> onGreenChanged, onRedChanged;
   
    [SerializeField] private int greenCounter, redCounter;

    private bool _isGameStarted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted)
        {
            _isGameStarted = true;
            Ball.I.AddForce(UnityEngine.Random.Range(-200f, 200f), false);
        }
    }

    public int GreenCounter
    {
        get => greenCounter;
        set
        {
            greenCounter = value;
            onGreenChanged?.Invoke(greenCounter);
        }
    }

    public int RedCounter
    {
        get => redCounter;
        set
        {
            redCounter = value;
            onRedChanged?.Invoke(redCounter);
        }
    }
}
