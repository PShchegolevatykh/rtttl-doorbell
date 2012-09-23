using System;
using Microsoft.SPOT;
using System.Collections;

namespace DoorBell
{
    public class Note
    {
        public string Name { get; set; }
        public uint FrequencyInHertz { get; set; }
		public uint DurationMilliseconds { get; set; }

		public Note()
		{
		}

		public Note(string name, uint frequencyInHertz)
		{
			Name = name;
			FrequencyInHertz = frequencyInHertz;
		}

		public Note(string name, uint frequencyInHertz, uint durationMilliseconds)
			: this(name, frequencyInHertz)
		{
			DurationMilliseconds = durationMilliseconds;
		}

		public static uint GetDefaultFrequency(string name)
		{
			foreach (Note note in defaultNotes)
			{
				if (note.Name == name)
				{
					return note.FrequencyInHertz;
				}
			}
			return 0;
		}

		private static readonly NoteList defaultNotes = GetDefaultNotes();

        private static NoteList GetDefaultNotes()
        {
            return new NoteList { new Note("B0",  31),
                           new Note("C1",  33),
                           new Note("C#1", 35),
                           new Note("D1",  37),
                           new Note("D#1", 39),
                           new Note("E1",  41),
                           new Note("F1",  44),
                           new Note("F#1", 46),
                           new Note("G1",  49),
                           new Note("G#1", 52),
                           new Note("A1",  55),
                           new Note("A#1", 58),
                           new Note("B1",  62),
                           new Note("C2",  65),
                           new Note("C#2", 69),
                           new Note("D2",  73),
                           new Note("D#2", 78),
                           new Note("E2",  82),
                           new Note("F2",  87),
                           new Note("F#2", 93),
                           new Note("G2",  98),
                           new Note("G#2", 104),
                           new Note("A2",  110),
                           new Note("A#2", 117),
                           new Note("B2",  123),
                           new Note("C3",  131),
                           new Note("C#3", 139),
                           new Note("D3",  147),
                           new Note("D#3", 156),
                           new Note("E3",  165),
                           new Note("F3",  175),
                           new Note("F#3", 185),
                           new Note("G3",  196),
                           new Note("G#3", 208),
                           new Note("A3",  220),
                           new Note("A#3", 233),
                           new Note("B3",  247),
                           new Note("C4",  262),
                           new Note("C#4", 277),
                           new Note("D4",  294),
                           new Note("D#4", 311),
                           new Note("E4",  330),
                           new Note("F4",  349),
                           new Note("F#4", 370),
                           new Note("G4",  392),
                           new Note("G#4", 415),
                           new Note("A4",  440),
                           new Note("A#4", 466),
                           new Note("B4",  494),
                           new Note("C5",  523),
                           new Note("C#5", 554),
                           new Note("D5",  587),
                           new Note("D#5", 622),
                           new Note("E5",  659),
                           new Note("F5",  698),
                           new Note("F#5", 740),
                           new Note("G5",  784),
                           new Note("G#5", 831),
                           new Note("A5",  880),
                           new Note("A#5", 932),
                           new Note("B5",  988),
                           new Note("C6",  1047),
                           new Note("C#6", 1109),
                           new Note("D6",  1175),
                           new Note("D#6", 1245),
                           new Note("E6",  1319),
                           new Note("F6",  1397),
                           new Note("F#6", 1480),
                           new Note("G6",  1568),
                           new Note("G#6", 1661),
                           new Note("A6",  1760),
                           new Note("A#6", 1865),
                           new Note("B6",  1976),
                           new Note("C7",  2093),
                           new Note("C#7", 2217),
                           new Note("D7",  2349),
                           new Note("D#7", 2489),
                           new Note("E7",  2637),
                           new Note("F7",  2794),
                           new Note("F#7", 2960),
                           new Note("G7",  3136),
                           new Note("G#7", 3322),
                           new Note("A7",  3520),
                           new Note("A#7", 3729),
                           new Note("B7",  3951),
                           new Note("C8",  4186),
                           new Note("C#8", 4435),
                           new Note("D8",  4699),
                           new Note("D#8", 4978)
			};
        }
    }
}
