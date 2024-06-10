﻿using UnityEngine;
using System.Collections;

public class PlayerTurnMaker : TurnMaker 
{
    public override void OnTurnStart()
    {
        base.OnTurnStart();
        // dispay a message that it is player`s turn
        new ShowMessageCommand("YOUR TURN!", 2.0f).AddToQueue();
        p.DrawACard();
    }
}
