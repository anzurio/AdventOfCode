using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Day03
{
    public class Fabric
    {
        private List<int> ClaimIds = new List<int>();
        private List<Claim>[,] Claims = new List<Claim>[1000,1000];

        public Fabric()
        {
            Claims = new List<Claim>[1001, 1001];
        }

        public void Add(Claim claim)
        {
            ClaimIds.Add(claim.Id);
            for (int i = claim.Left; i < claim.Left + claim.Width; i++)
            {
                for (int j = claim.Top; j < claim.Top + claim.Height; j++)
                {
                    Add(i, j, claim);
                }
            }
        }

        private void Add(int left, int top, Claim claim)
        {
            if (Claims[left, top] == null)
            {
                Claims[left, top] = new List<Claim>();
            }
            Claims[left, top].Add(claim);
        }

        public int GetOverlappedSquareInches()
        {
            int overlappedSquareInches = 0;
            foreach (var claimsInSquareInch in Claims)
            {
                if (claimsInSquareInch != null && claimsInSquareInch.Count > 1)
                {
                    overlappedSquareInches++;
                }
            }
            return overlappedSquareInches;
        }

        public int GetUnoverlappingClaim()
        {
            HashSet<int> overlappingClaims = new HashSet<int>();

            foreach (var claimsInSquareInch in Claims)
            {
                if (claimsInSquareInch != null && claimsInSquareInch.Count > 1)
                {
                    foreach(var claim in claimsInSquareInch)
                    {
                        overlappingClaims.Add(claim.Id);
                    }
                }
            }
            ClaimIds.RemoveAll(x => overlappingClaims.Contains(x));

            return ClaimIds.First();
        }
    }
}
