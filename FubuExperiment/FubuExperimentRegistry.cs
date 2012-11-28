using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FubuMVC.Core;
using FubuExperiment.Services;
using FubuExperiment.Handlers.Home;

namespace FubuExperiment {
	class FubuExperimentRegistry : FubuRegistry {
		public FubuExperimentRegistry() {
			Actions.FindBy(x => {
				x.Applies.ToThisAssembly();
				x.IncludeTypesNamed(t => t.EndsWith("Handler"));
			});

			Routes.HomeIs<IndexInput>().
				IgnoreMethodSuffix("Fetch").
				IgnoreMethodSuffix("Command").
				IgnoreControllerNamespaceEntirely().
				IgnoreControllerNamesEntirely();
			Routes.ConstrainToHttpMethod(x => x.Method.Name.EndsWith("Fetch"), "GET");
			Routes.ConstrainToHttpMethod(x => x.Method.Name.EndsWith("Command"), "POST");

			Services(x => x.SetServiceIfNone<IMembershipService, InMemoryMembershipService>());
			Services(x => x.SetServiceIfNone<ITodoService, InMemoryTodoService>()); 
		}
	}
}
