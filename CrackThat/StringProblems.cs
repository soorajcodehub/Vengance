using System;
using System.Collections.Generic;
using System.Text;

namespace CrackThat
{
    public class StringProblems
    {
        public static List<string> FindAllValidPalindromes(String str)
        {
            int i = 0;
            int j = 1;
            int length = str.Length;
            List<string> palindromes = new List<string>();

            while (i >= 0 && j >= 0 && i < length && j < length)
            {
                if (str[i] == str[j] && i >= 0 && j < length)
                {
                    palindromes.Add(str.Substring(i, j - i + 1));
                    if (i > 0)
                    {
                        i--;
                    }
                    j++;
                }
                else
                {
                    if (i + 2 == j)
                    {
                        i = i + 1;
                    }
                    else if (i + 1 == j)
                    {
                        j = j + 1;
                    }
                    else
                    {
                        i = j;
                        j = j + 1;
                    }
                }
            }

            return palindromes;
        }

        public static string GetZigzagString(string str, int numberOfRows)
        {
            StringBuilder[] bottomAcrossStrings = new StringBuilder[numberOfRows];
            int stringIndex = 0;
            while (stringIndex < str.Length)
            {
                for (int stringBuilderIndex = 0; stringBuilderIndex < numberOfRows && stringIndex < str.Length; stringBuilderIndex++)
                {
                    if (bottomAcrossStrings[stringBuilderIndex] == null)
                    {
                        bottomAcrossStrings[stringBuilderIndex] = new StringBuilder();
                    }

                    bottomAcrossStrings[stringBuilderIndex].Append(str[stringIndex]);
                    stringIndex++;
                }

                for (int stringBuilderIndex = numberOfRows - 2; stringBuilderIndex > 0 && stringIndex < str.Length; stringBuilderIndex--)
                {
                    bottomAcrossStrings[stringBuilderIndex].Append(str[stringIndex]);
                    stringIndex++;
                }
            }

            for (int i = 1; i < numberOfRows; i++)
            {
                bottomAcrossStrings[0].Append(bottomAcrossStrings[i]);
            }

            return bottomAcrossStrings[0].ToString();
        }

        public static string LongestSubStringWithNonRepeatedCharacters(string str)
        {
            Dictionary<char, int> characterIndexLookup = new Dictionary<char, int>();
            int start, end;
            start = end = 0;
            int maxSubStringLength = 0;
            int subStringLength = 0;
            StringBuilder maxSubString = new StringBuilder();

            while (end < str.Length)
            {
                if (!characterIndexLookup.ContainsKey(str[end]))
                {
                    characterIndexLookup.Add(str[end], end);
                }
                else
                {
                    subStringLength = end - start;
                    end += 1;
                    if (subStringLength > maxSubStringLength)
                    {
                        maxSubStringLength = subStringLength;
                        maxSubString.Clear();
                        maxSubString.Append(str.Substring(start, subStringLength));
                        start = characterIndexLookup[str[end]] + 1; 
                    }
                }
            }

            if (start == 0)
            {
                return str;
            }
            else
            {
                return maxSubString.ToString();
            }
        }

        public static bool isMatch(string str, string pattern)
        {
            int i = 0;
            int j = 0;

            while (i < str.Length && j < pattern.Length)
            {
                if (str[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else if (str[i] != pattern[j])
                {
                    if (pattern[j] == '.')
                    {
                        i++;
                        j++;
                    }
                    else if (pattern[j] == '*')
                    {
                        while (i + 1 < str.Length && str[i] == str[i + 1])
                        {
                            i++;
                        }

                        if (i + 1 == str.Length)
                        {
                            return true;
                        }
                        else
                        {
                            j++;
                        }
                    }
                    else
                    {
                        if (i == str.Length - 1 || j == pattern.Length - 1)
                        {
                            return false;
                        }

                        i++;
                        j++;
                    }
                }
            }

            if (i == str.Length && j == pattern.Length)
                return true;

            else
                return false;
        }

        #region tricky bullshit

        public static void PrintFirstNonRepeatedCharacterInStream(string str)
        {
            Dictionary<char, int> charLookup = new Dictionary<char, int>();
            charLookup.Add(str[0], 1);
            char latestNonRepatingChar = str[0];
            char previousNonRepeatedChar = str[0];

            Console.Write(str[0] + " ");

            for (int j = 1; j < str.Length; j++ )
            {
                // if this is the first time we are seeing a char 
                if (!charLookup.ContainsKey(str[j]))
                {
                    // make it the latest non repeating char
                    latestNonRepatingChar = str[j];

                    // if previous char has not yet been repeated, print it
                    if (charLookup[previousNonRepeatedChar] <= 1)
                    {
                        Console.Write(previousNonRepeatedChar + " ");
                    }
                    else 
                    {
                        // else print latest repeated char 
                        // and update prev repeating char

                        previousNonRepeatedChar = latestNonRepatingChar;
                        Console.Write(latestNonRepatingChar + " ");
                    }

                    // add new char to lookup
                    charLookup.Add(latestNonRepatingChar, 1);
                }
                else 
                {
                    charLookup[str[j]] = charLookup[str[j]] + 1;

                    if (charLookup[previousNonRepeatedChar] > 1 && charLookup[latestNonRepatingChar] > 1 )
                    {
                        Console.Write(-1 + " ");
                    }

                    else
                    {
                        if (charLookup[previousNonRepeatedChar] <= 1)
                        {
                            Console.Write((previousNonRepeatedChar + " "));
                        }

                        else if (charLookup[latestNonRepatingChar] <= 1 )
                        {
                            Console.Write((latestNonRepatingChar + " "));
                            previousNonRepeatedChar = latestNonRepatingChar;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
