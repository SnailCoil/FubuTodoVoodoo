namespace FubuExperiment.Handlers.Home {
	public class HomeHandler {
		public IndexModel IndexFetch(IndexInput input) {
			return new IndexModel {
				Message = "Welcome to FUBUMVC!"
			};
		}
	}

	public class IndexInput {
	}

	public class IndexModel {
		public string Message { get; set; }
	}

}