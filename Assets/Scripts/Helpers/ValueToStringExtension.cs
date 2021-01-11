using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ValueToStringExtension
{
    /// <summary>
    /// contains method for correct (for js) converting values to string.
    /// </summary>
    public static class ValueToStringExtension
    {
        private const string validVariableNameSpecialCharacters = "_$";

        private const char notValidCharacterReplacer = '_';

        /// <summary>
        /// invariant string representation of value.
        /// </summary>
        /// <param name="value">value.</param>
        /// <returns>invariant string representation of value.</returns>
        public static string ToInvariantString(this float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// makes sure that variable doesn't have prohibited for js variables symbols, and if they are, replace them to correct.
        /// </summary>
        /// <param name="value">value.</param>
        /// <returns>correct js variable name.</returns>
        public static string ToValidVariableName(this string value)
        {
            char[] validCharacters = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                validCharacters[i] = IsCharacterValid(value[i]) ? value[i] : notValidCharacterReplacer;
            }

            return new string(validCharacters);
        }

        /// <summary>
        /// gets correct js variable name for the given unity scene objct.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns>correct js variable name.</returns>
        public static string GetVariableName(this GameObject gameObject)
        { 
            StringBuilder nameConstructor = new StringBuilder(50);

            // we will construct full variable name using its parents.
            // we want to save correct order of names in hierarchy, so we use Stack.
            var allHierarchyNames = new Stack<string>();
            allHierarchyNames.Push(gameObject.name);

            var currentGameObject = gameObject;
            while (currentGameObject.transform.parent != null)
            {
                allHierarchyNames.Push(currentGameObject.transform.parent.name);
                currentGameObject = currentGameObject.transform.parent.gameObject;
            }

            foreach (var hierarchyName in allHierarchyNames)
            {
                nameConstructor.Append(hierarchyName);
                nameConstructor.Append(notValidCharacterReplacer);
            }
         
            // just to make sure that js variables names will be unique.
            nameConstructor.Append($"${gameObject.GetHashCode()}");
            
            // replacing all not walid for js variables symbols to valid.
            return nameConstructor.ToString().ToValidVariableName();
        }

        private static bool IsCharacterValid(char c)
            => char.IsLetterOrDigit(c) || validVariableNameSpecialCharacters.Contains(c);
    }
}
