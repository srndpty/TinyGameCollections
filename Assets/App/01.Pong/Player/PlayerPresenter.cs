using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TinyGameCollections
{
	/// <summary>
	/// PlayerのPresenterクラス
	/// </summary>
	[RequireComponent(typeof(PlayerView))]
	[DisallowMultipleComponent]
	public class PlayerPresenter : GenericPresenterBase<PlayerView, PlayerModel>
	{
		/// <summary>
		/// 初期化処理(ベースクラスの初期化前）
		/// </summary>
		protected override void OnBeforeInitialize()
		{
		}
		
		/// <summary>
		/// 初期化処理(ベースクラスの初期化終了後）
		/// </summary>
		protected override void OnAfterInitialize()
		{
		}

		/// <summary>
		/// Modelの値を監視する
		/// </summary>
		protected override void Bind()
		{
		}

		/// <summary>
		/// 外部イベントを監視する
		/// </summary>
		protected override void ExternalEventBind()
		{
		}

		/// <summary>
		/// Viewのイベントの設定を行う
		/// </summary>
		protected override void SetEvent()
		{
		}
	}
}