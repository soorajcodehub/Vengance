using System;
using System.Collections.Generic;

namespace CrackThat
{
    public class ValueStructure
    {
        int intValue;
        Dictionary<string, ValueStructure> valueStruct;

        public ValueStructure(int? intValue = null, Dictionary<string, ValueStructure> valueStruct = null)
        {
            if (intValue != null && valueStruct != null)
            {
                throw new Exception("both cannot be set");
            }
            else if (intValue != null)
            {
                this.intValue = (int)intValue;
            }
            else
            {
                this.valueStruct = valueStruct;
            }
        }

        public int IntValue { get => intValue; }
        public Dictionary<string, ValueStructure> ValueStruct { get => this.valueStruct; }
    }

    public class FlattenDictionary
    {

        public static Dictionary<string, int> Flatten(Dictionary<string, ValueStructure> dict)
        {
            Dictionary<string, int> resultDictionary = new Dictionary<string, int>();
            FlattenUtil(dict, "", resultDictionary);

            foreach(KeyValuePair<string, int> keyValue in resultDictionary)
            {
                Console.WriteLine(keyValue.Key + " ===> " + keyValue.Value);
            }

            return resultDictionary;
        }

        private static void FlattenUtil(Dictionary<string, ValueStructure> dict, string key, Dictionary<string, int> resultDictionary)
        {
            foreach (KeyValuePair<string, ValueStructure> dictKeyValue in dict)
            {
                if (dictKeyValue.Value.ValueStruct != null)
                {
                    FlattenUtil(dictKeyValue.Value.ValueStruct, key + dictKeyValue.Key, resultDictionary);
                }
                else 
                {
                    resultDictionary.Add(key + "." + dictKeyValue.Key, dictKeyValue.Value.IntValue);
                }
            }
        }
    }
}
