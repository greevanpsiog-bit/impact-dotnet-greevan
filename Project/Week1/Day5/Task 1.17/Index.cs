namespace BridgeCourse.Week1;

public class Playlist
{
    private readonly List<string> _songs = new();

    public void Add(string song) => _songs.Add(song);
    public int Count => _songs.Count;

    // Integer Indexer with strict bounds checking
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= _songs.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Playlist index is out of bounds.");
            return _songs[index];
        }
        set
        {
            if (index < 0 || index >= _songs.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Playlist index is out of bounds.");
            _songs[index] = value;
        }
    }

    // String Indexer (Searches/Replaces by song name)
    public string this[string songName]
    {
        get => _songs.Contains(songName) ? songName : null;
        set
        {
            int idx = _songs.IndexOf(songName);
            if (idx != -1) _songs[idx] = value;
        }
    }
}