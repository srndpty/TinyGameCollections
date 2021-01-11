using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyGameCollections
{
	public class MvpSettings : EditorScriptableObjectBase<MvpSettings>
	{
		[SerializeField]
		private List<TextAsset> _templates = default;
		public List<TextAsset> Templates => _templates;
	}
}