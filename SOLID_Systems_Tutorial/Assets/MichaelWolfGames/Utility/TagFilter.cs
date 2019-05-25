using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MichaelWolfGames.Utility
{
    /// <summary>
    /// Utility struct for managing tag checks.
    /// </summary>
    public struct TagFilter
	{
        public string[] TargetTags;// = new string[1] { "Enemy" };
        public string[] IgnoreTags;

	    public TagFilter(string[] targetTags = null, string[] ignoreTags = null)
	    {
	        TargetTags = targetTags;
	        IgnoreTags = ignoreTags;
	    }

	    public bool CheckTag(string tag)
	    {
	        //if (CheckForTarget(tag)) return true;
            if (CheckForIgnore(tag)) return false;
            return true;
        }
        public bool CheckForIgnore(string tag)
        {
            return CheckFilter(tag, IgnoreTags);
        }
        public bool CheckForTarget(string tag)
        {
            return CheckFilter(tag, TargetTags);
        }

	    private bool CheckFilter(string tag, string[] filterTags)
	    {
            if (filterTags == null) return false;
            if (filterTags.Length < 1) return false;
            for (int i = 0; i < filterTags.Length; i++)
            {
                if (filterTags[i] == tag)
                    return true;
            }
            return false;
        }

    }
}