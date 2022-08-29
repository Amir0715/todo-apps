import { makeAutoObservable } from "mobx";
import { create_todos, get_todos } from "../services/todos";
import { ITodo, Todo } from "../types/types";

export class TodosStore {
    todos: ITodo[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    fetchTodos() {
        this.todos = get_todos();
    }

    remove(id: string) {
        this.todos = this.todos.filter(todo => todo.id !== id);
    }

    invert(id: string) {
        this.todos.map(todo => todo.id === id ? todo.isDone = !todo.isDone : todo);
    }

    save(id: string) {
        this.todos.map(todo => todo.id === id ? () => { create_todos(todo) } : todo);
    }

    create() {
        this.todos.push(new Todo());
    }
}
