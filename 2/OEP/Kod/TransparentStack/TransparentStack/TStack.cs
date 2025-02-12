using System;
using System.Collections.Generic;
using System.Linq;

namespace TransparentStack.Type
{
	public class TStack<T>
	{
		class EmptyStackException : Exception { };
		class IndexOutOfBoundsException :Exception { };

		private List<T> list;
		public TStack()
		{
			list = new List<T>();
		}
		public void Push(T item)
		{
			list.Add(item);
		}
		public T Pop()
		{
			if (list.Count == 0)
				throw new EmptyStackException();
			T last = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			return last;
		}
		public T Top()
		{
			if (list.Count == 0)
				throw new EmptyStackException();
			return list[list.Count - 1];
		}
		public T this[int index]
		{
			get
			{
				if (list.Count == 0 || list.Count < index || index < 0)
					throw new IndexOutOfBoundsException();
				return list[index];
			}
			private set
			{
				list[index] = value;
			}
		}
		public override string ToString()
		{
			string rep = "[";
			foreach (T item in list)
				rep += item?.ToString() + ", ";
			rep.TrimEnd(',');
			rep += ']';
			return rep;
		}
		public int Length
		{
			get
			{
				return list.Count();
			}
			private set { } 
		}
	}
}