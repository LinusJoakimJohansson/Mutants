using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Battle {

	public class ActionBar : MonoBehaviour
	{
		public Transform ChargeBar;
		public Transform RechargeBar;
		public Image ChargeIcon;
		public Image RechargeIcon;
		public GameObject PortraitPrefab;

		private Vector2 _chargeStartPosition;
		private Vector2 _rechargeStartPosition;
		private List<Portrait> _portraits = new List<Portrait>();
		private Portrait _activePortrait;

		public void Setup(ref List<BaseCharacter> playerCharacters, 
			ref List<BaseCharacter> EnemyCharacters)
		{
			_chargeStartPosition = new Vector2(0, 0);
			_rechargeStartPosition = new Vector2(0,0);

			foreach (BaseCharacter c in playerCharacters)
			{
				GameObject obj = Instantiate(PortraitPrefab,this.transform, false);
				Portrait temp = obj.GetComponent<Portrait>();
				temp.Setup(c);
				//temp.transform.SetParent(this.transform);
				temp.transform.position = _chargeStartPosition;
				_portraits.Add(temp);
			}

			foreach (BaseCharacter c in EnemyCharacters)
			{
				GameObject obj = Instantiate(PortraitPrefab, this.transform, false);
				Portrait temp = obj.GetComponent<Portrait>();
				temp.Setup(c);
				//temp.transform.SetParent(this.transform);
				temp.transform.position = _chargeStartPosition;
				_portraits.Add(temp);
			}
		}

		public void Run()
		{
		}

		public void Pause(Portrait portrait)
		{
			_activePortrait = portrait;
			if (_activePortrait.IsChargeing)
			{
				_activePortrait.transform.position = ChargeIcon.transform.position;
			}
			else
			{
				_activePortrait.transform.position = RechargeIcon.transform.position;
			}

		}

		public void Continue()
		{
			if(_activePortrait.IsChargeing)
			{
				_activePortrait.transform.position = _rechargeStartPosition;
			}
			else
			{
				_activePortrait.transform.position = _chargeStartPosition;
			}
			_activePortrait.UpdateSpeed();
			_activePortrait.Charge = 0f;
			_activePortrait.IsChargeing = !_activePortrait.IsChargeing;
		}

		// Update is called once per frame
		void Update()
		{
			if (BattleSystem.Instance.BattleFrozen)
				return;

			if (_portraits.Any(p => p.Charge >= 100))
			{
				Portrait first = _portraits.OrderByDescending(p => p.Charge).FirstOrDefault();
				Pause(first);
				BattleSystem.Instance.ActivateCharacter(first);
				return;
			}

			foreach (Portrait p in _portraits)
			{
				MovePortrait(p);
			}			
		}

		private void MovePortrait (Portrait portrait)
		{
			portrait.Charge += portrait.Speed * Time.deltaTime;
			//if (portrait.IsChargeing)
			//{
			//	portrait.transform.Translate(ChargeBar.rect.xMin + 
			//		(ChargeBar.rect.width * (portrait.Charge / 100))
			//		, portrait.transform.position.y, 0);
			//}
			//else
			//{
			//	portrait.transform.Translate(RechargeBar.rect.xMax -
			//		(RechargeBar.rect.width * (portrait.Charge / 100))
			//		, portrait.transform.position.y, 0);
			//}
			
		}
	}
}