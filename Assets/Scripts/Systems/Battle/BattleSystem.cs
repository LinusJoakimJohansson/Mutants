using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
	public class BattleSystem : MonoBehaviour
	{
		#region BattleFrozen
		private bool _battleFrozen = false;
		public bool BattleFrozen
		{
			get { return _battleFrozen; }
			set
			{
				_battleFrozen = value;
				if (!_battleFrozen)
				{
					_actionBar.Continue();
				}
			}
		}
		#endregion

		#region Fields
		public List<BaseCharacter> PlayerTeam = new List<BaseCharacter>();
		public List<BaseCharacter> EnemyTeam = new List<BaseCharacter>();

		public Canvas UICanvas;
		//public GameObject ActionMenuPrefab;
		//public GameObject ActionBarPrefab;

		//private GameObject      _actionMenuObject;
		public ActionMenu      _actionMenu;
		//private GameObject      _actionBarObject;
		public ActionBar       _actionBar;
		private ActionHandler   _actionHandler;
		#endregion

		#region Instance
		private static BattleSystem _instance;
		public static BattleSystem Instance
		{
			get
			{
				if (_instance == null)
				{
					BattleSystem bs = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
					if (bs == null)
						return null;
					else
						_instance = bs;
				}
				return _instance;
			}
			set { _instance = value; }
		}
		#endregion

		#region Initalize
		public void Initalize()
		{
			//Load Characters
			//Start Triggering ActionMenu
		}
		#endregion

		#region Awake
		public void Awake()
		{
			//Take the saved characters 

			//Take the most recent generated Enemies
			//_actionMenuObject = Instantiate(ActionMenuPrefab);
			//_actionMenu = _actionMenuObject.GetComponent<ActionMenu>();
			//_actionMenuObject.SetActive(false);
			//_actionBarObject = Instantiate(ActionBarPrefab);
			//_actionBar = _actionBarObject.GetComponent<ActionBar>();
			_actionBar.Setup(ref PlayerTeam, ref EnemyTeam);
			_actionHandler = GetComponent<ActionHandler>();

		}
		#endregion

		#region ActivateCharacter
		public void ActivateCharacter(Portrait portrait)
		{
			if (portrait.IsChargeing)
			{
				_actionHandler.HandleAction(portrait.Character);
			} else
			{
				_actionMenu.Open(portrait.Character);
			}
		}
		#endregion

		#region InstantiateMenu
		private void InstantiateMenu(BaseCharacter character)
		{
			//_actionMenuObject = Instantiate(ActionMenuPrefab);
			//_actionMenu = _actionMenuObject.GetComponent<ActionMenu>();
			_actionMenu.Open(character);
		}
		#endregion

	}
}
