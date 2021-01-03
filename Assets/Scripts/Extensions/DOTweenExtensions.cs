using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;

namespace TinyGameCollections
{
	public static class DOTweenExtensions
	{
		public static TaskAwaiter<Tween> GetAwaiter( this Tween self )
		{
			var source = new TaskCompletionSource<Tween>();

			TweenCallback onComplete = null;
			onComplete = () =>
			{
				self.onComplete -= onComplete;
				source.SetResult( self );
			};
			self.onComplete += onComplete;

			return source.Task.GetAwaiter();
		}
	}
}