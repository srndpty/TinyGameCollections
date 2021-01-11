using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyGameCollections
{
	public abstract class SceneRootBase : MonoBehaviour
	{
		void Start()
		{
			OnStart();
		}

		private void OnStart()
		{
			// Common�V�[�����[�h�Ȃ�

			// init
			Initialize(true);
		}

		protected abstract void Initialize(bool isLoadSucceed);
	}
}
