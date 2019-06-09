﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Core.Networking
{
    public struct MessageWrapper
    {
        public string TypeName { get; }
        public object Object { get; }
        public TypeNameStrategy TypeNameStrategy { get; }

        public MessageWrapper(object obj)
        {
            var objType = obj.GetType();
            var fullName = objType.FullName;
            if (fullName == null)
            {
                TypeNameStrategy = TypeNameStrategy.AssemblyAndName;
                TypeName = $"{objType.Assembly}{objType.Name}";
            }
            else
            {
                TypeNameStrategy = TypeNameStrategy.FullName;
                TypeName = fullName;
            }

            Object = obj;
        }
    }
}
