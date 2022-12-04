using NAudio.Wave;

public class AACPlayer
{
    public async Task Play(List<string> syllables)
    {
        foreach (string syllable in syllables)
        {
            AudioFileReader audioFile = new($"Sounds/mp3/{syllable}.mp3");
            WaveOutEvent outputDevice = new();
            
            outputDevice.Init(audioFile);
            outputDevice.Play();
            await TaskExtensions.WaitWhile(() => outputDevice.PlaybackState == PlaybackState.Playing);
        }
    }
}