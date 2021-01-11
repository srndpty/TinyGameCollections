using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;

namespace TinyGameCollections
{
	/// <summary>
	/// PongFieldのPresenterクラス
	/// </summary>
	[RequireComponent(typeof(PongFieldView))]
	[DisallowMultipleComponent]
	public class PongFieldPresenter : GenericPresenterBase<PongFieldView, PongFieldModel>
	{
		[SerializeField]
		private List<PongPlayerPresenter> _players;

		[SerializeField]
		private List<PongBallPresenter> _balls;

		/// <summary>
		/// 初期化処理(ベースクラスの初期化前）
		/// </summary>
		protected override void OnBeforeInitialize()
		{
			foreach (var player in _players)
			{
				player.Initialize();
			}

			foreach (var ball in _balls)
			{
				ball.Initialize();
			}
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