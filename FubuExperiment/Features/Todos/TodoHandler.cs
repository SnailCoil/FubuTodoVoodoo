using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuExperiment.Services;
using FubuMVC.Core.Security;

namespace FubuExperiment.Handlers.Todos {
	public class TodoHandler {
		private ITodoService todoService;
		private ISecurityContext securityContext;

		public TodoHandler(ITodoService todoService, ISecurityContext securityContext) {
			this.todoService = todoService;
			this.securityContext = securityContext;
		}

		public TodoIndexModel Todo(TodoIndexInput input) {
			string username = securityContext.CurrentIdentity.Name;
			return new TodoIndexModel() { Todos = todoService.getTodosForUser(username), Username = username };
		}
	}

	public class TodoIndexInput {
	}

	public class TodoIndexModel {
		public IEnumerable<Todo> Todos { get; set; }
		public String Username { get; set; }
	}
}