using System;
using Microsoft.SPOT;
using System.Collections;

namespace DoorBell
{
    public class NoteList : IEnumerable
    {
        private ArrayList noteList = new ArrayList();

        public IEnumerator GetEnumerator()
        {
            return noteList.GetEnumerator();
        }

		public int Add(Note value)
		{
			return noteList.Add(value);
		}

        public void Clear()
        {
            noteList.Clear();
        }

        public bool Contains(Note note)
        {
            return noteList.Contains(note);
        }

        public int IndexOf(Note note)
        {
            return noteList.IndexOf(note);
        }

        public void Insert(int index, Note note)
        {
            noteList.Insert(index, note);
        }

        public void Remove(Note note)
        {
            noteList.Remove(note);
        }

        public void RemoveAt(int index)
        {
            noteList.RemoveAt(index);
        }

        public Note this[int index]
        {
            get
            {
                return (Note)noteList[index];
            }
            set
            {
                noteList[index] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            noteList.CopyTo(array, index);
        }

        public int Count
        {
            get { return noteList.Count; }
        }
    }
}
