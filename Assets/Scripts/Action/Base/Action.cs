using UnityEngine;
using System.Collections;
using Battle;

public abstract class Action {

	public ActionType Type;
	public float Charge;
	public float Recharge;
	public float Accuracy;
	public float Power;
	public BaseCharacter Target;

	public abstract void Use(BaseCharacter user);
}
