namespace MicroServiceCharacter.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string ActiveSpecName { get; set; }
        public string ActiveSpecRole { get; set; }
        public string Gender { get; set; }
        public string Faction { get; set; }
        public int AchievementPoints { get; set; }
        public int HonorableKills { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Region { get; set; }
        public string Realm { get; set; }
        public DateTime? LastCrawledAt { get; set; }
        public string ProfileUrl { get; set; }
        public string ProfileBanner { get; set; }
    }
}
