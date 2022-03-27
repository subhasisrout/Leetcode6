using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Sequence of steps
 *	1. Get their depths
 *	2. Bring the lower node to upper one (i.e Get them to the same level)
 *	3. Lift both of them up, until their ancestor is SAME.
 *			4. Two edge cases - when one of them is the ROOT ancestor, when one is the descendant of other.
 */

namespace Leetcode
{
    public class YoungestCommonAncestorAE
    {
		public static AncestralTree GetYoungestCommonAncestor(
		AncestralTree topAncestor,
		AncestralTree descendantOne,
		AncestralTree descendantTwo
		)
		{
			if (descendantOne == topAncestor || descendantTwo == topAncestor) //edge case when one of them is the ROOT ancestor.
				return topAncestor;
			int depthDescendant1 = 0;
			AncestralTree curr = descendantOne;
			while (curr.ancestor != null)
			{
				depthDescendant1++;
				curr = curr.ancestor;
			}

			int depthDescendant2 = 0;
			curr = descendantTwo;
			while (curr.ancestor != null)
			{
				depthDescendant2++;
				curr = curr.ancestor;
			}
			// up till here we have got their depths.


			if (depthDescendant1 > depthDescendant2)
			{
				for (int i = 0; i < (depthDescendant1 - depthDescendant2); i++)
					descendantOne = descendantOne.ancestor;
			}
			else
			{
				for (int i = 0; i < (depthDescendant2 - depthDescendant1); i++)
					descendantTwo = descendantTwo.ancestor;
			}
			// up till there we have got them to the same level/depth

			if (descendantOne == descendantTwo) return descendantOne; //edge when descendantOne or Two itself is the ancestor.

			while (descendantOne.ancestor != descendantTwo.ancestor)
			{
				descendantOne = descendantOne.ancestor;
				descendantTwo = descendantTwo.ancestor;
			}

			return descendantOne.ancestor; // or descendantTwo.ancestor;
		}

		public class AncestralTree
		{
			public char name;
			public AncestralTree ancestor;

			public AncestralTree(char name)
			{
				this.name = name;
				this.ancestor = null;
			}

			// This method is for testing only.
			public void AddAsAncestor(AncestralTree[] descendants)
			{
				foreach (AncestralTree descendant in descendants)
				{
					descendant.ancestor = this;
				}
			}
		}
	}
}
