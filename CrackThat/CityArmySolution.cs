
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CityArmySolution
{

    /*
     * Complete the function below.
     */

    static string[] EvaluateActions(string[] actions)
    {
        ActionData[] actionDataArray = new ActionData[actions.Length];

        for (int i = 0; i < actions.Length; i++)
        {
            actionDataArray[i] = CreateActionData(actions[i]);
        }

        Dictionary<string, Army> ArmyLookup = new Dictionary<string, Army>();
        Dictionary<string, List<Army>> CityArmyLookup = new Dictionary<string, List<Army>>();

        for (int i = 0; i < actionDataArray.Length; i++)
        {
            ActionData actionData = actionDataArray[i];
            Army army = new Army(actionData.armyName, actionData.currentLocation, 0);
            ArmyLookup.Add(actionData.armyName, army);
            List<Army> armies = new List<Army>();
            armies.Add(army);
            CityArmyLookup.Add(actionData.currentLocation, armies);
        }

        for (int i = 0; i < actionDataArray.Length; i++)
        {
            ActionData actionData = actionDataArray[i];
            if (actionData.action.Equals("Move"))
            {
                List<Army> armysAtCity = CityArmyLookup[actionData.actionArgument];
                Army attackingArmy = ArmyLookup[actionData.armyName];
                attackingArmy.hasMoved = true;
                armysAtCity.Add(attackingArmy);
            }
        }

        for (int i = 0; i < actionDataArray.Length; i++)
        {
            ActionData actionData = actionDataArray[i];
            if (actionData.action.Equals("Support"))
            {
                Army armyBeingSupported = ArmyLookup[actionData.actionArgument];
                Army supportingArmy = ArmyLookup[actionData.armyName];

                if (CityArmyLookup[supportingArmy.baseCity].Count == 1)
                {
                    armyBeingSupported.strength += supportingArmy.strength;
                }
            }
        }

        StringBuilder[] outputArmies = new StringBuilder[actions.Length];
        int outputArmyCount = 0;

        foreach (KeyValuePair<string, List<Army>> CityArmies in CityArmyLookup)
        {
            List<Army> armiesAtCity = CityArmies.Value;

            if (armiesAtCity.Count > 1)
            {
                int previousStrength = armiesAtCity[0].strength;
                bool areAllDead = false;
                string winningArmy = "";

                for (int i = 1; i < armiesAtCity.Count; i ++)
                {
                    if (armiesAtCity[i].strength == previousStrength)
                    {
                        areAllDead = true;
                    }
                    else if (armiesAtCity[i].strength > previousStrength)
                    {
                        areAllDead = false;
                        winningArmy = armiesAtCity[i].ArmyName;
                        previousStrength = armiesAtCity[i].strength;
                    }
                    else 
                    {
                        areAllDead = false;
                        winningArmy = armiesAtCity[i -1].ArmyName;
                    }
                }

                if (areAllDead) 
                {
                    for (int i = 0; i < armiesAtCity.Count; i ++)
                    {
                        outputArmies[outputArmyCount] = new StringBuilder();
                        outputArmies[outputArmyCount].Append("dead");
                        outputArmyCount++;
                    }
                }
                else 
                {
                    outputArmies[outputArmyCount] = new StringBuilder();
                    outputArmies[outputArmyCount].Append(winningArmy + " " + CityArmies.Key + " ");
                }
            }
            else 
            {
                Army armyAtCity = armiesAtCity[0];
                if (!armyAtCity.hasMoved)
                {
                    outputArmies[outputArmyCount].Append((armyAtCity.ArmyName + " " + "has city " + CityArmies.Key));
                }
            }
        }

        string[] armiesOutputs = new string[outputArmies.Length];
        for (int p = 0; p < outputArmies.Length; p++)
        {
            armiesOutputs[p] = outputArmies[p].ToString();
        }

        return armiesOutputs;
    }


    private static ActionData CreateActionData(string action)
    {
        string[] actionBreakup = action.Split(' ');
        string actionArgument = actionBreakup.Length > 3 ? actionBreakup[3] : null;
        return new ActionData(actionBreakup[0], actionBreakup[1], actionBreakup[2], actionArgument);

    }

    internal class ActionData
    {
        public string armyName;
        public string currentLocation;
        public string action;
        public string actionArgument;

        internal ActionData(string armyName, string currentLocation, string action, string actionArgument = null)
        {
            this.armyName = armyName;
            this.currentLocation = currentLocation;
            this.action = action;
            this.actionArgument = actionArgument;

        }

    }

    internal class Army
    {
        public string ArmyName;
        public string baseCity;
        public int strength;
        public bool hasMoved;
        public Army(string armyName, string baseCity, int strength = 1)
        {
            this.ArmyName = armyName;
            this.baseCity = baseCity;
            this.strength = strength;
        }
    }
}