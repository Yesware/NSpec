﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NSpec.Domain
{
    [Serializable]
    public class ContextCollection : List<Context>
    {
        public ContextCollection(IEnumerable<Context> contexts) :base(contexts){}

        public ContextCollection(){}

        public IEnumerable<Example> Examples()
        {
            return this.SelectMany(c => c.AllExamples());
        }

        public IEnumerable<Example> Failures()
        {
            return Examples().Where(e => e.Exception != null);
        }

        public IEnumerable<Example> Pendings()
        {
            return Examples().Where(e => e.Pending);
        }
    }
}