import { makeAutoObservable, observable } from "mobx";
import { create_todos, get_todos } from "../services/todos";
import { ITodo } from "../types/types";
import { RootStore } from "./RootStore";
import { Todo } from "./Todo";

export class TodosStore {
    @observable todos: Todo[] = [];
    rootStore: RootStore

    constructor(rootStore: RootStore) {
        makeAutoObservable(this);
        this.rootStore = rootStore;
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

    add(todo: Todo) {
        this.todos.push(todo);
    }
}
