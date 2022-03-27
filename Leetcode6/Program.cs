using Leetcode.SampleEntities;
using PriorityQueueFromCodeProject;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonOA amazonOA = new AmazonOA();
            var result = amazonOA.findTotalImbalance(new List<int> { 4, 1, 3, 2 });


            //NQueensILC51 nQueensILC51 = new NQueensILC51();
            //nQueensILC51.SolveNQueens(4);

            //RemoveCoveredIntervalsLC1288 removeCoveredIntervalsLC1288 = new RemoveCoveredIntervalsLC1288();
            //removeCoveredIntervalsLC1288.RemoveCoveredIntervals(new int[][]{
            //new int[] {34, 39},
            //new int[] {15, 91},
            //new int[] {29, 66},
            //new int[] {53, 69},
            //new int[] {40, 93}
            //});

            //RemoveKDigitsLC402 removeKDigitsLC402 = new RemoveKDigitsLC402();
            //var x = removeKDigitsLC402.RemoveKdigits("1234567890", 9);

            //OAMaxNumOfNonIntersectingSegmentsOfLen2OfEqualSum maxNumOfNonIntersectingSegmentsOfLen2OfEqualSum = new OAMaxNumOfNonIntersectingSegmentsOfLen2OfEqualSum();
            //var x1 = maxNumOfNonIntersectingSegmentsOfLen2OfEqualSum.Solution(new int[] { 10, 1, 3, 1, 2, 2, 1, 0, 4 });
            //var x2 = maxNumOfNonIntersectingSegmentsOfLen2OfEqualSum.Solution(new int[] { 5,3,1,3,2,3 });
            //var x3 = maxNumOfNonIntersectingSegmentsOfLen2OfEqualSum.Solution(new int[] { 9,9,9,9,9 });
            //var x4 = maxNumOfNonIntersectingSegmentsOfLen2OfEqualSum.Solution(new int[] { 1,2 });

            //MinimumAreaRectangleLC939 minimumAreaRectangleLC939 = new MinimumAreaRectangleLC939();
            //minimumAreaRectangleLC939.MinAreaRect(new int[][]
            //{
            //    new int[]{1,1},
            //    new int[]{1,3},
            //    new int[]{3,1},
            //    new int[]{3,3},
            //    new int[]{2,2}
            //});

            //NextPermutationLC31 nextPermutationLC31 = new NextPermutationLC31();
            //nextPermutationLC31.NextPermutation(new int[] { 5, 4, 7, 5, 3, 2 });
            //AllPathsFromSourceToTargetLC797 allPathsFromSourceToTargetLC797 = new AllPathsFromSourceToTargetLC797();
            //allPathsFromSourceToTargetLC797.AllPathsSourceTarget(new int[4][] {
            //new int[]{1,2},
            //new int[]{3},
            //new int[]{3},
            //new int[]{}
            //});

            //SmallestLetterGreaterThanTarget smallestLetterGreaterThanTarget = new SmallestLetterGreaterThanTarget();
            //smallestLetterGreaterThanTarget.NextGreatestLetter(new char[] {'e','e', 'e', 'e', 'e', 'e','n', 'n', 'n', 'n'}, 'e');

            // MedianOfTwoSortedArrays medianOfTwoSortedArrays = new MedianOfTwoSortedArrays();
            // medianOfTwoSortedArrays.FindMedianSortedArrays(new[] { 1, 2 }, new int[] { 3, 4 });

            // CoinChangeLC322 coinChangeLC322 = new CoinChangeLC322();
            // var coins = coinChangeLC322.CoinChange(new int[] { 3 }, 2);

            //var x12 = NumberOfWaysToMakeChangeLE.NumberOfWaysToMakeChange(10, new int[] { 25, 1, 5, 10 });

            // FindTheTownJudgeLC997 findTheTownJudgeLC997 = new FindTheTownJudgeLC997();
            // findTheTownJudgeLC997.FindJudge(2, new int[][] { new int[] { 1, 2 } });

            //PacificAtlanticWaterflowLC417 pacificAtlanticWaterflowLC417 = new PacificAtlanticWaterflowLC417();
            //pacificAtlanticWaterflowLC417.PacificAtlantic(new int[][]
            //{
            //    new int[] {1,2,2,3,5 },
            //    new int[] {3, 2, 3, 4, 4},
            //    new int[] { 2, 4, 5, 3, 1},
            //    new int[] {6, 7, 1, 4, 5},
            //    new int[] {5, 1, 1, 2, 4}
            //});

            //CodeChefSHROUTE codeChefSHROUTE = new CodeChefSHROUTE();
            //codeChefSHROUTE.GetTime(new int[] { 2, 0, 0, 0, 1 }, 0);



            //HouseRobberLC213 houseRobberLC213 = new HouseRobberLC213();
            //houseRobberLC213.Rob(new int[] {1,2,3,1});

            //PowLC50 powLC50 = new PowLC50();
            //var x = powLC50.MyPow(2.0, -2147483648);

            //RandomizedSet randomizedSet = new RandomizedSet();
            //randomizedSet.Remove(0);
            //randomizedSet.Remove(0);
            //randomizedSet.Insert(0);
            //var x = randomizedSet.GetRandom();
            //randomizedSet.Remove(0);
            //randomizedSet.Insert(0);



            //MinimumPassesOfMatrixAE minimumPassesOfMatrixAE = new MinimumPassesOfMatrixAE();
            //minimumPassesOfMatrixAE.MinimumPassesOfMatrix(new int[][] { new int[] { 0, -1, -3, 2, 0 }, new int[] { 1, -2, -5, -1, -3 }, new int[] { 3, 0, 0, -4, -1 } });

            //InterweavingStringsAE.Interweavingstrings("algoexpert", "your-dream-job", "your-algodream-expertjob");

            //LastStoneWeightLC1046 lastStoneWeightLC1046 = new LastStoneWeightLC1046();
            //lastStoneWeightLC1046.LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 });

            //CanCompleteCircuitLC134 canCompleteCircuitLC134 = new CanCompleteCircuitLC134();
            //canCompleteCircuitLC134.CanCompleteCircuit(new[] { 5,1,2,3,4 }, new int[] { 4,4,1,5,1 });

            //SubArraySortAE.SubarraySort(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 });

            //List<List<int>> arrays = new List<List<int>>()
            //{
            //    new List<int>(){1,5,9,21},
            //    new List<int>(){-1,0},
            //    new List<int>(){-124,81,121},
            //    new List<int>(){3,6,12,20,150},
            //};
            //Leetcode3.MergeKSortedArraysAE.MergeSortedArrays(arrays);

            //FindAllDuplicatesInArrayLC442 findAllDuplicatesInArrayLC442 = new FindAllDuplicatesInArrayLC442();
            //var result = findAllDuplicatesInArrayLC442.FindDuplicates(new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 });

            // NumberOfWaysToTraverseGraphAE numberOfWaysToTraverseGraphAE = new NumberOfWaysToTraverseGraphAE();
            // var result = numberOfWaysToTraverseGraphAE.NumberOfWaysToTraverseGraph(3,4);

            //var result = FourNumberSumAE.FourNumberSum(new int[] { -2, -1, -1, 1, 1, 2, 2 }, 0);

            // var result = FourNumberSumAE.FourNumberSum(new int[] { 7, 6, 4, -1, 1, 2 }, 16);

            //FindPivotInShiftedSortedArray findPivotInShiftedSorted = new FindPivotInShiftedSortedArray();
            //var pivot = findPivotInShiftedSorted.FindPivot(new int[] { 1, 2, 3 });

            //ValidIPAddressesAE validIPAddressesAE = new ValidIPAddressesAE();
            //var result = validIPAddressesAE.ValidIPAddresses("0279245587303");

            //int[] selectionSortedNumsAE = SelectionSortAE.SelectionSort(new int[] {8, 5, 2, 9, 5, 6, 3 });
            //int[] insertionSortedNumsAE = InsertionSortAE.InsertionSort(new int[] { 8, 5, 2, 9, 5, 6, 3 });

            //var s = LongestPalindromicSubStringAE.LongestPalindromicSubstring("babad");

            //HasSingleCycleAE hasSingleCycleAE = new HasSingleCycleAE();
            //hasSingleCycleAE.HasSingleCycle(new int[] { 1, 2, 3, 4, -2, 3, 7, 8, -26 });


            //ProductSumAE productSumAE = new ProductSumAE();
            //productSumAE.ProductSum(new List<object>() { 5, 2, new List<object>() {7, -1 }, 3, });

            //FirstDuplicateAE firstDuplicateAE = new FirstDuplicateAE();
            //firstDuplicateAE.FirstDuplicateValue(new int[] { 2, 1, 5, 2, 3, 3, 4 });

            //PermutationsLC46AE permutationsLC46AE = new PermutationsLC46AE();
            //permutationsLC46AE.Permute(new int[] { 1, 2, 3 });

            //ThreeNumSumLC15 threeNumSumLC15 = new ThreeNumSumLC15();
            //threeNumSumLC15.ThreeSum(new int[] { 0, 0, 0 });

            //DetermineIfStringsAreCloseLC1657 determineIfStringsAreCloseLC1657 = new DetermineIfStringsAreCloseLC1657();
            //determineIfStringsAreCloseLC1657.CloseStrings("a", "aa");

            // FindCommonCharsLC1002 findCommonCharsLC1002 = new FindCommonCharsLC1002();
            // findCommonCharsLC1002.CommonChars(new string[] { "bella", "label","roller" });

            // PermutationOfCharsUsingCase permutationOfCharsUsingCase = new PermutationOfCharsUsingCase();
            // var result = permutationOfCharsUsingCase.Permutations("abc");

            //PrintFooBarAlternatelyLC1115 printFooBarAlternatelyLC1115 = new PrintFooBarAlternatelyLC1115(5);
            //Thread t1 = new Thread(() => printFooBarAlternatelyLC1115.Foo(() => { Console.WriteLine("Foo"); }));
            //Thread t2 = new Thread(() => printFooBarAlternatelyLC1115.Bar(() => { Console.WriteLine("Bar"); }));
            //t1.Start();
            //t2.Start();


            //MaximumBinaryTreeLC654 maximumBinaryTreeLC654 = new MaximumBinaryTreeLC654();
            //maximumBinaryTreeLC654.ConstructMaximumBinaryTree(new int[] { 1, 3, 2 });

            //CountNumberOfTeamsLC1395 countNumberOfTeamsLC1395 = new CountNumberOfTeamsLC1395();
            //var x = countNumberOfTeamsLC1395.NumTeams(new int[] { 1,2,3,4 });

            // ContiguousArrayLC525 contiguousArrayLC525 = new ContiguousArrayLC525();
            // var result = contiguousArrayLC525.FindMaxLength(new int[] { 0, 0, 1, 0, 0, 0, 1, 1 });


            //ThirdMaxO_of_N_LC414 thirdMaxO_Of_N_LC414 = new ThirdMaxO_of_N_LC414();
            //var x = thirdMaxO_Of_N_LC414.ThirdMax(new int[] { 1, 2 });

            //SortedSquaresLC977 sortedSquaresLC977 = new SortedSquaresLC977();
            //var x = sortedSquaresLC977.SortedSquares(new int[] { -1, 2, 2 });

            //RemoveDuplicateLettersLC316 removeDuplicateLettersLC316 = new RemoveDuplicateLettersLC316();
            //var x= removeDuplicateLettersLC316.RemoveDuplicateLetters("aaabbbcccddd");

            //MaxConsecutiveOnesLC485 maxConsecutiveOnesLC485 = new MaxConsecutiveOnesLC485();
            //maxConsecutiveOnesLC485.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 });


            //            CountServersThatCommunicateLC1267 countServersThatCommunicateLC1267 = new CountServersThatCommunicateLC1267();
            //            int[][] jaggedArray =
            //{
            //    new int[] { 1,0 },
            //    new int[] { 0,1 }
            //};
            //countServersThatCommunicateLC1267.CountServers(jaggedArray);

            //DesignTwitterLC355 designTwitterLC355 = new DesignTwitterLC355();
            //designTwitterLC355.PostTweet(1, 1);
            //var newsFeed1 = designTwitterLC355.GetNewsFeed(1);
            //designTwitterLC355.Follow(2, 1);           
            //var newsFeed2 = designTwitterLC355.GetNewsFeed(2);
            //designTwitterLC355.Unfollow(1, 2);
            //newsFeed2 = designTwitterLC355.GetNewsFeed(2);


            // DFSInArrayGeneral dFSInArrayGeneral = new DFSInArrayGeneral();
            // dFSInArrayGeneral.Subsets(new int[] {1,2,3 });
            // dFSInArrayGeneral.SubsetsChar(new char[] {'a','b','c' });

            //StringCompressionLC443 stringCompressionLC443 = new StringCompressionLC443();
            //stringCompressionLC443.Compress(new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' });

            // ValidateParenthesisLC20 validateParenthesisLC20 = new ValidateParenthesisLC20();
            // validateParenthesisLC20.IsValid('()[]{}");

            // FindTheDifferenceLC389 findTheDifferenceLC389 = new FindTheDifferenceLC389();
            // findTheDifferenceLC389.FindTheDifference("abcd", "abcde");

            //Console.WriteLine((char)('a' + 4));

            // ClimbStairsLC70 climbStairsLC70 = new ClimbStairsLC70();
            // int result = climbStairsLC70.ClimbStairs(4);

            //LettersCombinationLC17 lettersCombinationLC17 = new LettersCombinationLC17();
            //var result = lettersCombinationLC17.LetterCombinations("279");

            //BinaryNumWithAltBitsLC693 binaryNumWithAltBitsLC693 = new BinaryNumWithAltBitsLC693();
            //binaryNumWithAltBitsLC693.HasAlternatingBits(6);

            //ValidPalindromeLC125 validPalindromeLC125 = new ValidPalindromeLC125();
            //validPalindromeLC125.IsPalindrome("A man, a plan, a canal: Panama");

            // RemoveDuplicatesFromSortedArrayLC26 removeDuplicatesFromSortedArrayLC26 = new RemoveDuplicatesFromSortedArrayLC26();
            // removeDuplicatesFromSortedArrayLC26.RemoveDuplicates(new int[] {1,1 });

            //AddBinaryLC67 addBinaryLC67 = new AddBinaryLC67();
            //string res = addBinaryLC67.AddBinary("11", "1");

            //int[][] points = new int[3][];
            //points[0] = new int[] { 3, 3 };
            //points[1] = new int[] { 5, -1 };
            //points[2] = new int[] { -2, 4 };
            //KClosestPointsToOriginLC973 kClosestPointsToOriginLC973 = new KClosestPointsToOriginLC973();
            //kClosestPointsToOriginLC973.KClosest(points, 2);


            //ListNode list1 = new ListNode(1);
            //list1.next = new ListNode(4);
            //list1.next.next = new ListNode(5);

            //ListNode list2 = new ListNode(1);
            //list2.next = new ListNode(3);
            //list2.next.next = new ListNode(4);

            //ListNode list3 = new ListNode(2);
            //list3.next = new ListNode(6);

            //MergeKSortedListLC23 mergeKSortedListLC23 = new MergeKSortedListLC23();
            //mergeKSortedListLC23.MergeKLists(new ListNode[] { list1, list2, list3 });



            //HouseRobberLC198 houseRobberLC198 = new HouseRobberLC198();
            //var x = houseRobberLC198.Rob(new int[] { 2,3,2 });

            //HappyNumberLC202 happyNumberLC202 = new HappyNumberLC202();
            //Console.WriteLine(happyNumberLC202.IsHappy(19));

            //SortArrayByParityLC905 sortArrayByParityLC905 = new SortArrayByParityLC905();
            //var res = sortArrayByParityLC905.SortArrayByParity2(new int[] { 3, 1, 2, 4 });

            //CountPrimesLC204 countPrimesLC204 = new CountPrimesLC204();           

            //PartitionLabelsLC763 partitionLabelsLC763 = new PartitionLabelsLC763();
            //var result = partitionLabelsLC763.PartitionLabels("ababcbacadefegdehijhklij");

            //LongestCommonPrefixLC14 longestCommonPrefixLC14 = new LongestCommonPrefixLC14();
            //var res = longestCommonPrefixLC14.LongestCommonPrefix(new string[] { "flower", "flow", "flight" });

            //PartitionEqualSubsetSumLC416 partitionEqualSubsetSumLC416 = new PartitionEqualSubsetSumLC416();
            //Console.WriteLine(partitionEqualSubsetSumLC416.CanPartition(new int[] { 1, 5, 5, 11, 8, 2, 6, 2, 1, 1, }));

            //RepeatedDNASequencesLC187 repeatedDNASequencesLC187 = new RepeatedDNASequencesLC187();
            //var retVal = repeatedDNASequencesLC187.FindRepeatedDnaSequences("AAAAAAAAAAA");

            //ListNode headA = new ListNode(1);
            //headA.next = new ListNode(2);
            //headA.next.next = new ListNode(4);
            //headA.next.next.next = new ListNode(4);
            //headA.next.next.next.next = new ListNode(5);

            //ListNode headB = new ListNode(1);
            //headB.next = new ListNode(3);
            //headB.next.next = new ListNode(4);
            //headB.next.next.next = headA.next.next;
            //headB.next.next.next.next = headA.next.next.next;
            //headB.next.next.next.next.next = headA.next.next.next.next;

            //ListNode headA = new ListNode(3);
            //ListNode headB = new ListNode(2);
            //headB.next = headA;

            //MergeSortedListLC21 mergeSortedListLC21 = new MergeSortedListLC21();
            //var res = mergeSortedListLC21.MergeTwoLists(headA, headB);

            //IntersectionOfTwoLinkedListLC160 intersectionOfTwoLinkedListLC160 = new IntersectionOfTwoLinkedListLC160();
            //var intersectionNode = intersectionOfTwoLinkedListLC160.GetIntersectionNode(headA, headB);

            //MinCostToConnectSticksLC1167Premium minCostToConnectSticksLC1167Premium = new MinCostToConnectSticksLC1167Premium();
            //var result = minCostToConnectSticksLC1167Premium.ConnectSticks(new int[] {1,8,3,5});

            //AddStringsLC415 addStringsLC415 = new AddStringsLC415();
            //var result = addStringsLC415.AddStrings("1", "9");

            //BagofTokensLC948 bagofTokensLC948 = new BagofTokensLC948();
            //var output = bagofTokensLC948.BagOfTokensScore(new int[] {100, 200 }, 150);

            //ReorganizeStringLC767 reorganizeStringLC767 = new ReorganizeStringLC767();
            //var res = reorganizeStringLC767.ReorganizeString("aaab");

            //PriorityQueue<Employee,Employee> maxHeap = new PriorityQueue<Employee,Employee>(EmployeeUtils.GetEmployees(), new EmployeeComparer());
            //var x = maxHeap.DequeueValue();

            //MinimumDominoRotationLC1007 minimumDominoRotationLC1007 = new MinimumDominoRotationLC1007();
            //var result = minimumDominoRotationLC1007.MinDominoRotations(new int[] { 1,2,3,4,6 }, new int[] { 6,6,6,6,5 });

            //VerifyAlienDictionaryLC953 verifyAlienDictionaryLC953 = new VerifyAlienDictionaryLC953();
            //bool result = verifyAlienDictionaryLC953.IsAlienSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");

            //LargestValuesFromLabelLC1090 largestValuesFromLabelLC1090 = new LargestValuesFromLabelLC1090();
            //var r = largestValuesFromLabelLC1090.LargestValsFromLabels(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 1, 2, 2, 3 }, 3, 1);

            //GroupAnagramsLC49 groupAnagramsLC49 = new GroupAnagramsLC49();
            //var tmp = groupAnagramsLC49.GroupAnagrams(new string[] {"ate","eat","abc","tea","ball","bat","tab" });

            //ValidAnagramLC242 validAnagramLC242 = new ValidAnagramLC242();
            //Console.WriteLine(validAnagramLC242.IsAnagram("eat","ate"));


            //int[][] jaggedArray = new int[1][];
            //jaggedArray[0] = new int[] { 1, 2 };

            //RottingOrangesLC994 rottingOrangesLC994 = new RottingOrangesLC994();
            //rottingOrangesLC994.OrangesRotting(jaggedArray);

            //AsteroidCollisionLC735 asteroidCollisionLC735 = new AsteroidCollisionLC735();
            //var asteriodCollisionOutput = asteroidCollisionLC735.AsteroidCollision(new int[] { -2,-2,-2,-2 });

            //ValidPalindrome2LC680 validPalindrome2LC680 = new ValidPalindrome2LC680();
            //Console.WriteLine(validPalindrome2LC680.ValidPalindrome("abca"));
            //MissingNumInArrayLC448 missingNumInArrayLC448 = new MissingNumInArrayLC448();
            //var results = missingNumInArrayLC448.FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });


            //SingleNumberXORLC136 singleNumberXORLC136 = new SingleNumberXORLC136();
            //Console.WriteLine(singleNumberXORLC136.SingleNumber(new int[] {1,2,1,2,9 }));

            //LastStoneWeightLC1046 lastStoneWeightLC1046 = new LastStoneWeightLC1046();
            //Console.WriteLine(lastStoneWeightLC1046.LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 }));

            //                  20
            //          10               30
            //      4       12       21      50
            //                           45      55
            //TreeNode root = new TreeNode(20);
            //root.left = new TreeNode(10);
            //root.right = new TreeNode(30);

            //root.left.left = new TreeNode(4);
            //root.left.right = new TreeNode(12);

            //root.right.left = new TreeNode(21);
            //root.right.right = new TreeNode(50);

            //root.right.right.left = new TreeNode(45);
            //root.right.right.right = new TreeNode(55);

            //BSTRightSideViewLC199 bSTRightSideViewLC199 = new BSTRightSideViewLC199();
            //bSTRightSideViewLC199.RightSideView(root);

            //ValidateBSTLC98 validateBSTLC98 = new ValidateBSTLC98();
            //Console.WriteLine(validateBSTLC98.IsValidBST(root));

            //BinaryTreePathsLC257 binaryTreePathsLC257 = new BinaryTreePathsLC257();
            //var binaryTreePaths = binaryTreePathsLC257.BinaryTreePaths(root);
            //KthSmallestInBSTLeetcode230 kthSmallestInBSTLeetcode230 = new KthSmallestInBSTLeetcode230();
            //Console.WriteLine(kthSmallestInBSTLeetcode230.KthSmallest(root, 3));

            //KthSmallestInBSTLeetcode230 obj1 = new KthSmallestInBSTLeetcode230();
            //Console.WriteLine(obj1.FindMin(root));



            //ReverseOnlyLetterLeetcode917 reverseOnlyLetterLeetcode917 = new ReverseOnlyLetterLeetcode917();
            //Console.WriteLine(reverseOnlyLetterLeetcode917.ReverseOnlyLetters("s-ub-has-is"));

            //LRUCache.LRUCacheLeetCode146 lruCache = new LRUCache.LRUCacheLeetCode146(3);
            //lruCache.Put(1, 1);
            //lruCache.Put(2, 2);
            //lruCache.Put(3, 3);
            //lruCache.Put(2, 22);
            //lruCache.Print();

            //SortCharByFreqLeetcode451 sortCharByFreqLeetcode451 = new SortCharByFreqLeetcode451();
            //Console.WriteLine(sortCharByFreqLeetcode451.FrequencySort("subhasisrout"));

            //char[,] board = new char[,] {
            //{ 'A', 'B', 'C', 'E' },
            //{ 'S', 'F', 'C', 'S' },
            //{ 'A', 'D', 'E', 'E' }
            //};
            //WordsearchLC79 wordsearchLC79 = new WordsearchLC79();
            //Console.WriteLine(wordsearchLC79.Exist(board, "ABCCED"));

            //int[] groupSizes = { 2,1,3,3,3,2};
            //var res = GroupThePeople(groupSizes);

            //int[] arr = { 3, 7, 10, 11, 45, 78, 90, 110, 120, 130, 1000, 9999 };
            //Console.WriteLine(BinarySearch(arr, 130));

            //Console.WriteLine(NumberOfSteps(1));

            //https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/submissions/
            //concept of using more spaces and increasing runtime performance (frequency array, greaterThan array)
            //int[] nums = { 8,1,2,2,3 };

            //int[] freqArr = new int[101];
            //int[] gtArr = new int[101];
            //int[] resultsArr = new int[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    freqArr[nums[i]] = freqArr[nums[i]] + 1;
            //}
            //for (int i = 1; i < 101; i++)
            //{
            //    gtArr[i] = gtArr[i-1] + freqArr[i-1];
            //}
            //for (int i = 0; i < resultsArr.Length; i++)
            //{
            //    resultsArr[i] = gtArr[nums[i]];
            //}

            //int[] resultArr = new int[nums.Length];

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int numberToBeCompared = nums[i];
            //    int result = 0;
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        if (i != j && numberToBeCompared > nums[j])
            //            result++;
            //    }
            //    resultArr[i] = result;
            //}
            //Dictionary<int, List<int>> dictPosition = new Dictionary<int, List<int>>();
            //for (int i = 0; i < nums.Length ; i++)
            //{
            //    if (!dictPosition.ContainsKey(nums[i]))
            //    {
            //        dictPosition.Add(nums[i], new List<int> { i });
            //    }
            //    else
            //    {
            //        dictPosition[nums[i]].Add(i);
            //    }

            //}

            //quickSort(nums, 0, nums.Length - 1);

            //int[] arr2 = new int[nums.Length];

            //for (int i = 0; i < nums.Length ; i++)
            //{
            //    if (i == 0)
            //        arr2[i] = 0;
            //    else
            //    {
            //        if (nums[i] == nums[i-1])
            //        {
            //            arr2[i] = arr2[i - 1];
            //        }
            //        else
            //        {
            //            arr2[i] = i;
            //        }
            //    }
            //}

            //int[] arr3 = new int[nums.Length];

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    //get position
            //    int positionfinder = nums[i];
            //    List<int> actualpositions = dictPosition[positionfinder];

            //    foreach (var actualposition in actualpositions)
            //    {
            //        arr3[actualposition] = arr2[i];
            //    }

            //}





        }

        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!dict.ContainsKey(groupSizes[i]))
                    dict.Add(groupSizes[i], new List<int> { i });
                else
                    dict[groupSizes[i]].Add(i);
            }


            foreach (var item in dict)
            {
                int grpSize = item.Key;
                List<int> grpMembers = item.Value;
                List<int> innerList = new List<int>();
                int counter = 0;
                foreach (var member in grpMembers)
                {
                    innerList.Add(member);
                    counter++;
                    if (counter == grpSize)
                    {
                        res.Add(innerList);
                        innerList = new List<int>();
                        counter = 0;
                    }
                }
            }


            return res;
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                        return new int[] { i, j };
                }
            }
            return new int[] { -1, -1 };
        }

        static int BinarySearch(int[] arr, int num)
        {
            int left = 0;
            int right = arr.Length;

            while (left < right - 1)
            {
                int mid = (left + right) / 2;

                if (num == arr[mid])
                    return mid;
                if (num > arr[mid])
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
            return -1;

        }

        public static int NumberOfSteps(int num)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return 1;

            if (num % 2 == 0)
                return 1 + NumberOfSteps(num / 2);
            else
                return 1 + NumberOfSteps(num - 1);
        }

        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = qs_partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        static int qs_partition(int[] arr, int low,
                                   int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
}