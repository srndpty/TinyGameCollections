using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using Cysharp.Threading.Tasks;
using UniRx.Triggers;

namespace TinyGameCollections
{
	/// <summary>
	/// PongPlayerのPresenterクラス
	/// </summary>
	[RequireComponent(typeof(PongPlayerView))]
	[DisallowMultipleComponent]
	public class PongPlayerPresenter : GenericPresenterBase<PongPlayerView, PongPlayerModel>
	{
		[SerializeField]
		private Collider2D _collider;

		/// <summary>
		/// 初期化処理(ベースクラスの初期化前）
		/// </summary>
		protected override void OnBeforeInitialize()
		{
			this.UpdateAsObservable()
				.Subscribe(_ => _model.Move())
				.AddTo(this);
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
			_model.PositionY
				.Subscribe(y => _view.SetY(y))
				.AddTo(this);
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