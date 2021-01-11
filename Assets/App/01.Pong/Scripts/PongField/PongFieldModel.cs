using System;
using UnityEngine;
using System.Collections.Generic;
using UniRx;
using Cysharp.Threading.Tasks;
using Zenject;

namespace TinyGameCollections
{
	/// <summary>
	/// PongFieldのModelクラス 
	/// </summary>
	[Serializable]
	public class PongFieldModel : IModel
	{
	    public void Initialize()
	    {
	        //初期化処理
	    }
	}
}