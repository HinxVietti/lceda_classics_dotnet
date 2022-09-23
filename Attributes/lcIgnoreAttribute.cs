
using System;
using System.Collections.Generic;

namespace _LC_Classis_dotnetf.Attributes
{
    [AttributeUsage(((int)AttributeTargets.Field + AttributeTargets.Property))]
    public class lcIgnoreAttribute : Attribute
    {

    }
}