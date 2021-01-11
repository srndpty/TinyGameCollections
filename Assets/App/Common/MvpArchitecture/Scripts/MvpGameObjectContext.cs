using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Zenject;

namespace TinyGameCollections
{
	[DisallowMultipleComponent]
	public sealed class MvpGameObjectContext : GameObjectContext
	{
		#if UNITY_EDITOR

		[CustomEditor(typeof(MvpGameObjectContext))]
		public class MvpGameObjectContextEditor : Editor
		{
			private IPresenter _presenter;
			private IView _view;
			public override void OnInspectorGUI()
			{
				var t = target as MvpGameObjectContext;

				if (_presenter == null)
				{
					_presenter = t.gameObject.GetComponent<IPresenter>();
				}

				if (_view == null)
				{
					_view = t.gameObject.GetComponent<IView>();
				}

				var cText = "■ PresenterとView用のGameObjectContext";
				var pText =
					$"Presenter : {_presenter?.GetType().Name}クラスでInjectしたい他のPresenterクラスが存在する場合、" +
					"そのPresenterクラスのPresenterZenjectBindingに、このGameObjectContextを" +
					"設定してください";
				var vText =
					$"View : {_view?.GetType().Name}クラスでInjectしたいView系のオブジェクト(ButtonやImageなど)が存在する場合、" +
					"そのオブジェクトにアタッチされているZenjectBindingのContext項目に、" +
					"このGameObejctContextを設定してください";
				var helpBoxText = $"{cText}\n\n{pText}\n\n{vText}";
				//help box
				EditorGUILayout.HelpBox(helpBoxText, MessageType.Info);
				//draw default
				DrawDefaultInspector();
			}
		}
		#endif
	}
}