using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TinyGameCollections
{
	/// <summary>
	/// プレゼンタークラスのジェネリック用ベースクラスです
	/// </summary>
	/// <typeparam name="TView"></typeparam>
	/// <typeparam name="TModel"></typeparam>
	public abstract class GenericPresenterBase<TView, TModel> : PresenterBase, IPresenter
		where TView : MonoBehaviour, IView
		where TModel : class, IModel
	{
		/// <summary>
		/// DI Container
		/// </summary>
		[SerializeField, Inject, Disable]
		private DiContainer _diContainer = default;

		/// <summary>
		/// ビュークラス
		/// </summary>
		[SerializeField]
		protected TView _view;

		/// <summary>
		/// モデルクラス
		/// </summary>
		[SerializeField]
		protected TModel _model;

		/// <summary>
		/// 初期化前に呼ばれる
		/// </summary>
		protected abstract void OnBeforeInitialize();

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize()
		{
			OnBeforeInitialize();

			_diContainer.Inject(_model);

			_model.Initialize();
			_view.Initialize();
			Bind();
			ExternalEventBind();
			SetEvent();

			OnAfterInitialize();
		}

		/// <summary>
		/// 初期化後に呼ばれる
		/// </summary>
		protected abstract void OnAfterInitialize();

		/// <summary>
		/// Modelの値を監視する
		/// </summary>
		protected abstract void Bind();

		/// <summary>
		/// 外部クラスのイベントを監視する
		/// </summary>
		protected abstract void ExternalEventBind();


		/// <summary>
		/// Viewのイベントの設定を行う
		/// </summary>
		protected abstract void SetEvent();

		#if UNITY_EDITOR

		/// <summary>
		/// スクリプトがゲームオブジェクトにアタッチされた時に呼ばれます
		/// </summary>
		protected void OnValidate()
		{
			if (_view == null)
			{
				_view = gameObject.SafeAddComponent<TView>();
			}
		}
		#endif
	}
}