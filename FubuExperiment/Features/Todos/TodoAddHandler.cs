using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Continuations;
using FubuExperiment.Services;
using FubuMVC.Core.Ajax;

namespace FubuExperiment.Handlers.Todos {
	public class TodoAddHandler {
		private ITodoService todoService;

		public TodoAddHandler(ITodoService todoService) {
			this.todoService = todoService;
		}

		public AjaxContinuation AddTodoCommand(TodoAddModel input) {
			var todo = new Todo() { Description = input.Description, Title = input.Title };
			bool successful = todoService.addTodo(input.Username, todo);
			return new AjaxContinuation() { ShouldRefresh = successful, Success = successful, Message = successful?"Todo added!":"Todo not added.." };
		}
	}

	public class TodoAddModel {
		public String Title { get; set; }
		public String Description { get; set; }
		public String Username { get; set; }
	}
}