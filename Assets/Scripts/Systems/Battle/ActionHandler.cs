using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{

	public class ActionHandler : MonoBehaviour
	{
		public BaseCharacter CurrentCharacter;

		public void HandleAction(BaseCharacter character)
		{
			BattleSystem.Instance.BattleFrozen = true;
			CurrentCharacter = character;
			CurrentCharacter.UseAction();
			BattleSystem.Instance.BattleFrozen = false;
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
