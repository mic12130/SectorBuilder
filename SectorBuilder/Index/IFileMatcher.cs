namespace SectorBuilder.Index
{
    public interface IFileMatcher
    {
        string[] MatchFiles(string dir, string pattern);
    }
}
