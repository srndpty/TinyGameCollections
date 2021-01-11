using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TinyGameCollections
{
	public class InspectorLock
	{
		// インスペクターのロック状態をトグルさせる
		[MenuItem("Tools/Editor/Toggle Inspector Lock %l")] // Ctrl(Command⌘) + L
		static void ToggleInspectorLock()
		{
			ActiveEditorTracker.sharedTracker.isLocked ^= true;
			ActiveEditorTracker.sharedTracker.ForceRebuild();
		}
	}
}