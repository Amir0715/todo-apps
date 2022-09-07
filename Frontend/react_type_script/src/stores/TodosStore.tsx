import { makeAutoObservable } from "mobx";
import { create_todos, get_todos } from "../services/todos";
import { ITodo } from "../types/types";
import { TodoStore } from "./TodoStore";

export class TodosStore {
    todos: ITodo[] = [{ id: "11213", title: "Hello world", description: "Desc", isDone: true }];

    constructor() {
        makeAutoObservable(this);
    }

    fetchTodos() {
        this.todos = get_todos();
    }

    remove(id: string) {
        this.todos = this.todos.filter(todo => todo.id !== id);
    }

    save(id: string) {
        this.todos.map(todo => todo.id === id ? () => { create_todos(todo) } : todo);
    }

    create() {
        this.todos.push(new TodoStore());
    }
}
