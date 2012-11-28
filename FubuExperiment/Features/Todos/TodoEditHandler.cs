using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuExperiment.Services;
using FubuMVC.Core.Ajax;

namespace FubuExperiment.Handlers.Todos {
	public class TodoEditHandler {
		private ITodoService todoService;

		public TodoEditHandler(ITodoService todoService) {
			this.todoService = todoService;
		}

		public AjaxContinuation EditTodoCommand(TodoEditModel input) {
			var todo = new Todo(input.ID) { Description = input.Description, Title = input.Title };
			bool successful = todoService.editTodo(input.Username, todo);
			return new AjaxContinuation() { ShouldRefresh = false, Success = successful, Message = successful ? "Changes saved!" : "Changes not saved.." };
		}
	}

	public class TodoEditModel {
		public int ID { get; set; }
		public String Title { get; set; }
		public String Description { get; set; }
		public String Username { get; set; }
	}
}