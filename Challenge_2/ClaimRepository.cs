using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        Queue<Claim> claims = new Queue<Claim>();
        bool isMenuRunning = false;
        int index = 0;

        public int NumberOfClaims { get { return claims.Count; } }
        public Claim CurrentClaim { get { return claims.Peek(); } }

        public void AddClaim(Claim claim)
        {
            claims.Enqueue(claim);
        }
        public Claim RemoveClaim()
        {
            return claims.Dequeue();
        }

        public string Stringify(Claim claim) {
            string str = claim.ClaimID.ToString("0000000");
            str += " ";
            string ct = $"{claim.ClaimType}";
            while (ct.Length < 10) ct += " ";
            str += ct;
            string cd = claim.Description;
            while (cd.Length < 30) cd += " ";
            str += cd;
            str += $"${claim.ClaimAmount.ToString("00000.00")}";
            str += "   ";
            str += claim.DateOfIncident.ToString("MM/dd/yyyy");
            str += "   ";
            str += claim.DateOfClaim.ToString("MM/dd/yyyy");
            return str;
        }
        public void ShowDetails(Claim claim) {
            Console.Clear();
            Console.WriteLine("Here are the details for the claim to be handled: ");
            Console.WriteLine($"ClaimID: {claim.ClaimID}");
            Console.WriteLine($"Type: {claim.ClaimType}");
            Console.WriteLine($"Description: {claim.Description}");
            Console.WriteLine($"Amount: ${claim.ClaimAmount.ToString("0.00")}");
            Console.WriteLine($"Date of Incident: {claim.DateOfIncident.ToString("M/dd/yyyy")}");
            Console.WriteLine($"Date of Incident: {claim.DateOfClaim.ToString("M/dd/yyyy")}");
            Console.WriteLine($"IsValid: {claim.IsValid}");
            Console.Write("\nDo you want to handle this claim now(y/n)? ");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Y) RemoveClaim();
        }
        public void OnKeyPress(ConsoleKeyInfo keyInfo) {
            ConsoleKey key = keyInfo.Key;

            switch (key) {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = NumberOfClaims - 1;
                    break;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index == NumberOfClaims) index = 0;
                    break;
                case ConsoleKey.Enter:
                    ShowDetails(CurrentClaim);
                    break;
                case ConsoleKey.N:
                    CreateClaim();
                    break;
                case ConsoleKey.Escape:
                    isMenuRunning = false;
                    break;
            }
        }
        public void DrawMenu() {
            Console.Clear();
                            //"0000001 Home Wreck in my house             $00000.05"
            Console.WriteLine("  ID      ClaimType Description                   ClaimAmount IncidentDate ClaimDate ");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            for (int i = 0; i < NumberOfClaims; i++) {
                string str = "";
                str += i == index ? "> " : "  ";
                str += Stringify(claims.ElementAt(i));
                Console.WriteLine(str);
            }
        }
        private static string Prompt(string p) {
            Console.Write(p);
            return Console.ReadLine();
        }
        public void CreateClaim() {
            /*
             * Enter the claim id: 4
             * Enter the claim type: Car
             * Enter a claim description: Wreck on I-70.
             * Amount of Damage: $2000.00
             * Date Of Accident: 4/27/18
             * Date of Claim: 4/28/18
             */
            Console.Clear();
            Claim claim = new Claim();
            claim.ClaimID = long.Parse(Prompt("Enter the claim id: "));
            string typeq = Prompt("Enter the claim type: ");
            switch (typeq.ToLower()) {
                case "car":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "home":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    claim.ClaimType = ClaimType.Theft;
                    break;
            }
            claim.Description = Prompt("Enter a claim description: ");
            claim.ClaimAmount = Decimal.Parse(Prompt("Amount of Damage: "));
            claim.DateOfIncident = DateTime.Parse(Prompt("Date of Incident: "));
            claim.DateOfClaim = DateTime.Parse(Prompt("Date of Claim: "));

            claims.Enqueue(claim);
        }
        public void Run() {
            isMenuRunning = true;

            while (isMenuRunning) {
                DrawMenu();
                OnKeyPress(Console.ReadKey());
            }
        }
    }
}
