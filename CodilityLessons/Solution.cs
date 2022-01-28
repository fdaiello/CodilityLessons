namespace CodilityLessons
{
    public class Solution
    {
        public int BinaryGap(int n) {

            // String with number formated to binary
            string s = Convert.ToString(n,2);

            // Loop string
            int c1 = 0;
            int c2 = 0;
            char last = '0';
            for ( int x=0; x<s.Length; x++)
            {
                if (s[x]=='0' && last == '1')
                {
                    c2++;
                }
                else if (s[x]=='1' && last == '0')
                {
                    c1 = Math.Max(c1, c2);
                    c2 = 0;
                }
                else if (s[x] == '0' && last == '0')
                {
                    c2++;
                }
                last = s[x];
            }

            return c1;
        }
        public int[] ArrayRotation(int[] A, int K)
        {
            // Check for empty array
            if ( A.Length==0)
                return new int[0];

            // Convert array to List
            List<int> list = new List<int>(A);

            // Loop K times
            for (int i=1; i<=K; i++)
            {
                // Shift the array to the right
                list.Insert(0, list[list.Count - 1]);
                list.RemoveAt(list.Count - 1);
            }

            // Return list 
            return list.ToArray();

        }

        /*
         * Given an Array of Integers, with odd number of elements
         * Find the value of the unique element that is unpaired - ocur only once
         */
        public int ArrayUnpairedElement(int[] A)
        {
            // If array has only one element
            if (A.Length==1)
                return A[0];

            // Sort the array
            Array.Sort(A);

            // Loop the array 2 by 2, up to last but one
            for ( int x=0; x<A.Length-1; x = x + 2)
            {
                if (A[x] != A[x + 1])
                    return A[x];
            }

            // Last element is unpaired
            return A[A.Length-1];
        }

        /*
         * Return how many steps is need to take to get from x to y, when each step runs D positions
         */
        public static int FrogJumps(int X, int Y, int D)
        {
            int jumps = (Y-X) / D;
            if ((Y-X) % D != 0)
                jumps++;
            return jumps;
        }

        /*
         * Array A of N elements contains a sequence of number, starting at 1, up to N+1
         * One number is is missing
         * Return the missing number
         */
        public static int ArrayMissingElement(int[] A)
        {

            if (A.Length == 0)
                return 1;

            Array.Sort(A);

            for ( int i=0; i < A.Length; i++)
            {
                if (A[i] != i + 1)
                    return i + 1;
            }

            return A.Length+1;
        }
        /*
         * Given one Array of integers
         * Return the index of the array, that points to an element that cuts the array with minimum difference when comparing the sums of both segments
         */
        public static int MinDifferenceOfSplittedArray(int[] A)
        {
            // Sum the values of each segment
            int s1 = A[0];
            int s2 = A.Sum() - s1;

            // Minimum difference found
            int minDif = Math.Abs(s2 - s1);

            // Loop the array from second element
            for ( int x=1; x<A.Length-1;x++)
            {
                // Update sums of each segment
                s1 += A[x];
                s2 -= A[x];

                // Check differences of this segment
                if ( Math.Abs(s2-s1 ) < minDif)
                {
                    minDif = Math.Abs(s2- s1);
                }
            }

            return minDif;
        }

        /*
         *  return the lowest index of A where A[0] to A[y] fills all integers from 1 to  X
         */ 
        public static int FroggerJump(int X, int[] A)
        {
            // Store positions to be filled
            int[] arr = new int[X+1];

            // Positions filled
            int p = 0;

            // Loop the array A
            for ( int y=0; y<A.Length; y++ )
            {
                // If this position was not filled yet
                if (arr[A[y]] == 0)
                    // Sum counter
                    p++;

                // Mark position as filled
                arr[A[y]] = 1;

                // Check if all positions are filled
                if (p == X)
                    return y;
            }

            return -1;

        }
        /*
         * Return 1 if array A is a permutation of sequence from 1 to N - where N is A.lenght
         * Else return 0
         */
        public static int IsPermutationSequence(int[] A)
        {
            // Lets start sorting A
            Array.Sort(A);

            // Lets Loop the array and check if sequence matches
            for ( int x=0; x<A.Length; x++)
            {
                // Compare index with its value
                if (A[x] != x + 1)
                    return 0;
            }

            // if we got here, array A has a sequence from 1 to A.length
            return 1;
        }

        /* 
         *    Create N counters
         *    Process each element of array A - each element is a command to process on counters
         *    If A[x] <= N; increase counter A[x]
         *    If A[x] > N; set all counters to value of max counter
         *    return array of counters
         */
        public static int[] ProcessCounters(int N, int[] A)
        {
            // array of counters
            int[] counters = new int[N];

            // save max counter - so we wont need to check each time
            int max = 0;
            int max2 = 0;

            // loop array with "commands"
            for ( int x = 0; x < A.Length; x++)
            {
                // Check what is the command
                if ( A[x] <= N)
                {
                    // Increase counter A[x]
                    counters[A[x] - 1]++;

                    // Save max value
                    max = Math.Max(max, counters[A[x] - 1]);

                }
                else
                {
                    // Only set to max if max has changed
                    if (max2 < max)
                    {
                        // Set all counters to max
                        for (int y = 0; y < N; y++)
                        {
                            counters[y] = max;
                        }

                        // So we wont enter loop if max hasn't changed
                        max2 = max;
                    }
                }
            }

            return counters;
        }

        /*
         * returns the smallest positive integer (greater than 0) that does not occur in A.
         */
        public static int MinMissingPositiveNumber(int[] A)
        {
            // Sort the array
            Array.Sort(A);

            // If all numbers are negative or zero, or if first element is greater than 1, return 1
            if (A[A.Length-1] <= 0 || A[0]>1)
            {
                return 1;
            }

            // delta index from where to search
            int d = 0;

            // If array start with zero or negative numbers
            if (A[0] < 1)
            {
                // Serach position of number 1 element, or first positive number
                for (int x = 0; x < A.Length; x++)
                {
                    // Check if found number greater than 1
                    if ( A[x] > 1)
                    {
                        // 1 is missing;
                        return 1;
                    }
                    // If we found 1
                    else if (A[x] == 1){
                        // Save position of number 1
                        d = x;
                        break;
                    }
                }
            }

            // Now lets loop positive numbers, checking the sequence
            int i = 0;
            for ( int x = d; x<A.Length; x++)
            {
                // Check if number is out of sequence
                if (A[x] > i+1)
                    return i+1;
                else if (A[x] > i)
                    i++;
            }

            // If we got here, we have a sequence to the end. Return last element +1
            return A[A.Length - 1] + 1;

        }
        /*
         * Passing Cars
         *   A represent cars on a road ( supose you are seeing the road from above )
         *   Each element in the array represents a car.
         *   Elements can be 0 or 1.
         *      0 - represents car going East
         *      1 - represents car going West
         *   Return the total number of "passing cars" - each time one car cross the car coming from the other side
         *   
         *   Note: we may pick one number and count the passage from the other number.
         *   
         *   Simple aproach:
         *       Loop all elements at the array, search for zeros, if its a zero
         *          Loop all SUBSEQUENT elements of the array
         *               If its 1, increase passing cars count
         *               
         *   Optimizes approach with prefix sums
         *       Loop all elements at the array
         *              ???
         */
        public static int PassingCars(int[] A)
        {
            // Length constraint
            if (A.Length < 2)
                return 0;

            // Search first zero - up to last but one
            int p1 = 0;
            for ( int x = 0; x< A.Length-1; x++)
            {
                if (A[x] == 0)
                {
                    p1 = x;
                    break;
                }
                else if (x == A.Length - 1)
                    return 0;
            }

            int sum = 0;
            int zeros = 0;

            // Loop the array, starting at first element that is zero
            for ( int x = p1; x< A.Length; x++)
            {
                if ( A[x] == 0)
                {
                    zeros++;
                }
                else
                {
                    sum += zeros;
                    if (sum > 1000000000)
                        return -1;
                }
            }

            return sum;
        }
        /*
         * Return the number of integers, between A and B
         * That are multiples of K - divide by K with rest = 0
         */
        public static int NumberOfMultiplesWithinRange(int A, int B, int K)
        {
            int b = B / K;
            int a = A > 0 ? (A - 1) / K : 0;
            if (A == 0)
            {
                b++;
            }
            return b - a;
        }
        /*
         * Dna Sequence
         *   input - string s representing a sequence of DNA with letters A C G or T with values 1 2 3 4
         *   P, Q - array with queries
         *   output - array with response to queries
         *   
         *   For each element of P and Q, return the lower value found in the segment s(p[x]..q[x])
         */
        public static int[] DnaSequence(string S, int[] P, int[] Q)
        {
            // Acumulate results
            List<int> results = new List<int>();

            // List of values
            List<int> values = S.ToCharArray().Select(c => c == 'A' ? 1 : c == 'C' ? 2 : c== 'G' ? 3 : c=='T' ? 4 : 0).ToList();

            // Loop queries
            for (int x=0; x< P.Length; x++)
            {
                // Add the minimum value of subarray
                results.Add(values.GetRange(P[x], Q[x] - P[x]+1).Min());
            }

            return results.ToArray();
        }
        /*
         *  Position of Minimum slice Average
         *  
         *  
         */
        public static int PosMinSliceAverage ( int[] A)
        {
            // Matrix with prefix sum of slices
            int[] p1 = new int[A.Length];
            int[] p2 = new int[A.Length];


            // Loop A 
            p1[0] = A[0];
            for ( int y = 1; y< A.Length; y++)
            {
                // Prefix sum
                p1[y] = A[y]+p1[y-1];
            }

            Console.WriteLine(String.Join(",", A));
            for ( int x=0; x< A.Length; x++)
            {
                Console.Write($"{p1[x]},");
            }

            return 0;
        }
    }
}
