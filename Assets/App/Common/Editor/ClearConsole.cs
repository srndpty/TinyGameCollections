using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace TinyGameCollections
{
	public static class ClearConsole
	{
		// コンソールログをクリアする
		[MenuItem("Tools/Editor/Clear Console #&c")] // Alt(Option) + Shift + L
		static void Clear()
		{
			var assembly = Assembly.GetAssembly(typeof(SceneView));
			var type = assembly.GetType("UnityEditor.LogEntries");
			var method = type.GetMethod("Clear");
			method.Invoke(new object(), null);
		}
	}
}