using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace TinyGameCollections
{
	/// <summary>
	/// プレゼンタークラスのベースクラス
	/// </summary>
	public abstract class PresenterBase : MonoBehaviour
	{
		/// <summary>
		/// PresenterをBindする用のZenject Binding
		/// </summary>
		[SerializeField, HideInInspector]
		private PresenterZenjectBinging _presenterZenjectBinging = default;

		/// <summary>
		/// View用のGameObjectContext
		/// </summary>
		[SerializeField, HideInInspector]
		protected MvpGameObjectContext _mvpGameObjectContext;

		/// <summary>
		/// ZenjectSupportの有効有無
		/// </summary>
		[SerializeField, HideInInspector]
		protected bool _enableZenjectSupport;

		#if UNITY_EDITOR

		[CustomEditor(typeof(PresenterBase), true)]
		[CanEditMultipleObjects]
		public class PresenterBaseEditor : Editor
		{
			private PresenterBase _presenterBase;

			public override void OnInspectorGUI()
			{
				//draw default
				DrawDefaultInspector();

				//target
				_presenterBase = target as PresenterBase;

				serializedObject.Update();

				//null check
				if (_presenterBase == null)
				{
					return;
				}

				//Enable Zenject Support
				var enableZenjectSupport = _presenterBase._enableZenjectSupport;

				//button text
				var buttonText = enableZenjectSupport
								 ? "Disable Zenject Support Mode"
								 : "Enable Zenject Support Mode";
				//default gui color
				var defaultGuiColor = GUI.color;

				//set color
				GUI.color = enableZenjectSupport ? Color.yellow : Color.green;

				//ボタンを表示
				if (GUILayout.Button(buttonText))
				{
					//undo registration
					Undo.RegisterFullObjectHierarchyUndo(_presenterBase.gameObject, "full object hierarchy change");

					//set enable
					_presenterBase._enableZenjectSupport = _presenterBase?._enableZenjectSupport == false;

					//ZenjectSupportモードが有効な
					if (_presenterBase._enableZenjectSupport)
					{
						AddZenjectSupportComponents();
					}
					else
					{
						RemoveZenjectSupportComponents();
					}
				}

				var existMvpGameObjectContext = _presenterBase.gameObject.GetComponent<MvpGameObjectContext>() != null;

				//set color
				GUI.color = existMvpGameObjectContext ? Color.yellow : Color.green;

				//button text
				var mvpButtonText = existMvpGameObjectContext
									? "Remove MvpGameObjectContext"
									: "Add MvpGameObjectContext";

				//ボタンを表示
				if (GUILayout.Button(mvpButtonText))
				{
					//undo registration
					Undo.RegisterFullObjectHierarchyUndo(_presenterBase.gameObject, "full object hierarchy change");

					//MvpGameObjectContextが存在する場合
					if (existMvpGameObjectContext)
					{
						_presenterBase?._mvpGameObjectContext?.gameObject
						.RemoveComponentImmediate<MvpGameObjectContext>();
					}
					else
					{
						_presenterBase._mvpGameObjectContext =
							_presenterBase.gameObject.AddComponent<MvpGameObjectContext>();
					}
				}

				//set default
				GUI.color = defaultGuiColor;

				//help
				var helpBoxText = _presenterBase._enableZenjectSupport
								  ? "※現在,ZenjectSupportModeは有効です"
								  : "※現在,ZenjectSupportModeは無効です";

				//help box
				EditorGUILayout.HelpBox(helpBoxText, MessageType.Info);

				serializedObject.ApplyModifiedProperties();
			}

			/// <summary>
			/// Zenject系コンポーネントを追加
			/// </summary>
			private void AddZenjectSupportComponents()
			{
				if (_presenterBase._presenterZenjectBinging == null)
				{
					_presenterBase._presenterZenjectBinging =
						_presenterBase.gameObject.AddComponent<PresenterZenjectBinging>();

					//プレゼンターを設定
					ZenjectRefrectionHelper.SetComponents
					(
						_presenterBase._presenterZenjectBinging, new Component[] {_presenterBase}
					);
				}
			}

			/// <summary>
			/// Zenject系コンポーネントを削除
			/// </summary>
			private void RemoveZenjectSupportComponents()
			{
				EditorApplication.delayCall += () =>
				{
					_presenterBase?._presenterZenjectBinging?.gameObject
					.RemoveComponentImmediate<PresenterZenjectBinging>();
					_presenterBase?._mvpGameObjectContext?.gameObject
					.RemoveComponentImmediate<MvpGameObjectContext>();
				};
			}
		}
		#endif
	}
}