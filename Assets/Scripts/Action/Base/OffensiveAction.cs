using UnityEngine;
using System.Collections;
using Battle;

public class OffensiveAction : Action
{
	public OffensiveAction ()
	{
		Type = ActionType.Attack;

	}

	public override void Use(BaseCharacter user)
	{
		BaseCharacter target = BattleSystem.Instance.EnemyTeam[0];
		int part = (int)Random.Range(0, 4);
		switch (part)
		{
			case 1:
				target.Body.Head.HP -= this.Power;
				break;
			case 2:
				target.Body.LeftArm.HP -= this.Power;
				break;
			case 3:
				target.Body.RightArm.HP -= this.Power;
				break;
			case 4:
			default:
				target.Body.Legs.HP -= this.Power;
				break;
		}
	}
}
