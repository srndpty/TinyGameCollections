using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Zenject;

namespace TinyGameCollections
{
	[DisallowMultipleComponent]
	public sealed class PresenterZenjectBinging : ZenjectBinding
	{
		#if UNITY_EDITOR

		[CustomEditor(typeof(PresenterZenjectBinging))]
		[CanEditMultipleObjects]
		public class PresenterZenjectBindingEditor : Editor
		{
			private SerializedProperty _useSceneContext;
			private SerializedProperty _context;
			private SerializedProperty _bindType;

			private void OnEnable()
			{
				_useSceneContext = serializedObject.FindProperty("_useSceneContext");
				_context = serializedObject.FindProperty("_context");
				_bindType = serializedObject.FindProperty("_bindType");
			}

			public override void OnInspectorGUI()
			{
				//target
				var t = target as PresenterZenjectBinging;

				//null check
				if (t == null)
				{
					return;
				}

				serializedObject.Update();

				EditorGUILayout.Space();
				_useSceneContext.boolValue = EditorGUILayout.Toggle("Use Scene Context", t.UseSceneContext);

				//is null or scene context
				var isNullOrSceneContext = t.Context == null ||
										   t.Context.GetType() == typeof(SceneContext);

				if (_useSceneContext.boolValue == false)
				{
					//description
					var description =
						$"PresenterクラスのZenjectBindingです。\n" +
						(t.Context != null
						 ? $"{t.Context.gameObject.name}にアタッチされているGameObjectContextに{t.Components.FirstOrDefault()?.GetType().Name}がBindingされています。"
						 : "");
					//help box
					EditorGUILayout.HelpBox(description, MessageType.Info);
					//background color
					GUI.backgroundColor = isNullOrSceneContext ? Color.red : GUI.color;
					EditorGUILayout.Space();
					//Context
					_context.objectReferenceValue = (RunnableContext) EditorGUILayout.ObjectField
													(
														t.Context,
														typeof(RunnableContext),
														true
													);

					if (t.Components == null || t.Components.Length == 0)
					{
						var helpBoxText = "※PresenterがComponentsに設定されていません!";
						EditorGUILayout.HelpBox(helpBoxText, MessageType.Error);
					}
				}
				else
				{
					var helpBoxText = "※PresenterがSceneContextにBindされています";
					EditorGUILayout.HelpBox(helpBoxText, MessageType.Info);
				}

				if (isNullOrSceneContext && t.UseSceneContext == false)
				{
					var helpBoxText = "※Contextの設定を見直してください！\nPresenterのInject可能な範囲がScene全体になっています!";
					EditorGUILayout.HelpBox(helpBoxText, MessageType.Error);
				}
				else
				{
					EditorGUILayout.Space();
					//BindType
					_bindType.enumValueIndex = (int) (BindTypes) EditorGUILayout.EnumPopup
											   (
												   "BindType",
												   t.BindType
											   );
				}

				serializedObject.ApplyModifiedProperties();
			}
		}
		#endif
	}
}