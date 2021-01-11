using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyGameCollections
{
	public class PongWalls : MonoBehaviour
	{
		[SerializeField]
		private Collider2D _topWall;
		public Collider2D TopWall => _topWall;

		[SerializeField]
		private Collider2D _bottomWall;
		public Collider2D BottomWall => _bottomWall;

		[SerializeField]
		private Collider2D _leftWall;
		public Collider2D LeftWall => _leftWall;

		[SerializeField]
		private Collider2D _rightWall;
		public Collider2D RightWall => _rightWall;

	}
}
