using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Battle {

	public class Portrait : MonoBehaviour
	{
		public float Speed
		{ get{
				if (IsChargeing)
					return _chargeSpeed;
				else
					return _rechargeSpeed;
			}}
		public float Charge = 100;
		public bool IsChargeing = false;
		public BaseCharacter Character;

		[SerializeField]
		Image _image;

		float _chargeSpeed;
		float _rechargeSpeed;

		public void Setup(BaseCharacter character)
		{
			Character = character;
			_image.sprite = Character.Portrait;
		}

		public void UpdateSpeed()
		{
			_chargeSpeed = Character.selectedBodyPart.Action.Charge;
			_rechargeSpeed = Character.selectedBodyPart.Action.Recharge;
		}
	}
}
