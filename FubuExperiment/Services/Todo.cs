using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FubuExperiment.Services {
	public class Todo {
		private static int index;
		private static int Index { 
			get { 
				index++; 
				return index; 
			}
		}

		private int todoID = -1;
		public int ID { 
			get { return todoID; } 
			set { todoID = value; }
		}
		public String Description { get; set; }
		public String Title { get; set; }

		public Todo(int todoID) {
			this.todoID = todoID;
		}

		public Todo() {
			this.todoID = Index;
		}

		public override bool Equals(object obj) {
			bool result;
			if(obj != null && obj is Todo) {
				result = ((Todo)obj).ID == this.ID;
			} else {
				result = false;
			}
			return result;
		}

		public override int GetHashCode() {
			return ID;
		}

		public override string ToString() {
			return "Todo #"+ID+" Desc: "+Description+" Title: "+Title;
		}
	}
}
