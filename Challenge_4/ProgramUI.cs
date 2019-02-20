using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Challenge_4
{
    public abstract class ConsoleScreen {
        bool IsRunning { get; set; }

        public abstract int MaxIndex { get; }

        public virtual bool OnKeyPress(ConsoleKeyInfo keyInfo) {
            return false;
        }
        public virtual void Draw() {
            Console.Clear();
        }
        public void Run() {
            IsRunning = true;

            while (IsRunning) {
                Draw();
                OnKeyPress(Console.ReadKey());
            }
        }
    }

    class BadgeEditScreen : ConsoleScreen
    {
        Badge badge;
        int index = 0;

        public BadgeEditScreen(Badge b) {
            this.badge = b;
        }

        public override int MaxIndex => badge.AccessibleDoors.Length;

        public override void Draw()
        {
            base.Draw();
            for (int i = 0; i < badge.AccessibleDoors.Length; i++)
            {
                ConsoleColor fc = Console.ForegroundColor;
                ConsoleColor bc = Console.BackgroundColor;
                if (i == index)
                {
                    Console.ForegroundColor = bc;
                    Console.BackgroundColor = fc;
                }
                Console.WriteLine(badge.AccessibleDoors[i]);
                if (i == index)
                {
                    Console.ForegroundColor = fc;
                    Console.BackgroundColor = bc;
                }
            }
        }
        public override bool OnKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (base.OnKeyPress(keyInfo)) return true;

            switch (keyInfo.Key) {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = MaxIndex - 1;
                    return true;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index >= MaxIndex) index = 0;
                    return true;
                case ConsoleKey.Delete:
                    badge.DenyAccess(badge.AccessibleDoors[index]);
                    while (index >= MaxIndex) index--;
                    return true;
                case ConsoleKey.Insert:
                    badge.GrantAccess(Console.ReadLine().Split(','));
                    break;
            }
            
            return false;
        }
    }

    public class ProgramUI : ConsoleScreen
    {
        BadgeRepository badges = new BadgeRepository();
        int index = 0;

        public override int MaxIndex => badges.NumberOfBadges;

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Badge #     Door Access");
            int i = 0;
            foreach (ulong key in badges.badges.Keys) {
                Badge badge = badges.badges[key];
                string badgeNumStr = $"{badge.BadgeID}";
                while (badgeNumStr.Length < 11) badgeNumStr += " ";
                string str = $"{badgeNumStr} {badge.AccessibleDoorsString}";
                ConsoleColor fc = Console.ForegroundColor;
                ConsoleColor bc = Console.BackgroundColor;
                if (i == index)
                {
                    Console.ForegroundColor = bc;
                    Console.BackgroundColor = fc;
                }
                Console.WriteLine(str);
                if (i == index)
                {
                    Console.ForegroundColor = fc;
                    Console.BackgroundColor = bc;
                }
                i++;
            }
        }

        public override bool OnKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (base.OnKeyPress(keyInfo)) return true;

            ConsoleKey key = keyInfo.Key;
            switch (key) {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = MaxIndex - 1;
                    return true;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index >= MaxIndex) index = 0;
                    return true;
                case ConsoleKey.N:
                    Console.Clear();
                    Console.WriteLine("What doors should this new badge open (separate with commas):");
                    string[] doors = Console.ReadLine().Split(',');
                    badges.AddBadge(new Badge(doors));
                    return true;
                case ConsoleKey.C:
                    badges.GetBadge(index).ClearAccess();
                    return true;
                case ConsoleKey.E:
                    new BadgeEditScreen(badges.GetBadge(index)).Run();
                    return true;
            }

            return false;
        }
    }
}
