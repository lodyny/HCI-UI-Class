using System;

[System.Serializable]
public class SaveData
{
    public int Gold;
    public float Energy;

    public Action<int, int> goldChangedEvent;
    
    //Alternativa à Action a cima
    // public UnityEvent testeEvent;

    public string PlayerName { get; private set; }

    public SaveData(string playerName)
    {
        Gold = 1000;
        Energy = 100f;
        this.PlayerName = playerName;
    }

    public void AddGold(int value)
    {
        Gold += value;
        goldChangedEvent?.Invoke(Gold, value);
    }

    public void LoadData()
    {
        // ler da BD
    }

    public void SaveGame()
    {
        // Grava na BD
    }
}