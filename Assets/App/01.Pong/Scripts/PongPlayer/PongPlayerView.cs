using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyGameCollections
{
	/// <summary>
	/// PongPlayerのViewクラス
	/// </summary>
	[DisallowMultipleComponent]
	public class PongPlayerView : MonoBehaviour, IView
	{
		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Initialize()
		{
		}

		public void SetY(float y)
		{
			var pos = transform.position;
			pos.y = y;
			transform.position = pos;
		}
	}
}