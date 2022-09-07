import { TodosStore } from "./TodosStore";

class Store {
    todosStore: TodosStore;

    constructor() {
        this.todosStore = new TodosStore();
    }
}

export default new Store();
