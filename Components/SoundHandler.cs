using System;
using System.Threading;
using System.Media;


namespace StudentsSelector
{
    public static class Sounds
    {
        public static void Intro()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\xxjos\Desktop\SelectorEstudiantes\Extras\IntroMusic.wav";
                player.Play();
            }
            else
            {
                Console.WriteLine("Sound playback is only supported on Windows.");
            }
        }

        public static void StartSound(){
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\xxjos\Desktop\SelectorEstudiantes\Extras\StartingXP.wav";
                player.Play();
            }
            else
            {
                Console.WriteLine("Sound playback is only supported on Windows.");
            }
        }

        public static void Error(){
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\xxjos\Desktop\SelectorEstudiantes\Extras\ErrorXP.wav";
                player.Play();
            }
            else
            {
                Console.WriteLine("Sound playback is only supported on Windows.");
            }
        }

          public static void Acess(){
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\xxjos\Desktop\SelectorEstudiantes\Extras\Acess.wav";
                player.Play();
            }
            else
            {
                Console.WriteLine("Sound playback is only supported on Windows.");
            }
        }
    }
}