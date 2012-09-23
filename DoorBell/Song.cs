using System;
using Microsoft.SPOT;
using System.Collections;

namespace DoorBell
{
    public class Song
    {
        public string Name { get; set; }
        public uint DefaultDuration { get; set; }
        public uint DefaultOctave { get; set; }
        public uint Tempo { get; set; }
        public uint WholeNote 
        {
            get
            {
                if (Tempo != 0)
                {
                    return 60 * 1000 * 4 / Tempo;
                }
                else
                {
                    return 0;
                }
            } 
        }
		private readonly NoteList notes = new NoteList();
		public IEnumerable Notes 
		{ 
			get 
			{ 
				return notes; 
			} 
		}

		public void AddNote(Note note)
		{
			notes.Add(note);	
		}
	}
}
