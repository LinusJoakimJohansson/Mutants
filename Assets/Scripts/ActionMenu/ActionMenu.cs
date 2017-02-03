using UnityEngine;
using System.Collections.Generic;

namespace Battle
{

	public class ActionMenu : MonoBehaviour
	{

		BaseCharacter currentCharacter;
		public void Open(BaseCharacter character)
		{
			BattleSystem.Instance.BattleFrozen = true;
			currentCharacter = character;
			gameObject.SetActive(true);
		}

		public void SelectAction(int part)
		{
			switch ((BodyParts)part)
			{
				case BodyParts.HEAD:
					currentCharacter.selectedBodyPart = currentCharacter.Body.Head;
					break;
				case BodyParts.RIGHT:
					currentCharacter.selectedBodyPart = currentCharacter.Body.RightArm;
					break;
				case BodyParts.LEGS:
					currentCharacter.selectedBodyPart = currentCharacter.Body.Legs;
					break;
				case BodyParts.LEFT:
					currentCharacter.selectedBodyPart = currentCharacter.Body.LeftArm;
					break;
				default:
					break;
			}
			gameObject.SetActive(false);
			BattleSystem.Instance.BattleFrozen = false;
		}
	}
}
