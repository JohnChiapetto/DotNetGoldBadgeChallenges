using System.Collections.Generic;

namespace Challenge_4
{
    public class BadgeRepository
    {
        public Dictionary<ulong,Badge> badges = new Dictionary<ulong,Badge>();
        public List<ulong> badgeNumbers = new List<ulong>();

        public int NumberOfBadges => badges.Count;

        public Badge this[ulong k] {
            get { return badges[k]; }
            set {
                if (badges.ContainsKey(k))
                    badges[k] = value;
                badges.Add(k,value);
            }
        }

        public Badge GetBadge(int index) {
            return badges[badgeNumbers[index]];
        }
        public Badge GetBadge(ulong key) {
            return badges[key];
        }
        public void AddBadge(Badge badge) {
            badges.Add(badge.BadgeID,badge);
            badgeNumbers.Add(badge.BadgeID);
        }
        public void RemoveBadge(ulong n) {
            badges.Remove(n);
            badgeNumbers.Remove(n);
        }
        public void RemoveBadge(Badge b) {
            badges.Remove(b.BadgeID);
            badgeNumbers.Remove(b.BadgeID);
        }
    }
}
