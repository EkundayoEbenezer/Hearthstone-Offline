using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMinionStats : SpellEffect
{
        int HPAfter;
		int damageAfter;
        int ATAfter;
	public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
          
			int HPAfter = target.Health - damageAfter;            
			int ATAfter = target.Attack;

			new SwitchCommand(target.ID, HPAfter, ATAfter).AddToQueue();
			target.Health = ATAfter;
            target.Attack = HPAfter;
		
        }
}
