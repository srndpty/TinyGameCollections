using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;

namespace TinyGameCollections
{
	/// <summary>
	/// PongFieldのViewクラス
	/// </summary>
	[DisallowMultipleComponent]
	public class PongFieldView : MonoBehaviour, IView
	{
		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Initialize()
		{
		}
	}
}