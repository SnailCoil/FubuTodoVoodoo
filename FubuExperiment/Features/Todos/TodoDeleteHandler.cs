using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Ajax;
using FubuExperiment.Services;

namespace FubuExperiment.Handlers.Todos {
	public class TodoDeleteHandler {
		private ITodoService todoService;

		public TodoDeleteHandler(ITodoService todoService) {
			this.todoService = todoService;
		}

		public AjaxContinuation DeleteTodoCommand(TodoDeleteModel input) {
			bool successful = todoService.deleteTodo(input.Username, input.ID);
			return new AjaxContinuation() { ShouldRefresh = successful, Success = successful, Message = successful ? "Deleted!" : "Not deleted.." };
		}
	}

	public class TodoDeleteModel {
		public int ID { get; set; }
		public String Username { get; set; }
	}
}