using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType;

   private float _timer;
    [SerializeField] private float _secondsGiveGold = 1f;
    [SerializeField] private int _goldPerSec = 1;

    [SerializeField] private TextMeshProUGUI _buildingText;
    [SerializeField] private GameObject _buildingGFX;

    [Range(1,9999)]
    public int MoneyCost;
    
    private void Awake()
    {
        _timer = 0f;
        // I can access the values from the building type (public ones).
        _buildingText.text = BuildingType.BuildingName;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _secondsGiveGold)
        {
            _timer -= _secondsGiveGold;
            GameManager.Instance.save.AddGold(_goldPerSec);
        }
    }
    
    public void AddGold()
    {
        GameManager.Instance.save
            .AddGold(100);
        LeanTween.scale(_buildingGFX,
                new Vector3(1.2f, 1.2f, 1.2f), 0.05f)
            .setLoopPingPong(1);
    }
    
    public void Upgrade()
    {
        if (GameManager.Instance.save.Gold >= MoneyCost)
        {
            // Make upgrade here.
            GameManager.Instance.save.AddGold(-MoneyCost);
            
        }
    }
}