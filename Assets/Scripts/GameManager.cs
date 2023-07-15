using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI coinsText;
    public int coins;
    public int points;
    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coins = 0;
        points = 0;
    }

    private void Update()
    {
        pointsText.text = $"Points: {points}";
        coinsText.text = $"Coins: {coins}";
    }
}
