using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FubuExperiment.Services {
	public class InMemoryTodoService : ITodoService {
		private static Dictionary<string, HashSet<Todo>> userTodos = new Dictionary<string, HashSet<Todo>>();

		public bool addTodo(string username, Todo todo) {
			if (!userTodos.ContainsKey(username)) {
				userTodos[username] = new HashSet<Todo>();
			}
			return userTodos[username].Add(todo);
		}

		public bool deleteTodo(string username, int todoID) {
			bool result;
			if (userTodos.ContainsKey(username)) {
				var todos = userTodos[username];
				result = todos.Remove(new Todo(todoID));
			} else {
				result = false;
			}
			return result;
		}

		public bool editTodo(string username, Todo updated) {
			bool result = false;
			if (userTodos.ContainsKey(username)) {
				var todos = userTodos[username];
				Todo modified = todos.Single(x => x.ID == updated.ID);
				todos.Remove(modified);
				todos.Add(updated);
				result = true;
			}
			return result;
		}

		public IEnumerable<Todo> getTodosForUser(string username) {
			if(userTodos.ContainsKey(username)) {
				return userTodos[username];
			} else {
				return new HashSet<Todo>();
			}
		}
	}
}