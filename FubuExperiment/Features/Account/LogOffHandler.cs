using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using FubuExperiment.Handlers.Home;

namespace FubuExperiment.Handlers.Account {
	public class LogOffHandler {
		private readonly IAuthenticationContext _authenticationContext;

		public LogOffHandler(IAuthenticationContext authenticationContext) {
			_authenticationContext = authenticationContext;
		}

		public FubuContinuation LogOff(LogOffInput input) {
			_authenticationContext.SignOut();
			return FubuContinuation.RedirectTo<IndexInput>();
		}
	}

	public class LogOffInput {
	}

}