using _LC_Classis_dotnetf.Attributes;
using System;
using System.Collections.Generic;

namespace _LC_Classis_dotnetf.Common
{
    public class lcMeta
    {
        public string cmdKey;

        [lcIgnore]
        public readonly string[] _paras;

        public lcMeta(string[] args)
        {
            _paras = args;
            cmdKey = args[0];
        }
    }
}