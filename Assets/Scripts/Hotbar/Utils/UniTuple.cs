using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Utils
{
	[System.Serializable] public sealed class UniTuple<T1, T2> : System.Tuple<T1, T2>
	{
		[SerializeField] public T1 value1;
		[SerializeField] public T2 value2;

		public UniTuple(T1 item1, T2 item2) : base(item1, item2)
        {
			value1 = item1;
			value2 = item2;
        }

		public new T1 Item1 { get => value1; }
		public new T2 Item2 { get => value2; }
	}

	[System.Serializable] public sealed class UniTuple<T1, T2, T3> : System.Tuple<T1, T2, T3>
	{
		[SerializeField] public T1 value1;
		[SerializeField] public T2 value2;
		[SerializeField] public T3 value3;


		public UniTuple(T1 item1, T2 item2, T3 item3) : base(item1, item2, item3)
		{
			value1 = item1;
			value2 = item2;
			value3 = item3;
		}

		public new T1 Item1 { get => value1; }
		public new T2 Item2 { get => value2; }
		public new T3 Item3 { get => value3; }

	}

	[System.Serializable] public sealed class UniTuple<T1, T2, T3, T4> : System.Tuple<T1, T2, T3, T4>
	{
		[SerializeField] public T1 value1;
		[SerializeField] public T2 value2;
		[SerializeField] public T3 value3;
		[SerializeField] public T4 value4;

		public UniTuple(T1 item1, T2 item2, T3 item3, T4 item4) : base(item1, item2, item3, item4)
		{
			value1 = item1;
			value2 = item2;
			value3 = item3;
			value4 = item4;
		}

		public new T1 Item1 { get => value1; }
		public new T2 Item2 { get => value2; }
		public new T3 Item3 { get => value3; }
		public new T4 Item4 { get => value4; }
	}

	[System.Serializable] public sealed class UniTuple<T1, T2, T3, T4, T5> : System.Tuple<T1, T2, T3, T4, T5>
	{
		[SerializeField] public T1 value1;
		[SerializeField] public T2 value2;
		[SerializeField] public T3 value3;
		[SerializeField] public T4 value4;
		[SerializeField] public T5 value5;


		public UniTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) : base(item1, item2, item3, item4, item5)
		{
			value1 = item1;
			value2 = item2;
			value3 = item3;
			value4 = item4;
			value5 = item5;

		}

		public new T1 Item1 { get => value1; }
		public new T2 Item2 { get => value2; }
		public new T3 Item3 { get => value3; }
		public new T4 Item4 { get => value4; }
		public new T5 Item5 { get => value5; }
	}

	[System.Serializable] public sealed class UniTuple<T1, T2, T3, T4, T5, T6> : System.Tuple<T1, T2, T3, T4, T5, T6>
	{
		[SerializeField] public T1 value1;
		[SerializeField] public T2 value2;
		[SerializeField] public T3 value3;
		[SerializeField] public T4 value4;
		[SerializeField] public T5 value5;
		[SerializeField] public T6 value6;



		public UniTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) : base(item1, item2, item3, item4, item5, item6)
		{
			value1 = item1;
			value2 = item2;
			value3 = item3;
			value4 = item4;
			value5 = item5;
			value6 = item6;
		}

		public new T1 Item1 { get => value1; }
		public new T2 Item2 { get => value2; }
		public new T3 Item3 { get => value3; }
		public new T4 Item4 { get => value4; }
		public new T5 Item5 { get => value5; }
		public new T6 Item6 { get => value6; }
	}

}