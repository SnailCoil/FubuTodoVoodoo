using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace FubuExperiment {
	public class Global : System.Web.HttpApplication {

		protected void Application_Start(object sender, EventArgs e) {
			FubuApplication.For<FubuExperimentRegistry>()
				.StructureMap(new Container())
				.Bootstrap();
		}
	}
}