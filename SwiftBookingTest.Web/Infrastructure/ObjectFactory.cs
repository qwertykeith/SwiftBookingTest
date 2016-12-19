﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SwiftBookingTest.Web.Infrastructure
{
    public static class ObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
        new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            return new Container();
        }
    }
}