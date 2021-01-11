using System.Reflection;
using UnityEngine;
using Zenject;

#if UNITY_EDITOR
namespace TinyGameCollections
{
	public static class ZenjectRefrectionHelper
	{
		public static void SetComponents(ZenjectBinding binding, Component[] components)
		{
			var type = typeof(ZenjectBinding);
			var field = type.GetField
						(
							"_components",
							BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance
						);
			Debug.Assert(field != null);
			field.SetValue(binding, components);
		}

		public static void SetContext(ZenjectBinding binding, Context context)
		{
			var type = typeof(ZenjectBinding);
			var field = type.GetField
						(
							"_context",
							BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance
						);
			Debug.Assert(field != null);
			field.SetValue(binding, context);
		}
	}
}
#endif