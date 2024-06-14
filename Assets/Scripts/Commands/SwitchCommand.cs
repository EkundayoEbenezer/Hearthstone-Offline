using UnityEngine;
using System.Collections;

public class SwitchCommand : Command {

    private int targetID;
    private int healthAfter;
    private int attackAfter;
        public GameObject targetObject;

    public SwitchCommand( int targetID, int healthAfter, int attackAfter)
    {
        this.targetID = targetID;
        this.healthAfter = healthAfter;
        this.attackAfter = attackAfter;
    }

    public override void StartCommandExecution()
    {
		//Debug.Log("Il a "+healthAfter+" HP et "+armorAfter+" armure. Dans DealDamageCOmmand");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);
      
            // target is a creature
            target.GetComponent<OneCreatureManager>().SwitchStats(0, healthAfter,0, attackAfter);
        
        CommandExecutionComplete();
    }
}
