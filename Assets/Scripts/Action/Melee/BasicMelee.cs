using UnityEngine;
using System.Collections;

public class BasicMelee : OffensiveAction {

	public BasicMelee ()
	{
		Charge = 10;
		Recharge = 15;
		Accuracy = 75;
		Power = 20;
	}

	public override void Use(BaseCharacter user)
	{
		base.Use(user);
	}
}
