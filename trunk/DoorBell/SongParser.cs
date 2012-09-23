using System;
using Microsoft.SPOT;

namespace DoorBell
{
	public class SongParser
	{
		/// <summary>
		/// Parse from RTTTL string.
		/// </summary>
		/// <param name="songToParse">Name consist of three parts: name of the ringtone, settings, and the actual notes.</param>
		/// <returns>Valid song</returns>
		public Song GetValidSong(string songToParse)
		{
			string[] parts = songToParse.Split(':');
			Song song = new Song();
			song.Name = parts[0]; 
			string settings = parts[1]; 
			string tones = parts[2].ToUpper();
			string[] settingParts = settings.Split(',');
			song.DefaultDuration = GetValue(settingParts[0]);
			song.DefaultOctave = GetValue(settingParts[1]);
			song.Tempo = GetValue(settingParts[2]);
			string[] songNotes = tones.Split(',');
			foreach (string songNote in songNotes)
			{
				string rawNote = songNote.Trim();
				if (!CharExtensions.IsDigit(rawNote[0])) 
				{
					rawNote = song.DefaultDuration + rawNote;  
				}
				if (!CharExtensions.IsDigit(rawNote[rawNote.Length - 1])) 
				{ 
					rawNote = rawNote + song.DefaultOctave; 
				}
				song.AddNote(ParseNote(rawNote, song.WholeNote));
			}
			return song;
		}

		private Note ParseNote(string rawNote, uint wholeNote)
		{
			Note note = new Note();
			if (CharExtensions.IsDigit(rawNote[1])) 
			{
				note.DurationMilliseconds = wholeNote / uint.Parse(rawNote.Substring(0, 2)); 
				note.Name = rawNote.Substring(2, rawNote.Length - 2);
			}
			else
			{
				note.DurationMilliseconds = wholeNote / uint.Parse(rawNote.Substring(0, 1));
				note.Name = rawNote.Substring(1, rawNote.Length - 1);
			}

			// fix dotted notes
			if (note.Name[note.Name.Length - 2] == '.')
			{
				note.Name = note.Name.Substring(0, note.Name.Length - 2) + note.Name[note.Name.Length - 1];
				note.DurationMilliseconds += note.DurationMilliseconds / 2;
			}

			note.FrequencyInHertz = Note.GetDefaultFrequency(note.Name);

			return note;
		}

		private uint GetValue(string settingsNameValuePair)
		{
			return uint.Parse(settingsNameValuePair.Split('=')[1]);
		}
	}
}
