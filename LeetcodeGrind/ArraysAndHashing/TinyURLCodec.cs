namespace LeetcodeGrind.ArraysAndHashing;

// 535. Encode and Decode TinyURL
public class TinyURLCodec
{
    Dictionary<string, string> _codecMap = new Dictionary<string, string>();

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        var id = System.Guid.NewGuid().ToString().Substring(0, 6);
        _codecMap[id] = longUrl;
        return "https://tinyurl.com/" + id;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        var id = shortUrl.Replace("https://tinyurl.com/", "");
        return _codecMap[id];
    }
}