using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TinyGameCollections
{
	/// <summary>
	/// PongBallのPresenterクラス
	/// </summary>
	[RequireComponent(typeof(PongBallView))]
	[DisallowMultipleComponent]
	public class PongBallPresenter : GenericPresenterBase<PongBallView, PongBallModel>
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