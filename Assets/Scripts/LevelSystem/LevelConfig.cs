using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace LevelSystem
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Level Config", order = 52)]
    public class LevelConfig : ScriptableObject
    {
        [System.Serializable]
        private class LevelSetup
        {
            [field: SerializeField, Scene] public string StrLevel { get; set; }
        }
        
        [SerializeField] private List<LevelSetup> _levelSetup = new();

        public string GetNextLevel(string currentLevelName)
        {
            for (var index = 0; index < _levelSetup.Count; index++)
            {
                var levelSetup = _levelSetup[index];

                if (levelSetup.StrLevel != currentLevelName) 
                    continue;
                
                if (index + 1 >= _levelSetup.Count)
                    return _levelSetup[0].StrLevel;
                    
                return _levelSetup[index + 1].StrLevel;
            }

            return _levelSetup[0].StrLevel;
        }
    }
}