using System;
using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UnityEngine.InputSystem;
using Zenject;

namespace TinyGameCollections
{
	/// <summary>
	/// PongPlayerのModelクラス 
	/// </summary>
	[Serializable]
	public class PongPlayerModel : IModel
	{
		[SerializeField]
		private PlayerInput _playerInput;

		[SerializeField, Inject, Disable]
		private PongWalls _pongWalls;

		[SerializeField, Range(0f, 20f)]
		private float _moveMultiplier = 10f;

		[SerializeField]
		private float _limitPosition = 3.5f;

		[SerializeField]
		private string _actionName;

		public ReactiveProperty<float> PositionY { get; set; } = new ReactiveProperty<float>();

		private float _moveAmount => _playerInput.actions[_actionName].ReadValue<float>();

		public void Initialize()
		{
			PositionY.Value = 0f;
		}

		public void Move()
		{
			var y = Mathf.Clamp(PositionY.Value + _moveAmount * Time.deltaTime * _moveMultiplier, -_limitPosition, +_limitPosition);
			PositionY.Value = y;
		}

	}
}