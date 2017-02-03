using UnityEngine;
using System.Collections;

public class HumanArm : Arm {

	public HumanArm()
	{
		HP = 25;
		Level = 1;
		Action = new BasicMelee();
	}
}
