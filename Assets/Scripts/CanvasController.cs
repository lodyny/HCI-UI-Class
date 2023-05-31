using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.WSA;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _pNameText;

    [SerializeField] private GameObject _goUIMoney;
    [SerializeField] private GameObject _goldParent;
    
    void Awake()
    {
        GameManager.Instance.save.goldChangedEvent +=
            GoldUpdated;
    }

    void OnDestroy()
    {
        GameManager.Instance.save.goldChangedEvent -=
            GoldUpdated;
    }

    private void GoldUpdated(int gold, int incGold)
    {
        _goldText.text = GameManager.Instance.save.Gold.ToString();
        GameObject o = Instantiate(_goUIMoney);
        o.GetComponentInChildren<TextMeshProUGUI>().text = incGold.ToString();
        o.transform.SetParent(_goldParent.transform);
        Destroy(o, 1f);
    }

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        _energyText.text = GameManager.Instance.save.Energy.ToString();
        _pNameText.text = GameManager.Instance.save.PlayerName;
    }
}