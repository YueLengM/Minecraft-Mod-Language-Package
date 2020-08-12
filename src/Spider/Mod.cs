﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Spider
{
    public class Mod:IEquatable<Mod>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("projectId")]
        public long ProjectId { get; set; }
        [JsonPropertyName("projectUrl")]
        public Uri ProjectUrl { get; set; }
        [JsonPropertyName("downloadUrl")]
        public Uri DownloadUrl { get; set; }
        [JsonPropertyName("modId")]
        public string ModId { get; set; }
        [JsonPropertyName("assetDomain")]
        public string AssetDomain { get; set; }
        [JsonPropertyName("lastUpdateTime")]
        public DateTimeOffset LastUpdateTime { get; set; }
        [JsonPropertyName("lastCheckUpdateTime")]
        public DateTimeOffset LastCheckUpdateTime { get; set; }
        [JsonPropertyName("languageFilePaths")]
        public List<string> LanguageFilePaths { get; set; }
        [JsonIgnore]
        public string Path { get; set; }

        public bool Equals(Mod other)
        {
            return ProjectId == other.ProjectId && Equals(ProjectUrl, other.ProjectUrl) && ModId == other.ModId && AssetDomain == other.AssetDomain && Equals(LanguageFilePaths, other.LanguageFilePaths);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Mod)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProjectId, ProjectUrl, ModId, AssetDomain, LanguageFilePaths);
        }

        private sealed class ModEqualityComparer : IEqualityComparer<Mod>
        {
            public bool Equals(Mod x, Mod y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ProjectId == y.ProjectId && Equals(x.ProjectUrl, y.ProjectUrl) && x.ModId == y.ModId && x.AssetDomain == y.AssetDomain && Equals(x.LanguageFilePaths, y.LanguageFilePaths);
            }

            public int GetHashCode(Mod obj)
            {
                return HashCode.Combine(obj.ProjectId, obj.ProjectUrl, obj.ModId, obj.AssetDomain, obj.LanguageFilePaths);
            }
        }

        public static IEqualityComparer<Mod> ModComparer { get; } = new ModEqualityComparer();
    }
}