using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TinyGameCollections.Pong
{
	public class PongSceneRoot : SceneRootBase
	{
		[SerializeField, Inject, Disable]
		private PongFieldPresenter _pongFieldPresenter;

		protected override void Initialize(bool isLoadSucceed)
		{
			_pongFieldPresenter.Initialize();
		}
	}
}
