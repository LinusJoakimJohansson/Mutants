using UnityEngine;
using System.Collections;

public class HumanHead : Head {

	public HumanHead()
	{
		HP = 25;
		Level = 1;
		Action = new BasicMelee();
	}
}
