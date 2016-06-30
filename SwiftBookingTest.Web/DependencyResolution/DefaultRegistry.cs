// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SwiftBookingTest.Web.DependencyResolution
{
    using Core;
    using Core.BusinessEngine;
    using Core.Helpers;
    using CoreContracts;
    using CoreContracts.BusinessEngine;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Security.Principal;
    using System.Web;
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IExample>().Use<Example>();

            For<IIdentity>().Use(() => HttpContext.Current.User != null ? HttpContext.Current.User.Identity : null);

            //TODO:Create Interface for dbcontext and bind to that
            For<SwiftDemoContext>().Use(new SwiftDemoContext());

            //For<ILogger>().ToMethod(ctx => (ILogger)ctx.Kernel.Get<ILogger>());

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            For<RepositoryFactories>().Use<RepositoryFactories>()
                .Ctor<IDictionary<Type, Func<DbContext, object>>>()
                .Is(new Dictionary<Type, Func<DbContext, object>>());

            For<IRepositoryProvider>().Use<RepositoryProvider>();

            For<IBusinessEngineFactory>().Use<BusinessEngineFactory>()
                .Ctor<IDictionary<Type, object>>("businessEngine").Is(new Dictionary<Type, object>());

            For<ISwiftBookingBusinessEngineUow>().Use<SwiftBookingBusinessEngineUow>();

            For<ISwiftDemoUow>().Use<SwiftDemoUow>();

            

        }

        #endregion
    }
}