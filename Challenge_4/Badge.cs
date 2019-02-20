using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {

        private static ulong BadgeIDCounter = 0;

        public ulong BadgeID { get; private set; }
        private List<string> doors = new List<string>();

        public string[] AccessibleDoors => doors.ToArray();
        public string AccessibleDoorsString {
            get {
                string str = "";
                for (int i = 0; i < doors.Count; i++) {
                    str += doors[i];
                    if (i < doors.Count - 1) str += ", ";
                }
                return str;
            }
        }

        public Badge() {
            this.BadgeID = BadgeIDCounter++;
        }
        public Badge(string[] doors) : this() {
            foreach (string door in doors) this.doors.Add(door);
        }

        public bool CanOpen(string door) {
            return doors.Contains(door);
        }
        public void GrantAccess(string door)
        {
            doors.Add(door);
        }
        public void GrantAccess(string[] doors)
        {
            foreach (string door in doors) GrantAccess(door);
        }
        public void DenyAccess(string door)
        {
            doors.Remove(door);
        }
        public void DenyAccess(string[] doors)
        {
            foreach (string door in doors) DenyAccess(door);
        }
        public void ClearAccess() {
            doors.Clear();
        }
        
    }
}
