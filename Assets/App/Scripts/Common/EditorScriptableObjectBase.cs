using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace TinyGameCollections
{
	/// <summary>
	/// Resourcesフォルダ以下に配置されるScriptableObjectの取得をしやすくするBaseクラス
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EditorScriptableObjectBase<T> : ScriptableObject
		where T : EditorScriptableObjectBase<T>
	{
		private static T _cachedSettings;

		public static T Instance
		{
			get
			{
				if (_cachedSettings != null)
				{
					return _cachedSettings;
				}

				#if UNITY_EDITOR
				//guid
				var guid = AssetDatabase.FindAssets("t:" + typeof(T).Name).FirstOrDefault();

				//get settings
				_cachedSettings = AssetDatabase.LoadAssetAtPath<T>( AssetDatabase.GUIDToAssetPath(guid));
				#endif

				//null check
				if (_cachedSettings == null)
				{
					Debug.LogError($"Not Found {typeof(T)} !");
				}

				return _cachedSettings;
			}
		}

		private void OnEnable()
		{
			if (Instance == null)
			{
				Debug.LogError($"Not Found {typeof(T)} !\nPlease replace {typeof(T)} 'Resources-Folder' below !");
			}
		}
	}
}