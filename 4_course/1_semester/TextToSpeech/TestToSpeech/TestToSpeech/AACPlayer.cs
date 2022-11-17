using NAudio.Wave;

public class AACPlayer
{
    public async Task Play(List<string> syllables)
    {
        foreach (string syllable in syllables)
        {
            await using AudioFileReader audioFile = new($"Sounds/{syllable}.aac");
            using WaveOutEvent outputDevice = new();
            
            outputDevice.Init(audioFile);
            outputDevice.Play();
            await TaskExtensions.WaitWhile(() => outputDevice.PlaybackState == PlaybackState.Playing);
        }
    }
}