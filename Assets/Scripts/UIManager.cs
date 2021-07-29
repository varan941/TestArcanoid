using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI greenCounterTxt, redCounterTxt;

    private void Start()
    {
        GameManager.onGreenChanged += (count) => Change(greenCounterTxt, count);
        GameManager.onRedChanged += (count) => Change(redCounterTxt, count);
    }

    void Change(TextMeshProUGUI txt, int count)
    {
        txt.text = Convert.ToString(count);
    }
}
