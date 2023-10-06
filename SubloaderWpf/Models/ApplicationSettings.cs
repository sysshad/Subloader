using System;
using System.Collections.Generic;
using OpenSubtitlesSharp;
using SubloaderWpf.Extensions;

namespace SubloaderWpf.Models;

public class ApplicationSettings
{
    public bool AllowMultipleDownloads { get; set; }
    public SearchParameters DefaultSearchParameters { get; set; } = new();
    public bool DownloadToSubsFolder { get; set; }
    public bool KeepWindowOnTop { get; set; } = true;
    public User LoggedInUser { get; set; }
    public bool OverwriteSameLanguageSub { get; set; }
    public string PreferredFormat { get; set; } = "srt";

    public IReadOnlyList<string> WantedLanguages { get; set; }

    public ApplicationSettings Initialize()
    {
        DefaultSearchParameters ??= new();
        PreferredFormat ??= "srt";
        WantedLanguages ??= new List<string>() { "en" };

        if (LoggedInUser != null && LoggedInUser.TokenExpirationUnixTimestamp <= DateTime.UtcNow.ToUnixTimestamp())
        {
            LoggedInUser = null;
        }

        return this;
    }
}
