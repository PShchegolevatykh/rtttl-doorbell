using System;
using Microsoft.SPOT;
using System.Collections;
using System.Threading;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace DoorBell
{
    public class SongPlayer
    {
		private PWM pwm;

		public SongPlayer(Cpu.Pin speakerPin)
		{
			pwm = new PWM(speakerPin);
		}

		public void Play(uint frequencyInHertz, uint durationMilliseconds)
		{
			Thread.Sleep(10);
			if (frequencyInHertz != 0)
			{
				// 50% = perfect square wave
				uint timbre = 50; 
				pwm.SetDutyCycle(timbre);

				// 1000,000 instead of 1,000 because SetPulse duration is in microseconds, not in milliSeconds
				uint period = (uint)1000000 / frequencyInHertz; 
				pwm.SetPulse(period, durationMilliseconds);
			}

			// wait for note (or silence) to play out, then be quiet
			Thread.Sleep((int)durationMilliseconds);
			pwm.SetDutyCycle(0);
		}

		public void PlayNote(Note note)
		{
			Play(note.FrequencyInHertz, note.DurationMilliseconds);
		}
    }
}
