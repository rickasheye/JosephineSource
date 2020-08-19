using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

public partial class RedditPost
{
    [JsonProperty("kind")]
    public string Kind { get; set; }

    [JsonProperty("data")]
    public RedditPostData Data { get; set; }
}

public partial class RedditPostData
{
    [JsonProperty("modhash")]
    public string Modhash { get; set; }

    [JsonProperty("dist")]
    public long Dist { get; set; }

    [JsonProperty("children")]
    public Child[] Children { get; set; }

    [JsonProperty("after")]
    public string After { get; set; }

    [JsonProperty("before")]
    public object Before { get; set; }
}

public partial class Child
{
    [JsonProperty("kind")]
    public Kind Kind { get; set; }

    [JsonProperty("data")]
    public ChildData Data { get; set; }
}

public partial class ChildData
{
    [JsonProperty("approved_at_utc")]
    public object ApprovedAtUtc { get; set; }

    [JsonProperty("subreddit")]
    public Subreddit Subreddit { get; set; }

    [JsonProperty("selftext")]
    public string Selftext { get; set; }

    [JsonProperty("author_fullname")]
    public string AuthorFullname { get; set; }

    [JsonProperty("saved")]
    public bool Saved { get; set; }

    [JsonProperty("mod_reason_title")]
    public object ModReasonTitle { get; set; }

    [JsonProperty("gilded")]
    public long Gilded { get; set; }

    [JsonProperty("clicked")]
    public bool Clicked { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("link_flair_richtext")]
    public object[] LinkFlairRichtext { get; set; }

    [JsonProperty("subreddit_name_prefixed")]
    public SubredditNamePrefixed SubredditNamePrefixed { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }

    [JsonProperty("pwls")]
    public long Pwls { get; set; }

    [JsonProperty("link_flair_css_class")]
    public object LinkFlairCssClass { get; set; }

    [JsonProperty("downs")]
    public long Downs { get; set; }

    [JsonProperty("thumbnail_height")]
    public object ThumbnailHeight { get; set; }

    [JsonProperty("top_awarded_type")]
    public object TopAwardedType { get; set; }

    [JsonProperty("hide_score")]
    public bool HideScore { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("quarantine")]
    public bool Quarantine { get; set; }

    [JsonProperty("link_flair_text_color")]
    public LinkFlairTextColor LinkFlairTextColor { get; set; }

    [JsonProperty("upvote_ratio")]
    public double UpvoteRatio { get; set; }

    [JsonProperty("author_flair_background_color")]
    public object AuthorFlairBackgroundColor { get; set; }

    [JsonProperty("subreddit_type")]
    public SubredditType SubredditType { get; set; }

    [JsonProperty("ups")]
    public long Ups { get; set; }

    [JsonProperty("total_awards_received")]
    public long TotalAwardsReceived { get; set; }

    [JsonProperty("media_embed")]
    public MediaEmbed MediaEmbed { get; set; }

    [JsonProperty("thumbnail_width")]
    public object ThumbnailWidth { get; set; }

    [JsonProperty("author_flair_template_id")]
    public object AuthorFlairTemplateId { get; set; }

    [JsonProperty("is_original_content")]
    public bool IsOriginalContent { get; set; }

    [JsonProperty("user_reports")]
    public object[] UserReports { get; set; }

    [JsonProperty("secure_media")]
    public object SecureMedia { get; set; }

    [JsonProperty("is_reddit_media_domain")]
    public bool IsRedditMediaDomain { get; set; }

    [JsonProperty("is_meta")]
    public bool IsMeta { get; set; }

    [JsonProperty("category")]
    public object Category { get; set; }

    [JsonProperty("secure_media_embed")]
    public MediaEmbed SecureMediaEmbed { get; set; }

    [JsonProperty("link_flair_text")]
    public object LinkFlairText { get; set; }

    [JsonProperty("can_mod_post")]
    public bool CanModPost { get; set; }

    [JsonProperty("score")]
    public long Score { get; set; }

    [JsonProperty("approved_by")]
    public object ApprovedBy { get; set; }

    [JsonProperty("author_premium")]
    public bool AuthorPremium { get; set; }

    [JsonProperty("thumbnail")]
    public PostHint Thumbnail { get; set; }

    [JsonProperty("edited")]
    public Edited Edited { get; set; }

    [JsonProperty("author_flair_css_class")]
    public object AuthorFlairCssClass { get; set; }

    [JsonProperty("author_flair_richtext")]
    public object[] AuthorFlairRichtext { get; set; }

    [JsonProperty("gildings")]
    public Gildings Gildings { get; set; }

    [JsonProperty("content_categories")]
    public object ContentCategories { get; set; }

    [JsonProperty("is_self")]
    public bool IsSelf { get; set; }

    [JsonProperty("mod_note")]
    public object ModNote { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("link_flair_type")]
    public FlairType LinkFlairType { get; set; }

    [JsonProperty("wls")]
    public long Wls { get; set; }

    [JsonProperty("removed_by_category")]
    public object RemovedByCategory { get; set; }

    [JsonProperty("banned_by")]
    public object BannedBy { get; set; }

    [JsonProperty("author_flair_type")]
    public FlairType AuthorFlairType { get; set; }

    [JsonProperty("domain")]
    public Domain Domain { get; set; }

    [JsonProperty("allow_live_comments")]
    public bool AllowLiveComments { get; set; }

    [JsonProperty("selftext_html")]
    public string SelftextHtml { get; set; }

    [JsonProperty("likes")]
    public object Likes { get; set; }

    [JsonProperty("suggested_sort")]
    public object SuggestedSort { get; set; }

    [JsonProperty("banned_at_utc")]
    public object BannedAtUtc { get; set; }

    [JsonProperty("view_count")]
    public object ViewCount { get; set; }

    [JsonProperty("archived")]
    public bool Archived { get; set; }

    [JsonProperty("no_follow")]
    public bool NoFollow { get; set; }

    [JsonProperty("is_crosspostable")]
    public bool IsCrosspostable { get; set; }

    [JsonProperty("pinned")]
    public bool Pinned { get; set; }

    [JsonProperty("over_18")]
    public bool Over18 { get; set; }

    [JsonProperty("all_awardings")]
    public AllAwarding[] AllAwardings { get; set; }

    [JsonProperty("awarders")]
    public object[] Awarders { get; set; }

    [JsonProperty("media_only")]
    public bool MediaOnly { get; set; }

    [JsonProperty("can_gild")]
    public bool CanGild { get; set; }

    [JsonProperty("spoiler")]
    public bool Spoiler { get; set; }

    [JsonProperty("locked")]
    public bool Locked { get; set; }

    [JsonProperty("author_flair_text")]
    public object AuthorFlairText { get; set; }

    [JsonProperty("treatment_tags")]
    public object[] TreatmentTags { get; set; }

    [JsonProperty("visited")]
    public bool Visited { get; set; }

    [JsonProperty("removed_by")]
    public object RemovedBy { get; set; }

    [JsonProperty("num_reports")]
    public object NumReports { get; set; }

    [JsonProperty("distinguished")]
    public string Distinguished { get; set; }

    [JsonProperty("subreddit_id")]
    public SubredditId SubredditId { get; set; }

    [JsonProperty("mod_reason_by")]
    public object ModReasonBy { get; set; }

    [JsonProperty("removal_reason")]
    public object RemovalReason { get; set; }

    [JsonProperty("link_flair_background_color")]
    public string LinkFlairBackgroundColor { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("is_robot_indexable")]
    public bool IsRobotIndexable { get; set; }

    [JsonProperty("report_reasons")]
    public object ReportReasons { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("discussion_type")]
    public object DiscussionType { get; set; }

    [JsonProperty("num_comments")]
    public long NumComments { get; set; }

    [JsonProperty("send_replies")]
    public bool SendReplies { get; set; }

    [JsonProperty("whitelist_status")]
    public WhitelistStatus WhitelistStatus { get; set; }

    [JsonProperty("contest_mode")]
    public bool ContestMode { get; set; }

    [JsonProperty("mod_reports")]
    public object[] ModReports { get; set; }

    [JsonProperty("author_patreon_flair")]
    public bool AuthorPatreonFlair { get; set; }

    [JsonProperty("author_flair_text_color")]
    public object AuthorFlairTextColor { get; set; }

    [JsonProperty("permalink")]
    public string Permalink { get; set; }

    [JsonProperty("parent_whitelist_status")]
    public WhitelistStatus ParentWhitelistStatus { get; set; }

    [JsonProperty("stickied")]
    public bool Stickied { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("subreddit_subscribers")]
    public long SubredditSubscribers { get; set; }

    [JsonProperty("created_utc")]
    public long CreatedUtc { get; set; }

    [JsonProperty("num_crossposts")]
    public long NumCrossposts { get; set; }

    [JsonProperty("media")]
    public object Media { get; set; }

    [JsonProperty("is_video")]
    public bool IsVideo { get; set; }

    [JsonProperty("post_hint", NullValueHandling = NullValueHandling.Ignore)]
    public PostHint? PostHint { get; set; }

    [JsonProperty("preview", NullValueHandling = NullValueHandling.Ignore)]
    public Preview Preview { get; set; }

    [JsonProperty("author_cakeday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AuthorCakeday { get; set; }
}

public partial class AllAwarding
{
    [JsonProperty("giver_coin_reward")]
    public long? GiverCoinReward { get; set; }

    [JsonProperty("subreddit_id")]
    public object SubredditId { get; set; }

    [JsonProperty("is_new")]
    public bool IsNew { get; set; }

    [JsonProperty("days_of_drip_extension")]
    public long DaysOfDripExtension { get; set; }

    [JsonProperty("coin_price")]
    public long CoinPrice { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("penny_donate")]
    public long? PennyDonate { get; set; }

    [JsonProperty("award_sub_type")]
    public string AwardSubType { get; set; }

    [JsonProperty("coin_reward")]
    public long CoinReward { get; set; }

    [JsonProperty("icon_url")]
    public Uri IconUrl { get; set; }

    [JsonProperty("days_of_premium")]
    public long DaysOfPremium { get; set; }

    [JsonProperty("resized_icons")]
    public ResizedIcon[] ResizedIcons { get; set; }

    [JsonProperty("icon_width")]
    public long IconWidth { get; set; }

    [JsonProperty("static_icon_width")]
    public long StaticIconWidth { get; set; }

    [JsonProperty("start_date")]
    public object StartDate { get; set; }

    [JsonProperty("is_enabled")]
    public bool IsEnabled { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("end_date")]
    public object EndDate { get; set; }

    [JsonProperty("subreddit_coin_reward")]
    public long SubredditCoinReward { get; set; }

    [JsonProperty("count")]
    public long Count { get; set; }

    [JsonProperty("static_icon_height")]
    public long StaticIconHeight { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("resized_static_icons")]
    public ResizedIcon[] ResizedStaticIcons { get; set; }

    [JsonProperty("icon_format")]
    public string IconFormat { get; set; }

    [JsonProperty("icon_height")]
    public long IconHeight { get; set; }

    [JsonProperty("penny_price")]
    public long? PennyPrice { get; set; }

    [JsonProperty("award_type")]
    public string AwardType { get; set; }

    [JsonProperty("static_icon_url")]
    public Uri StaticIconUrl { get; set; }
}

public partial class ResizedIcon
{
    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("width")]
    public long Width { get; set; }

    [JsonProperty("height")]
    public long Height { get; set; }
}

public partial class Gildings
{
    [JsonProperty("gid_2", NullValueHandling = NullValueHandling.Ignore)]
    public long? Gid2 { get; set; }
}

public partial class MediaEmbed
{
}

public partial class Preview
{
    [JsonProperty("images")]
    public Image[] Images { get; set; }

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }
}

public partial class Image
{
    [JsonProperty("source")]
    public ResizedIcon Source { get; set; }

    [JsonProperty("resolutions")]
    public ResizedIcon[] Resolutions { get; set; }

    [JsonProperty("variants")]
    public MediaEmbed Variants { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}

public enum FlairType { Text };

public enum Domain { SelfShowerthoughts };

public enum LinkFlairTextColor { Dark };

public enum WhitelistStatus { AllAds };

public enum PostHint { Self };

public enum Subreddit { Showerthoughts };

public enum SubredditId { T52Szyo };

public enum SubredditNamePrefixed { RShowerthoughts };

public enum SubredditType { Public };

public enum Kind { T3 };

public partial struct Edited
{
    public bool? Bool;
    public long? Integer;

    public static implicit operator Edited(bool Bool) => new Edited { Bool = Bool };
    public static implicit operator Edited(long Integer) => new Edited { Integer = Integer };
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                FlairTypeConverter.Singleton,
                DomainConverter.Singleton,
                EditedConverter.Singleton,
                LinkFlairTextColorConverter.Singleton,
                WhitelistStatusConverter.Singleton,
                PostHintConverter.Singleton,
                SubredditConverter.Singleton,
                SubredditIdConverter.Singleton,
                SubredditNamePrefixedConverter.Singleton,
                SubredditTypeConverter.Singleton,
                KindConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

internal class FlairTypeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(FlairType) || t == typeof(FlairType?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "text")
        {
            return FlairType.Text;
        }
        throw new Exception("Cannot unmarshal type FlairType");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (FlairType)untypedValue;
        if (value == FlairType.Text)
        {
            serializer.Serialize(writer, "text");
            return;
        }
        throw new Exception("Cannot marshal type FlairType");
    }

    public static readonly FlairTypeConverter Singleton = new FlairTypeConverter();
}

internal class DomainConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Domain) || t == typeof(Domain?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "self.Showerthoughts")
        {
            return Domain.SelfShowerthoughts;
        }
        throw new Exception("Cannot unmarshal type Domain");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Domain)untypedValue;
        if (value == Domain.SelfShowerthoughts)
        {
            serializer.Serialize(writer, "self.Showerthoughts");
            return;
        }
        throw new Exception("Cannot marshal type Domain");
    }

    public static readonly DomainConverter Singleton = new DomainConverter();
}

internal class EditedConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Edited) || t == typeof(Edited?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        switch (reader.TokenType)
        {
            case JsonToken.Integer:
                var integerValue = serializer.Deserialize<long>(reader);
                return new Edited { Integer = integerValue };
            case JsonToken.Boolean:
                var boolValue = serializer.Deserialize<bool>(reader);
                return new Edited { Bool = boolValue };
        }
        throw new Exception("Cannot unmarshal type Edited");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        var value = (Edited)untypedValue;
        if (value.Integer != null)
        {
            serializer.Serialize(writer, value.Integer.Value);
            return;
        }
        if (value.Bool != null)
        {
            serializer.Serialize(writer, value.Bool.Value);
            return;
        }
        throw new Exception("Cannot marshal type Edited");
    }

    public static readonly EditedConverter Singleton = new EditedConverter();
}

internal class LinkFlairTextColorConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(LinkFlairTextColor) || t == typeof(LinkFlairTextColor?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "dark")
        {
            return LinkFlairTextColor.Dark;
        }
        throw new Exception("Cannot unmarshal type LinkFlairTextColor");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (LinkFlairTextColor)untypedValue;
        if (value == LinkFlairTextColor.Dark)
        {
            serializer.Serialize(writer, "dark");
            return;
        }
        throw new Exception("Cannot marshal type LinkFlairTextColor");
    }

    public static readonly LinkFlairTextColorConverter Singleton = new LinkFlairTextColorConverter();
}

internal class WhitelistStatusConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(WhitelistStatus) || t == typeof(WhitelistStatus?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "all_ads")
        {
            return WhitelistStatus.AllAds;
        }
        throw new Exception("Cannot unmarshal type WhitelistStatus");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (WhitelistStatus)untypedValue;
        if (value == WhitelistStatus.AllAds)
        {
            serializer.Serialize(writer, "all_ads");
            return;
        }
        throw new Exception("Cannot marshal type WhitelistStatus");
    }

    public static readonly WhitelistStatusConverter Singleton = new WhitelistStatusConverter();
}

internal class PostHintConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(PostHint) || t == typeof(PostHint?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "self")
        {
            return PostHint.Self;
        }
        throw new Exception("Cannot unmarshal type PostHint");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (PostHint)untypedValue;
        if (value == PostHint.Self)
        {
            serializer.Serialize(writer, "self");
            return;
        }
        throw new Exception("Cannot marshal type PostHint");
    }

    public static readonly PostHintConverter Singleton = new PostHintConverter();
}

internal class SubredditConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Subreddit) || t == typeof(Subreddit?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "Showerthoughts")
        {
            return Subreddit.Showerthoughts;
        }
        throw new Exception("Cannot unmarshal type Subreddit");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Subreddit)untypedValue;
        if (value == Subreddit.Showerthoughts)
        {
            serializer.Serialize(writer, "Showerthoughts");
            return;
        }
        throw new Exception("Cannot marshal type Subreddit");
    }

    public static readonly SubredditConverter Singleton = new SubredditConverter();
}

internal class SubredditIdConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(SubredditId) || t == typeof(SubredditId?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "t5_2szyo")
        {
            return SubredditId.T52Szyo;
        }
        throw new Exception("Cannot unmarshal type SubredditId");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (SubredditId)untypedValue;
        if (value == SubredditId.T52Szyo)
        {
            serializer.Serialize(writer, "t5_2szyo");
            return;
        }
        throw new Exception("Cannot marshal type SubredditId");
    }

    public static readonly SubredditIdConverter Singleton = new SubredditIdConverter();
}

internal class SubredditNamePrefixedConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(SubredditNamePrefixed) || t == typeof(SubredditNamePrefixed?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "r/Showerthoughts")
        {
            return SubredditNamePrefixed.RShowerthoughts;
        }
        throw new Exception("Cannot unmarshal type SubredditNamePrefixed");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (SubredditNamePrefixed)untypedValue;
        if (value == SubredditNamePrefixed.RShowerthoughts)
        {
            serializer.Serialize(writer, "r/Showerthoughts");
            return;
        }
        throw new Exception("Cannot marshal type SubredditNamePrefixed");
    }

    public static readonly SubredditNamePrefixedConverter Singleton = new SubredditNamePrefixedConverter();
}

internal class SubredditTypeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(SubredditType) || t == typeof(SubredditType?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "public")
        {
            return SubredditType.Public;
        }
        throw new Exception("Cannot unmarshal type SubredditType");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (SubredditType)untypedValue;
        if (value == SubredditType.Public)
        {
            serializer.Serialize(writer, "public");
            return;
        }
        throw new Exception("Cannot marshal type SubredditType");
    }

    public static readonly SubredditTypeConverter Singleton = new SubredditTypeConverter();
}

internal class KindConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Kind) || t == typeof(Kind?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "t3")
        {
            return Kind.T3;
        }
        throw new Exception("Cannot unmarshal type Kind");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Kind)untypedValue;
        if (value == Kind.T3)
        {
            serializer.Serialize(writer, "t3");
            return;
        }
        throw new Exception("Cannot marshal type Kind");
    }

    public static readonly KindConverter Singleton = new KindConverter();
}