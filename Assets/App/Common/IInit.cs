using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyGameCollections
{
	public interface IInit
	{
		void Initialize();
	}

	interface IInit<T>
	{
		void Initialize(T data);
	}

	interface IInit<T1, T2>
	{
		void Initialize(T1 data1, T2 data2);
	}
}
