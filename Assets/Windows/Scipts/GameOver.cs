using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : GenericWindow{

    public Text ScoreValue;
    private float Delay = 0;
    private float ScoreDelay = 0.7f;
    private bool Showed = false;

    public void ClearScore()
    {
        ScoreValue.text = "";
    }

    public override void Open()
    {
        ClearScore();
        base.Open();
    }

    public override void Close()
    {
        base.Close();
        Delay = 0;
        Showed = false;
    }

    public void ShowScore(Text Value)
    {
        Value.text = Random.Range(0, 1000000).ToString("D6");
        Showed = true;
    }

    public void MainMenu()
    {
        Manager.Open(1);
    }
    
    void Update()
    {
        Delay += Time.deltaTime;
        if (Delay > ScoreDelay && !Showed) ShowScore(ScoreValue);
    }
}
