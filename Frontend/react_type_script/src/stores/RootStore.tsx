import { TodosStore } from "./TodosStore";

export class RootStore {
    todosStore: TodosStore;

    constructor() {
        this.todosStore = new TodosStore(this);
    }
}

export default new RootStore();
