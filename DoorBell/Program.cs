using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DoorBell
{
    public class Program
    {
        public static void Main()
        {
			OutputPort externalLed = new OutputPort(Pins.GPIO_PIN_D5, false);
			InputPort externalButton = new InputPort(Pins.GPIO_PIN_D0, false, Port.ResistorMode.PullUp);
			OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);
			Cpu.Pin speaker = Pins.GPIO_PIN_D10;
			bool buttonState = false;
			bool songParsingComplete = false;

            const string pacman = "PacMan:d=32,o=5,b=112:32p,b,p,b6,p,f#6,p,d#6,p,b6,f#6,16p,16d#6,16p,c6,p,c7,p,g6,p,e6,p,c7,g6,16p,16e6,16p,b,p,b6,p,f#6,p,d#6,p,b6,f#6,16p,16d#6,16p,d#6,e6,f6,p,f6,f#6,g6,p,g6,g#6,a6,p,b.6";
			//const string mission = "MissionImp:d=16,o=6,b=100:32d,32d#,32d,32d#,32d,32d#,32d,32d#,32d,32d,32d#,32e,32f,32f#,32g,g,8p,g,8p,a#,p,c7,p,g,8p,g,8p,f,p,f#,p,g,8p,g,8p,a#,p,c7,p,g,8p,g,8p,f,p,f#,p,a#,g,2d,32p,a#,g,2c#,32p,a#,g,2c,a#5,8c";
			SongParser parser = new SongParser();
			var validSong = parser.GetValidSong(pacman);
			songParsingComplete = true;
			onBoardLed.Write(songParsingComplete);
			
			SongPlayer songPlayer = new SongPlayer(speaker);
		
            while (true)
            {
                buttonState = externalButton.Read();
                externalLed.Write(!buttonState);
				if (buttonState == false)
				{
					foreach (Note note in validSong.Notes)
					{
						if (!externalButton.Read())
						{
							songPlayer.PlayNote(note);
						}
					}
				}
            }
        }
    }
}
