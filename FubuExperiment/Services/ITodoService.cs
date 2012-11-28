using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FubuExperiment.Services {
	public interface ITodoService {
		bool addTodo(String username, Todo todo);
		bool editTodo(String username, Todo updated);
		bool deleteTodo(String username, int todoID);
		IEnumerable<Todo> getTodosForUser(String username);
	}
}